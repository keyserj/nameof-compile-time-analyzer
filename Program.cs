using Microsoft.Build.Evaluation;
using System;
using System.Diagnostics;
using System.IO;
using SFC = TestBigProject.StringFormattingConstants;

namespace TestBigProject
{
    public class Program
    {
        private const int NUM_DUPLICATE_FILES = 3;
        private const int NUM_LINES_PER_FILE = 10;
        private const int NUM_TIMES_TO_BUILD_PROJECTS = 10;

        private static void Main(string[] args)
        {
            // Initialize
            string formatNameOf = $"{SFC.TABS_FOR_FILE_BODY_LINES}s = nameof({{0}});{SFC.END_LINE}";
            string projectNameTestingNameOf = "TestBigNameOf";
            DirectoryInfo projectDirectoryTestingNameOf = GetDirectoryInfo(projectNameTestingNameOf);

            string formatLiteral = $"{SFC.TABS_FOR_FILE_BODY_LINES}s = {SFC.DOUBLE_QUOTE}{{0}}{SFC.DOUBLE_QUOTE};{SFC.END_LINE}";
            string projectNameTestingLiteral = "TestBigLiteral";
            DirectoryInfo projectDirectoryTestingLiteral = GetDirectoryInfo(projectNameTestingLiteral);

            // Create files
            FileDuplicator duplicator = new FileDuplicator(NUM_DUPLICATE_FILES, NUM_LINES_PER_FILE);
            duplicator.DuplicateFiles(formatNameOf, projectDirectoryTestingNameOf, "DuplicatedNameOfFiles");
            duplicator.DuplicateFiles(formatLiteral, projectDirectoryTestingLiteral, "DuplicatedLiteralFiles");

            // Time builds
            TimeSpan timeForNameOf = TimeBuild(projectNameTestingNameOf, NUM_TIMES_TO_BUILD_PROJECTS);
            TimeSpan timeForLiteral = TimeBuild(projectNameTestingLiteral, NUM_TIMES_TO_BUILD_PROJECTS);

            // Output times
            Console.WriteLine(
                $"\nFor each test, " +
                $"{NUM_DUPLICATE_FILES} duplicated files were built {NUM_TIMES_TO_BUILD_PROJECTS} times, " +
                $"and each file used {NUM_LINES_PER_FILE} duplicated lines per file.\n" +
                $"Each project had a total of {NUM_DUPLICATE_FILES * NUM_LINES_PER_FILE} duplicated lines to compile.\n");
            Console.WriteLine("Note the time format of hh:mm:ss:millsec");
            Console.WriteLine($"Building {projectNameTestingNameOf} took an average time of {timeForNameOf}.");
            Console.WriteLine($"Building {projectNameTestingLiteral} took an average time of {timeForLiteral}.");
        }

        private static TimeSpan TimeBuild(string projectName, int numberOfTimesToBuild)
        {
            string projectPath = SFC.GetProjectPathFormat(projectName);
            Project projectToRecordBuildTime = new Project(projectPath);

            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < numberOfTimesToBuild; i++)
            {
                Console.WriteLine($"Building for {i + 1}th time for project {projectName}; current time: {stopwatch.Elapsed}...");
                stopwatch.Start();
                projectToRecordBuildTime.Build();
                stopwatch.Stop();
            }

            // Milliseconds are used instead of ticks because Stopwatch ticks are different than TimeSpan ticks;
            // Stopwatch ticks are hardware dependent, TimeSpan ticks are not.
            return new TimeSpan(0, 0, 0, 0, (int)stopwatch.ElapsedMilliseconds / numberOfTimesToBuild);
        }

        private static DirectoryInfo GetDirectoryInfo(string projectName)
        {
            return new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\..\..\{projectName}");
        }
    }
}
