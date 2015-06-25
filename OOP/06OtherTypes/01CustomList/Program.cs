using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomGenericList<int> newList = new CustomGenericList<int>();
            newList.Add(10);
            newList.Add(15);
            newList.Add(8);
            newList.Add(250);
            newList.Remove(250);
            newList.Remove(10);
            newList.Add(157);
            Console.WriteLine(newList.Min());
            Console.WriteLine(newList.Max());
            Console.WriteLine(newList);

            CustomGenericList<string> newList2 = new CustomGenericList<string>();
            newList2.Add("blarg");
            newList2.Add("slgew");
            newList2.Add("bsdg");
            newList2.Add("apple");
            newList2.Remove("apple");
            //newList2.Remove("banana");
            newList2.Add("pear");
            Console.WriteLine(newList2.Min());
            Console.WriteLine(newList2.Max());
            Console.WriteLine(newList2);
        }
    }
}
