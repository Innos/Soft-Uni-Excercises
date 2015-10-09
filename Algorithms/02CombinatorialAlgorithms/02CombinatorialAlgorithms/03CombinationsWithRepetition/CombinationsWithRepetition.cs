namespace _03CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        private static int[] result;

        private static int iterations;

        private static int loops;

        public static void Main(string[] args)
        {
            iterations = int.Parse(Console.ReadLine());
            loops = int.Parse(Console.ReadLine());
            result = new int[loops];
            RecursiveLoop(0, 0);
        }

        private static void RecursiveLoop(int currentLoop, int start)
        {
            if (currentLoop == loops)
            {
                Print();
            }
            else
            {
                for (int i = start; i < iterations; i++)
                {
                    result[currentLoop] = i + 1;
                    RecursiveLoop(currentLoop + 1, i);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
