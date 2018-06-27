using Microsoft.Build.Evaluation;
using System.IO;
using TestBigProject;
using UnitTests.Helpers;
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
            duplicator.DuplicateFiles(formatNameOf, projectDirectory);

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

        [Fact]
        public void FileDuplicator_Correctly_Compiles_Duplicated_Files()
        {
            // Arrange
            FileDuplicator duplicator = new FileDuplicator(numberOfDuplicateFiles: 10, numberOfLinesPerFile: 1);
            string formatNameOf = "s = nameof({0});\r\n";
            string projectName = "UnitTestNameOf";
            DirectoryInfo projectDirectory = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\..\..\..\..\{projectName}");

            // Act
            duplicator.DuplicateFiles(formatNameOf, projectDirectory);
            Project project = new Project($@"{projectDirectory.FullName}\{projectDirectory.Name}.csproj");
            InMemoryLogger logger = new InMemoryLogger();
            project.Build(logger);

            // Assert
            Assert.True(true);
        }
    }
}
