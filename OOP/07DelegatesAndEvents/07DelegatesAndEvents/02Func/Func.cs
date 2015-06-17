using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Func
{
    class Func
    {
        static void Main(string[] args)
        {
            var nums = new List<int>(){1,2,3,5,7,9,10,11};
            var a = nums.TakeWhile(x => x < 10);
            Console.WriteLine(string.Join(", ",a));
        }
    }
}
