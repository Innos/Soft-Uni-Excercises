namespace _05RefactoringOthersCode
{
    using System;

    public class SumOfElements
    {
        private static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            long max = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int number = int.Parse(input[i]);
                sum = sum + number;

                if (number > max)
                {
                    max = number;
                }
            }

            long secondSum = sum - max;

            if (secondSum == max)
            {
                Console.WriteLine("Yes, sum={0}", secondSum);
            }
            else
            {
                Console.WriteLine("No, diff={0}", Math.Abs(max - secondSum));
            }
        }
    }
}