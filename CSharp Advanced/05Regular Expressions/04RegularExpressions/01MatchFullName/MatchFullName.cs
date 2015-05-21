using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class MatchFullName
{
    static void Main(string[] args)
    {
        string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
        Regex reg = new Regex(pattern);
        string text = "ivan ivanov, Ivan ivanov, ivan Ivanov,Ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan	Ivanov ";
        Match m = reg.Match(text);
        while(m.Success)
        {
            Console.WriteLine(m.Value);
            m = m.NextMatch();
        }
    }
}

