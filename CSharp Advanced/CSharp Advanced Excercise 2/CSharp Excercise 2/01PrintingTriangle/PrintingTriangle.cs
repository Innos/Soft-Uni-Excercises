using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintingTriangle
{
    static void Main(string[] args)
    {
        Console.Write("Input size of triangle: ");
        int size = int.Parse(Console.ReadLine());
        PrintTop(size);


    }
    static void PrintTop(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            var a = Enumerable.Range(1, i);
            Console.WriteLine(String.Join("", a));
        }
        PrintBot(n);
    }
    static void PrintBot(int n)
    {
        for (int i = n - 1; i > 0; i--)
        {
            var a = Enumerable.Range(1, i);
            Console.WriteLine(String.Join("", a));
        }
    }
}

