namespace Fuck
{
    internal class CodeFile1
    {
        private static TestStruct testStruct = new TestStruct(10,20);
        static void Main()
        {
            Console.WriteLine(testStruct.A);
            Console.WriteLine(testStruct.B);

        }
        
    }
    /// <summary>
    /// This is a Test Struct
    /// </summary>
    /// <example> </example>
    public readonly struct TestStruct
    {
        public readonly byte A;
        public readonly byte B;

        public TestStruct(byte _a, byte _b)
        {
            A = _a;
            B = _b;
        }
    }

}