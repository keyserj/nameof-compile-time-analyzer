namespace DuplicatedNameOfFiles
{
    class Program6
    {
        private void Test()
        {
            string s;
            s = nameof(Program6);
            s = nameof(Program4);
            s = nameof(Program4);
            s = nameof(Program6);
            s = nameof(Program6);
            s = nameof(Program4);
            s = nameof(Program2);
            s = nameof(Program2);
            s = nameof(Program6);
            s = nameof(Program6);
        }
    }
}