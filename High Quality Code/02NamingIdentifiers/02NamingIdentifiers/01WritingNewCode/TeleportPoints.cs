namespace ProgrammingBasicsExam30August2015
{
    using System;

    public class TeleportPoints
    {
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();

            double aX = double.Parse(line[0]);
            double aY = double.Parse(line[1]);

            line = Console.ReadLine().Split();

            double bX = double.Parse(line[0]);
            double bY = double.Parse(line[1]);

            line = Console.ReadLine().Split();

            double cX = double.Parse(line[0]);
            double cY = double.Parse(line[1]);

            line = Console.ReadLine().Split();

            double dX = double.Parse(line[0]);
            double dY = double.Parse(line[1]);

            double radius = double.Parse(Console.ReadLine());
            double step = double.Parse(Console.ReadLine());

            int positions = 0;

            //right
            for (double row = 0; row <= radius; row = row + step)
            {
                //top
                for (double col = 0; col <= radius; col = col + step)
                {
                    if (row < bX && row > aX && col < cY && col > bY)
                    {
                        if ((row * row) + (col * col) <= radius * radius)
                        {
                            positions++;
                        } 
                    }
                }

                //bot
                for (double col = -step; col >= -radius; col = col - step)
                {
                    if (row < bX && row > aX && col < cY && col > bY)
                    {
                        if ((row * row) + (col * col) <= radius * radius)
                        {
                            positions++;
                        } 
                    }
                }
            }

            //left
            for (double row = -step; row >= -radius; row = row - step)
            {
                //top
                for (double col = 0; col <= radius; col = col + step)
                {
                    if (row < bX && row > aX && col < cY && col > bY)
                    {
                        if ((row * row) + (col * col) <= radius * radius)
                        {
                            positions++;
                        }
                    }
                }

                //bot
                for (double col = -step; col >= -radius; col = col - step)
                {
                    if (row < bX && row > aX && col < cY && col > bY)
                    {
                        if ((row * row) + (col * col) <= radius * radius)
                        {
                            positions++;
                        }
                    }
                }
            }

            Console.WriteLine(positions);
        }
    }
}
