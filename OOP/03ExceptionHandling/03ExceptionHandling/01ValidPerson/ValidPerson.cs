using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ValidPerson
{
    class ValidPerson
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 24);

            try
            {
                //Person noname = new Person(String.Empty, "Goshev", 31);
                //Person noLastName = new Person("Ivan", null, 63);
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
                Person tooOldForThisProgram = new Person("Iskren", "Ivanov", 121);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}",ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
