using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Action
{
    class Action
    {
        static void Main(string[] args)
        {
            var nums = new List<int>(){1,2,3,6,7,10,12};
            nums.ForEach(Console.WriteLine);
        }
    }
}
