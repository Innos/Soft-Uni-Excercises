using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace _01ExtendTheStingbuilderClass
{
    class ExtendTheStringbuilderClass
    {
        static void Main(string[] args)
        {
            StringBuilder a = new StringBuilder();
            a.Append("abcd");
            string n = a.Substring(2, 2);
            Console.WriteLine(n);
        }
    }
}
