namespace DuplicatedNameOfFiles
{
    class Program2
    {
        private void Test()
        {
            string s;
            s = nameof(Program0);
            s = nameof(Program1);
            s = nameof(Program0);
            s = nameof(Program2);
            s = nameof(Program1);
            s = nameof(Program0);
            s = nameof(Program0);
            s = nameof(Program0);
            s = nameof(Program0);
            s = nameof(Program2);
        }
    }
}