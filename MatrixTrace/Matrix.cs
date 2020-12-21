using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTrace
{
    public static class Matrix
    {
        public static int GetMatrixTrace(int[,] matrix, out Queue<Tuple<int, int>> diagonalCoordinates)
        {
            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
                throw new ArgumentOutOfRangeException(nameof(matrix), "The matrix has at least one side that is smaller than 1");
            int rows = 0;
            int columns = 0;
            int diagonalTraceSum = 0;
            diagonalCoordinates = new Queue<Tuple<int, int>>();
            while (rows < matrix.GetLength(0) && columns < matrix.GetLength(1))
            { 
                diagonalCoordinates.Enqueue(new Tuple<int, int>(rows, columns));
                diagonalTraceSum += matrix[rows, columns];
                rows++;
                columns++;
            }
            return diagonalTraceSum;
        }
    }
}
