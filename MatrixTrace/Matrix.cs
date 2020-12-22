using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTrace
{
    public class Matrix
    {
        private readonly byte[,] _array;
        private readonly int _rows, _columns;

        public int MatrixTraceSum { get; }
        public byte[,] GetArray { get { return _array; } }

        public Matrix(int rows, int columns)
        {
            if (rows < 0)
                throw new ArgumentOutOfRangeException(nameof(rows), "rows must be 0 or greater");
            if (columns < 0)
                throw new ArgumentOutOfRangeException(nameof(columns), "columns must be 0 or greater");

            _rows = rows;
            _columns = columns;
            _array = FillMatrix(rows, columns);
            MatrixTraceSum = GetMatrixTraceSum();
        }

        private byte[,] FillMatrix(int rows, int columns)
        {
            byte[,] matrix = new byte[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = (byte)new Random().Next(0, 101);
                }
            }

            return matrix;
        }

        private int GetMatrixTraceSum()
        {
            int diagonalTraceSum = 0;

            for (int i = 0; i < Math.Min(_rows, _columns); i++)
            {
                diagonalTraceSum += _array[i, i];
            }

            return diagonalTraceSum;
        }

        public void PrintMatrix(ConsoleColor diagonalColor)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = diagonalColor;
                        Console.Write("{0:###}\t", _array[i, j].ToString());//conversion to string so that 0 is written
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("{0:###}\t", _array[i, j].ToString());//conversion to string so that 0 is written
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
