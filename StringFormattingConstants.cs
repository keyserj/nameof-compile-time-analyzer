using System.IO;

namespace TestBigProject
{
    public class StringFormattingConstants
    {
        /// <summary>
        /// Format to use for creating the project path 
        /// Parameter: (project name)
        /// </summary>
        public static readonly string PROJECT_PATH_FORMAT = $@"{Directory.GetCurrentDirectory()}\..\..\{{0}}\{{0}}.csproj";

        /// <summary>
        /// Format to use for creating the duplicate directory path 
        /// Parameter: (project name, duplicate directory name)
        /// </summary>
        public static readonly string DUPLICATE_DIRECTORY_PATH_FORMAT = $@"{Directory.GetCurrentDirectory()}\..\..\{{0}}\{{1}}\";
        
        public const string TABS_FOR_FILE_BODY_LINES = "            ";
        public const string TABS_FOR_CSPROJ_LINES = "    ";
        public const string DOUBLE_QUOTE = "\"";
        public const string END_LINE = "\r\n";
    }
}
