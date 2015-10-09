namespace _02VariationsWithoutRepetition
{
    using System;

    public class VariationsWithoutRepetition
    {
        private static int[] result;

        private static int iterations;

        private static int loops;

        private static bool[] used;

        public static void Main(string[] args)
        {
            iterations = int.Parse(Console.ReadLine());
            loops = int.Parse(Console.ReadLine());
            result = new int[loops];
            used = new bool[loops + 1];
            RecursiveLoop(0);
        }

        private static void RecursiveLoop(int currentLoop)
        {
            if (currentLoop == loops)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < iterations; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[currentLoop] = i + 1;
                        RecursiveLoop(currentLoop + 1);
                        used[i] = false;
                    }
                    
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
