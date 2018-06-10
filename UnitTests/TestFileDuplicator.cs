using System;
using System.IO;
using TestBigProject;
using Xunit;
using SFC = TestBigProject.StringFormattingConstants;

namespace UnitTests
{
    public class TestFileDuplicator
    {
        [Fact]
        public void FileDuplicator_Correctly_Creates_Nameof_File()
        {
            // Arrange
            FileDuplicator duplicator = new FileDuplicator(numberOfDuplicateFiles: 1, numberOfLinesPerFile: 1);
            string formatNameOf = $"{SFC.TABS_FOR_FILE_BODY_LINES}s = nameof({{0}});{SFC.END_LINE}";
            string projectName = "UnitTestNameOf";
            DirectoryInfo projectDirectory = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\..\..\..\..\{projectName}");
            string duplicateFolderName = "Duplicates";

            // Act
            duplicator.DuplicateFiles(formatNameOf, projectDirectory, duplicateFolderName); //TODO: probably can name the file for duplicates without an argument

            // Assert
            string duplicateFilePath = $@"{projectDirectory}\{duplicateFolderName}\Program0.cs";
            string fileText = File.ReadAllText(duplicateFilePath);
            string expectedFileText =
$@"namespace {duplicateFolderName}
{{
    class Program0
    {{
        private void Test()
        {{
            string s;
            s = nameof(Program0);
        }}
    }}
}}";
            Assert.Equal(expectedFileText, fileText);
        }
    }
}
