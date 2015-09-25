namespace _01Recursion
{
    using System;
    using System.Diagnostics;

    public class EightQueens
    {
        private const int Size = 8;

        private const int UpperBound = Size - 1;

        private static readonly bool[] AttackedLeftDiagonals = new bool[(Size * 2) - 1];

        private static readonly bool[] AttackedRightDiagonals = new bool[(Size * 2) - 1];

        private static readonly bool[] AttackedCols = new bool[Size];

        private static readonly int[] Queens = new int[Size];

        private static int solutuons = 1;

        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            PlaceQueen(0);
            Console.WriteLine(sw.Elapsed);
        }

        private static void PlaceQueen(int row)
        {
            if (row == Size)
            {
                Print();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    //Queens[row] = col;
                    //if (IsPlacable(row))
                    //{
                    //    PlaceQueen(row + 1);
                    //}
                    if (CanPlaceQueen(row, col))
                    {
                        SetPositions(row, col);
                        PlaceQueen(row + 1);
                        UnmarkPositins(row, col);
                    }
                }
            }
        }

        // This check is suboptimal, takes around 4 times more time
        private static bool IsPlacable(int row)
        {
            for (int i = 0; i < row; i++)
            {
                if (Queens[i] == Queens[row])
                {
                    return false;
                }

                if (Queens[i] - Queens[row] == row - i)
                {
                    return false;
                }

                if (Queens[row] - Queens[i] == row - i)
                {
                    return false;
                }
            }

            return true;
        }

        private static void UnmarkPositins(int row, int col)
        {
            AttackedCols[col] = false;
            AttackedLeftDiagonals[col - row + UpperBound] = false;
            AttackedRightDiagonals[col + row] = false;
            Queens[row] = -1;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (AttackedCols[col] ||
                AttackedLeftDiagonals[col - row + UpperBound] ||
                AttackedRightDiagonals[col + row])
            {
                return false;
            }

            return true;
        }

        private static void SetPositions(int row, int col)
        {
            AttackedCols[col] = true;
            AttackedLeftDiagonals[col - row + UpperBound] = true;
            AttackedRightDiagonals[col + row] = true;
            Queens[row] = col;
        }

        private static void Print()
        {
            //Console.WriteLine(solutuons);
            Console.WriteLine("Solution #{0}", solutuons++);

            // Column indexes
            Console.Write(" ");
            for (int i = 0; i < Size; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            for (int i = 0; i < Size; i++)
            {
                // Row indexes
                Console.Write("{0} ", i);

                for (int j = 0; j < Size; j++)
                {
                    Console.Write("{0} ", Queens[i] == j ? "Q" : "*");
                }

                Console.WriteLine();
            }
        }
    }
}
