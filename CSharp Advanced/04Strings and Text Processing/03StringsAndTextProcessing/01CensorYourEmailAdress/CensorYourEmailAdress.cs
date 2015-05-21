using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CensorYourEmailAdress
{
    static void Main(string[] args)
    {
        string email = "pesho.peshev@email.bg";
        string text = "My name is Pesho Peshev. I am from Sofia, my email is: pesho.peshev@email.bg (not pesho.peshev@email.com). Test: pesho.meshev@email.bg, pesho.peshev@email.bg";
        string username = email.Substring(0, email.IndexOf('@'));
        string domain = email.Substring(email.IndexOf('@'));
        string replace = new string('*', username.Length) + domain;
        text = text.Replace(email, replace);
        Console.WriteLine(text);
    }
}

