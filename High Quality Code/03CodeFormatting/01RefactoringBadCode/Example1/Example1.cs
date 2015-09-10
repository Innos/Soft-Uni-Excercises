namespace _01RefactoringBadCode
{
    using System;

    public class Example1
    {
        public static void Main(string[] args)
        {
        }

        public static void Brute(long length)
        {
            int number = 68491;
            Console.WriteLine("w8. Bruteforce working...");
            for (int i = 0; i < length; i++)
            {
                int currentIndex = i;
                int bug = number;
                string brute = Convert.ToString(bug.Equals(currentIndex));
                if (brute == "True")
                {
                    Console.WriteLine(currentIndex.ToString());
                    break;
                }
            }
            bool ok = false;

            if (ok == false)
            {
                Console.WriteLine("Brete Failed:(");
            }
        }
    }
}
