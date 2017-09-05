using System;
using System.IO;
using System.Text;
using SFC = TestBigProject.StringFormattingConstants;

namespace TestBigProject
{
    public class FileDuplicator
    {
        /// <summary>
        /// Format to use for creating the test file.
        /// Parameters: (namespace, program number, file body)
        /// </summary>
        private const string FORMAT_FOR_TEST_FILE =
@"namespace {0}
{{
    class Program{1}
    {{
        private void Test()
        {{
            string s;
{2}        }}
    }}
}}";

        /// <summary>
        /// Format to use for creating the lines in the .csproj file for specifying which files to compile.
        /// Parameters: (relative file path, file name)
        /// </summary>
        private static readonly string FORMAT_FOR_FILE_INCLUSION = $"    <Compile Include={SFC.DOUBLE_QUOTE}{{0}}{{1}}{SFC.DOUBLE_QUOTE} />";

        private static readonly Random seedGenerator = new Random();

        private static readonly string PROGRAM_CS_INCLUSION = string.Format(FORMAT_FOR_FILE_INCLUSION, "", "Program.cs");
        private static readonly string ASSEMBLYINFO_CS_INCLUSION = string.Format(FORMAT_FOR_FILE_INCLUSION, @"Properties\", "AssemblyInfo.cs");
        private const string COMPILATION_INCLUSION_IDENTIFIER = "<Compile Include=";

        private int _numberOfDuplicateFiles = 0;
        public int NumberOfDuplicateFiles
        {
            get
            {
                return _numberOfDuplicateFiles;
            }
            set
            {
                if (value < 0) throw new MemberAccessException("Tried to set NumberOfDuplicateFiles to a value less than zero.");
                _numberOfDuplicateFiles = value;
            }
        }

        private int _numberOfLinesPerFile = 0;
        public int NumberOfLinesPerFile
        {
            get
            {
                return _numberOfLinesPerFile;
            }
            set
            {
                if (value < 0) throw new MemberAccessException("Tried to set NumberOfLinesPerFile to a value less than zero.");
                _numberOfLinesPerFile = value;
            }
        }

        // ********** CLASS AND INSTANCE VARIABLES ABOVE THIS LINE ********** //

        public FileDuplicator() { }

        public void DuplicateFiles(string format, string projectName, string duplicateDirectoryName)
        {
            string duplicateFilesToCompile = CreateDuplicateFiles(projectName, duplicateDirectoryName, format);
            string allFilesToCompile = $"{PROGRAM_CS_INCLUSION}{SFC.END_LINE}{duplicateFilesToCompile}{ASSEMBLYINFO_CS_INCLUSION}";
            AddInclusionsToProject(projectName, allFilesToCompile);
        }

        /// <summary>
        /// Creates many duplicate files, whose name and containing class name is "Program{i}",
        /// where i is the iteration number for creating the files, starting from zero.
        /// </summary>
        /// <param name="directoryName">Name to give the directory that will hold all of the created duplicate files.</param>
        /// <param name="formatToCreateLineWithClassNameString">Format used to create each line of the file body, with one parameter being the class name to reference in the test</param>
        /// <returns>String for the .csproj that specifies the files to compile</returns>
        private string CreateDuplicateFiles(string projectName, string directoryName, string formatToCreateLineWithClassNameString)
        {
            StringBuilder filesToCompileStringBuilder = new StringBuilder();

            string duplicateDirectoryPath = string.Format(StringFormattingConstants.DUPLICATE_DIRECTORY_PATH_FORMAT, projectName, directoryName);
            Directory.CreateDirectory(duplicateDirectoryPath);

            for (int i = 0; i < _numberOfDuplicateFiles; i++)
            {
                string fileName = $"Program{i}.cs";
                filesToCompileStringBuilder.AppendLine(string.Format(FORMAT_FOR_FILE_INCLUSION, $@"{directoryName}\", fileName));
                using (FileStream duplicateFileStream = File.Create($"{duplicateDirectoryPath}{fileName}"))
                {
                    string fileBody = GetFileBody(formatToCreateLineWithClassNameString);
                    string fileText = string.Format(FORMAT_FOR_TEST_FILE, directoryName, i, fileBody);
                    Byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    duplicateFileStream.Write(info, 0, info.Length);
                }
            }

            return filesToCompileStringBuilder.ToString();
        }

        /// <summary>
        /// Adds the files from the input filesToCompile to the .csproj file that is found with
        /// the specified name and is located in "bin/Debug/../../projectName/".
        /// The files are added and replace all inclusions aside from Program.cs and Properties\AssemblyInfo.cs.
        /// </summary>
        /// <param name="projectPath">Path to the .csproj file to add file inclusions to.</param>
        /// <param name="filesToCompile">String of the file inclusions to add to the .csproj file.</param>
        private void AddInclusionsToProject(string projectName, string filesToCompile)
        {
            string projectPath = string.Format(StringFormattingConstants.PROJECT_PATH_FORMAT, projectName);

            string[] fileText = File.ReadAllLines(projectPath);
            int lineNumberBeforeFirstCompilationInclusion = GetLineNumberBeforeFirstCompilationInclusion(fileText);
            int lineNumberAfterLastCompilationInclusion = GetLineNumberAfterLastCompilationInclusion(fileText);

            using (FileStream projectFileStream = File.Create(projectPath))
            {
                string fileTextBeforeInclusions = string.Join(SFC.END_LINE, fileText, 0, lineNumberBeforeFirstCompilationInclusion);
                Byte[] fileBytesBeforeInclusions = new UTF8Encoding(true).GetBytes(fileTextBeforeInclusions);
                projectFileStream.Write(fileBytesBeforeInclusions, 0, fileBytesBeforeInclusions.Length);

                Byte[] fileBytesForInclusions = new UTF8Encoding(true).GetBytes($"{SFC.END_LINE}{filesToCompile}{SFC.END_LINE}");
                projectFileStream.Write(fileBytesForInclusions, 0, fileBytesForInclusions.Length);

                string fileTextAfterInclusions = string.Join(SFC.END_LINE, fileText, lineNumberAfterLastCompilationInclusion - 1, fileText.Length - lineNumberAfterLastCompilationInclusion + 1);
                Byte[] fileBytesAfterInclusions = new UTF8Encoding(true).GetBytes(fileTextAfterInclusions);
                projectFileStream.Write(fileBytesAfterInclusions, 0, fileBytesAfterInclusions.Length);
            }
        }

        /// <summary>
        /// For the input fileText, finds the line number immediately after the line of the last compilation inclusion.
        /// If no compilation inclusion is found, an array out of bounds exception will be thrown.
        /// </summary>
        /// <param name="fileText">Text to search through for the last compilation inclusion</param>
        /// <returns>Line number immediately after the line of the last compilation inclusion</returns>
        private int GetLineNumberAfterLastCompilationInclusion(string[] fileText)
        {
            const int SHIFT_TO_AFTER_LAST_COMPILATION_INCLUSION = 1;
            int lineNumber = fileText.Length;

            while (!fileText[lineNumber - 1].Contains(COMPILATION_INCLUSION_IDENTIFIER))
            {
                lineNumber--;
            }

            return lineNumber + SHIFT_TO_AFTER_LAST_COMPILATION_INCLUSION;
        }

        /// <summary>
        /// For the input fileText, finds the line number immediately before the line of the first compilation inclusion.
        /// If no compilation inclusion is found, an array out of bounds exception will be thrown.
        /// </summary>
        /// <param name="fileText">Text to search through for the first compilation inclusion</param>
        /// <returns>Line number immediately before the line of the first compilation inclusion</returns>
        private int GetLineNumberBeforeFirstCompilationInclusion(string[] fileText)
        {
            const int SHIFT_TO_BEFORE_FIRST_COMPILATION = 1;
            int lineNumber = 1;

            while (!fileText[lineNumber - 1].Contains(COMPILATION_INCLUSION_IDENTIFIER))
            {
                lineNumber++;
            }

            return lineNumber - SHIFT_TO_BEFORE_FIRST_COMPILATION;
        }

        /// <summary>
        /// Creates the body for the test file.
        /// Each line in the body sets the value of a string variable to the name of a class called "Program{x}",
        /// where x is a random number between 0 and NUM_DUPLICATE_FILES.
        /// </summary>
        /// <param name="formatToCreateLineWithClassNameString">Format whose parameter is the class name to reference in the test.</param>
        /// <returns></returns>
        private string GetFileBody(string formatToCreateLineWithClassNameString)
        {
            StringBuilder bodyBuilder = new StringBuilder();
            Random rand = new Random(seedGenerator.Next());

            for (int i = 0; i < _numberOfLinesPerFile; i++)
            {
                int randomNumber = rand.Next(_numberOfDuplicateFiles);
                bodyBuilder.Append(string.Format(formatToCreateLineWithClassNameString, $"Program{randomNumber}"));
            }

            return bodyBuilder.ToString();
        }
    }
}
