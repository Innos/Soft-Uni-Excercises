using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortUsingBubbleSort
{
    static void Main(string[] args)
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        BubbleSort(numbers);
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
    static void BubbleSort(int[] numbers)
    {
        bool swapped = false;

        do
        {
            swapped = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    int swap = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = swap;
                    swapped = true;
                }
            }

        } while (swapped == true);
    }
}

