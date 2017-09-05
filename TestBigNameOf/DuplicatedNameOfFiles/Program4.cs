namespace DuplicatedNameOfFiles
{
    class Program4
    {
        private void Test()
        {
            string s;
            s = nameof(Program2);
            s = nameof(Program1);
            s = nameof(Program1);
            s = nameof(Program0);
            s = nameof(Program3);
            s = nameof(Program0);
            s = nameof(Program0);
            s = nameof(Program3);
            s = nameof(Program2);
            s = nameof(Program4);
        }
    }
}