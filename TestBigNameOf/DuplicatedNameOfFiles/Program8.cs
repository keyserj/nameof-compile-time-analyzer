namespace DuplicatedNameOfFiles
{
    class Program8
    {
        private void Test()
        {
            string s;
            s = nameof(Program8);
            s = nameof(Program7);
            s = nameof(Program2);
            s = nameof(Program8);
            s = nameof(Program0);
            s = nameof(Program2);
            s = nameof(Program7);
            s = nameof(Program6);
            s = nameof(Program5);
            s = nameof(Program8);
        }
    }
}