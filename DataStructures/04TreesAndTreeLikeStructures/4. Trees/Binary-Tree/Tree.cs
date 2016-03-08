using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; private set; }

    public List<Tree<T>> Children { get; private set; }  

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        var stringIndent = new string(' ', indent);
        Console.WriteLine(stringIndent + this.Value);
        foreach (var child in this.Children)
        {
            child.Print(indent+2);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }
}
