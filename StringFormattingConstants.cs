using System.IO;

namespace TestBigProject
{
    public class StringFormattingConstants
    {
        public static string GetProjectPathFormat(string projectName) => $@"{Directory.GetCurrentDirectory()}\..\..\{projectName}\{projectName}.csproj";

        /// <summary>
        /// Format to use for creating the duplicate directory path 
        /// Parameter: (project name, duplicate directory name)
        /// </summary>
        public static readonly string DUPLICATE_DIRECTORY_PATH_FORMAT = $@"{Directory.GetCurrentDirectory()}\..\..\{{0}}\{{1}}\";
        
        public const string DOUBLE_QUOTE = "\"";
        public const string END_LINE = "\r\n";
    }
}
