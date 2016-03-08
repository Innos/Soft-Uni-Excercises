using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class EscapeFromLabyrinth
{
    private class Position
    {
        public Position(int row, int col, char direction, Position prev = null)
        {
            this.Row = row;
            this.Col = col;
            this.Direction = direction;
            this.Previous = prev;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Direction { get; private set; }

        public Position Previous { get; private set; }
    }

    public static void Main()
    {
        int cols = int.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        Position start = null;
        char[,] labyrinth = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                labyrinth[i, j] = line[j];
                if (line[j] == 's')
                {
                    start = new Position(i, j, 's');
                }
            }
        }
        if (start == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (start.Row == 0 || start.Row == labyrinth.GetUpperBound(0) || start.Col == 0 ||
                 start.Col == labyrinth.GetUpperBound(1))
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            var result = BFS(labyrinth, start);
            Console.WriteLine(result);
        }
    }

    private static string BFS(char[,] labyrinth, Position start)
    {
        var queue = new Queue<Position>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            labyrinth[current.Row, current.Col] = 'v';
            if (current.Row == 0 || current.Row == labyrinth.GetUpperBound(0) || current.Col == 0 ||
                current.Col == labyrinth.GetUpperBound(1))
            {
                StringBuilder sb = new StringBuilder();
                while (current.Previous != null)
                {
                    sb.Insert(0, current.Direction);
                    current = current.Previous;
                }
                return "Shortest exit: " + sb.ToString();
            }
            if (current.Row - 1 >= 0 && labyrinth[current.Row - 1, current.Col] == '-')
            {
                queue.Enqueue(new Position(current.Row - 1, current.Col, 'U', current));
            }
            if (current.Row + 1 < labyrinth.GetLength(0) && labyrinth[current.Row + 1, current.Col] == '-')
            {
                queue.Enqueue(new Position(current.Row + 1, current.Col, 'D', current));
            }
            if (current.Col - 1 >= 0 && labyrinth[current.Row, current.Col - 1] == '-')
            {
                queue.Enqueue(new Position(current.Row, current.Col - 1, 'L', current));
            }
            if (current.Col + 1 < labyrinth.GetLength(1) && labyrinth[current.Row, current.Col + 1] == '-')
            {
                queue.Enqueue(new Position(current.Row, current.Col + 1, 'R', current));
            }
        }

        return "No exit!";
    }
}
