using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


class JoinLists
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        List<int> list1 = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (!list1.Contains(input[i]))
            {
                list1.Add(input[i]);
            }
        }
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int i = 0; i < input.Length; i++)
        {
            if (!list1.Contains(input[i]))
            {
                list1.Add(input[i]);
            }
        }
        list1.Sort();
        list1.ForEach(i => Console.Write(i + " "));
    }
}

