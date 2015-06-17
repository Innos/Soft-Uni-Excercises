using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Predicates
{
    class Predicates
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>() { 1, 3, 5, 6, 8, 11, 3, 2 };
            Console.WriteLine(nums.FirstOrDefault(x => x > 8));
            Console.WriteLine(nums.FirstOrDefault(x => x < 0));
        }
    }
}
