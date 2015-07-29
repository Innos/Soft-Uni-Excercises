namespace _16Debugging
{
    using System;

    public class DebuggingTests
    {
        public static void Main()
        {
            int num = 0;
            for (;;)
            {
                Console.WriteLine(num++);
            }
        }
    }
}
