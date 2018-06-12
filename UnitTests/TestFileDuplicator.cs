using System.IO;
using TestBigProject;
using Xunit;

namespace UnitTests
{
    public class TestFileDuplicator
    {
        [Fact]
        public void FileDuplicator_Correctly_Creates_Nameof_File()
        {
            // Arrange
            FileDuplicator duplicator = new FileDuplicator(numberOfDuplicateFiles: 1, numberOfLinesPerFile: 1);
            string formatNameOf = "s = nameof({0});\r\n";
            string projectName = "UnitTestNameOf";
            DirectoryInfo projectDirectory = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\..\..\..\..\{projectName}");

            // Act
            duplicator.DuplicateFiles(formatNameOf, projectDirectory); //TODO: probably can name the file for duplicates without an argument

            // Assert
            string duplicateFilePath = $@"{projectDirectory}\DuplicatedFiles\Program0.cs";
            string fileText = File.ReadAllText(duplicateFilePath);
            string expectedFileText =
@"namespace DuplicatedFiles
{
    class Program0
    {
        private void Test()
        {
            string s;
            s = nameof(Program0);
        }
    }
}";
            Assert.Equal(expectedFileText, fileText);
        }
    }
}
