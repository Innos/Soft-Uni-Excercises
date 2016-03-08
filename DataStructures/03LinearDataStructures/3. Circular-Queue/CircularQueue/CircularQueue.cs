using System;

public class CircularQueue<T>
{
    private const int InitialCapacity = 16;

    public int Count { get; private set; }

    private T[] array;

    private int head;

    private int tail;

    public CircularQueue(int capacity = InitialCapacity)
    {
        this.array = new T[capacity];
        this.head = 0;
        this.tail = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.array.Length)
        {
            this.Resize();
        }
        this.array[this.tail] = element;
        this.tail = ++this.tail % this.array.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty!");
        }

        var value = this.array[this.head];
        this.array[this.head] = default(T);
        this.head = ++this.head % this.array.Length;
        this.Count--;
        return value;
    }

    public T[] ToArray()
    {
        var tempArray = new T[this.Count];
        this.CopyAllElements(tempArray);
        return tempArray;
    }

    private void Resize()
    {
        var newArray = new T[this.array.Length * 2];
        this.CopyAllElements(newArray);
        this.array = newArray;
        this.head = 0;
        this.tail = this.Count;

    }

    private void CopyAllElements(T[] newArray)
    {
        var start = this.head;
        var destination = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newArray[destination++] = this.array[start];
            start = ++start % this.array.Length;
        }
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
