using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BookShop
{
    static void Main(string[] args)
    {
        Book a = new Book("Something", "dude", 100.50m);
        GoldenEditionBook b = new GoldenEditionBook("Something", "dude", 100.50m);
        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());
    }
}

