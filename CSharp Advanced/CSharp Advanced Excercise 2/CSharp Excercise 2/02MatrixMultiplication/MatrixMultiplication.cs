using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatrixMultiplication
{
    static void Main(string[] args)
    {
        int[,] m1 = new int[,] { { 1, 2 }, { 2, 1 } };
        int[,] m2 = new int[,] { { 4, 5, 10 }, { 6, 5, 3 } };
        var result = MultiplyMatrix(m1, m2);
        Print2DimensionalMatrix(result);
    }
    static int[,] MultiplyMatrix(int[,] a, int[,] b)
    {
        int[,] resultMatrix = new int[a.GetLength(0), b.GetLength(1)];
        for (int aRow = 0; aRow < a.GetLength(0); aRow++)
        {
            for (int bColumn = 0; bColumn < b.GetLength(1); bColumn++)
            {
                int cellValue = 0;
                //aColumn = bRow
                for (int aColumn = 0; aColumn < a.GetLength(1); aColumn++)     
                {
                    cellValue += a[aRow, aColumn] * b[aColumn, bColumn];
                }
                resultMatrix[aRow, bColumn] = cellValue;
            }   
        }
        return resultMatrix;
    }
    static void Print2DimensionalMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }
    }
}

