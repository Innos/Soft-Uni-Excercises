using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class MatchPhoneNumber
{
    static void Main(string[] args)
    {
        string pattern = @"(?<= |^)\+359( |-)2(\1)\d{3}(\1)\d{4}\b";
        Regex reg = new Regex(pattern);
        string text = "+359-2-222-2222 359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359 2 222 2222 ";
        MatchCollection phones = reg.Matches(text);
        foreach (var phone in phones)
        {
            Console.WriteLine(phone);
        }
    }
}

