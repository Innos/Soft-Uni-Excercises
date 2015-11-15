namespace Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class Blocks
    {
        private const int SIZE = 4;

        private static int limit;

        private static int[] numbers;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int permutablePart = SIZE - 1;

            // the amount of sequences multiplied by the amount of variations of permutable elements from n (formila: n!/(n-p)!) divided by the amount of numbers in a sequence
            //permutable elements = SIZE - 1 because the first element of a subsequence will not change
            int combinations = (n - permutablePart) * CalculateVariationNumbers(n, permutablePart) / SIZE;
            Console.WriteLine("Number of blocks: {0}", combinations);

            numbers = new int[SIZE];
            limit = 'A' + n;

            // simple solution for this particular case, but definately not scalable
            //ForCyclesSolution(n);

            // optimal solution for all potential versions of this task (find all unique subsequences of P elements from a consecutive sequence of N elements)
            // all result that can be reached by rotating a subsequence are considered duplicates(non-unique) (ex. ABCD <=> DABC <=> CDAB <=> BCDA)
            FindCombinations(0, 'A');
        }

        private static void ForCyclesSolution(int n)
        {
            int lastLetter = 'A' + n;
            for (int i = 'A'; i < lastLetter; i++)
            {
                for (int j = i + 1; j < lastLetter; j++)
                {
                    for (int k = i + 1; k < lastLetter; k++)
                    {
                        if (k != j)
                        {
                            for (int l = i + 1; l < lastLetter; l++)
                            {
                                if (l != j && l != k)
                                {
                                    Console.WriteLine("{0}{1}{2}{3}", (char)i, (char)j, (char)k, (char)l);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void FindCombinations(int currentPosition, int current)
        {
            if (currentPosition == SIZE)
            {
                PermuteInLexicographicalOrder();
                return;
            }

            if (current + (SIZE - currentPosition - 1) < limit)
            {
                for (int i = current; i < limit; i++)
                {
                    numbers[currentPosition] = i;
                    FindCombinations(currentPosition + 1, i + 1);
                }
            }
        }


        // IMPORTANT Lexicographical order works only with sorted collections
        private static void PermuteInLexicographicalOrder()
        {
            int[] array = numbers.Clone() as int[];
            while (true)
            {
                PrintBlocks(array);
                int i = array.Length - 2;
                while (i > 0 && array[i] >= array[i + 1])
                {
                    i--;
                }

                if (i == 0)
                {
                    break;
                }

                int k = array.Length - 1;
                while (k > i && array[i] >= array[k])
                {
                    k--;
                }

                Swap(ref array[i], ref array[k]);

                ReverseArrayInPlace(array, i + 1, array.Length - 1);
            }
        }

        private static void ReverseArrayInPlace<T>(T[] array, int start, int end)
        {
            while (start < end)
            {
                T temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static void PrintBlocks(int[] results)
        {
            for (int i = 0; i < SIZE; i++)
            {
                Console.Write("{0}", (char)results[i]);
            }
            Console.WriteLine();
        }

        private static int CalculateVariationNumbers(int totalNumbers, int requiredNumbers)
        {
            int sum = 1;
            for (int i = totalNumbers; i > (totalNumbers - requiredNumbers); i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}