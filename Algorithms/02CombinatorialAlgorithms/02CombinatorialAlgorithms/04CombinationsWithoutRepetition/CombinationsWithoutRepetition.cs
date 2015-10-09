namespace _04CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
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
            used = new bool[iterations+1];
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
                    if (!used[i])
                    {
                        used[i] = true;
                        result[currentLoop] = i + 1;
                        RecursiveLoop(currentLoop + 1, i);
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
