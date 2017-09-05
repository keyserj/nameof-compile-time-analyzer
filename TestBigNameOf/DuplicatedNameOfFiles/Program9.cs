namespace DuplicatedNameOfFiles
{
    class Program9
    {
        private void Test()
        {
            string s;
            s = nameof(Program8);
            s = nameof(Program1);
            s = nameof(Program8);
            s = nameof(Program3);
            s = nameof(Program9);
            s = nameof(Program8);
            s = nameof(Program5);
            s = nameof(Program9);
            s = nameof(Program5);
            s = nameof(Program3);
        }
    }
}