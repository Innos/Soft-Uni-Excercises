using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DefineAClassDog
{
    static void Main(string[] args)
    {
        Dog sharo = new Dog("sharo", "melez");
        Dog unnamed = new Dog();
        Dog roger = new Dog("Roger", "Golden Retriever");

        unnamed.Breed = "German Shepherd";

        sharo.Bark();
        unnamed.Bark();
        roger.Bark();
    }
}

