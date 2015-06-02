using System;



class Dog
{
    public string Name { get; set; }
    public string Breed { get; set; }

    public Dog() : this(null,null)
    {
    }
    public Dog(string name,string breed)
    {
        this.Name = name;
        this.Breed = breed;
    }

    public void Bark()
    {
        Console.WriteLine("{0} ({1}) said: Bauuuuuuu!",
            this.Name ?? "[unnamed dog]",
            this.Breed ?? "[unknown breed]");
    }
}

