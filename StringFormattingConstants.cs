using System.IO;

namespace TestBigProject
{
    public class StringFormattingConstants
    {
        public static string GetProjectPathFormat(string projectName) => $@"{Directory.GetCurrentDirectory()}\..\..\{projectName}\{projectName}.csproj";
        
        public const string DOUBLE_QUOTE = "\"";
        public const string END_LINE = "\r\n";
    }
}
