using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTrace
{
    public class Matrix
    {
        private readonly byte[,] _array;

        public int MatrixTraceSum { get; }
        public byte[,] GetArray { get { return _array; } }

        public Matrix(int rows, int columns)
        {
            if (rows < 0)
                throw new ArgumentOutOfRangeException(nameof(rows), "rows must be 0 or greater");
            if (columns < 0)
                throw new ArgumentOutOfRangeException(nameof(columns), "columns must be 0 or greater");

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
            int rows = 0;
            int columns = 0;
            int diagonalTraceSum = 0;

            while (rows < _array.GetLength(0) && columns < _array.GetLength(1))
            {
                diagonalTraceSum += _array[rows, columns];
                rows++;
                columns++;
            }
            return diagonalTraceSum;
        }
        public void PrintMatrix(ConsoleColor diagonalColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;//store what the color was before

            Console.WriteLine("The trace sum is: " + GetMatrixTraceSum());

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    if (i==j)
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)

                        Console.ForegroundColor = diagonalColor;
                        Console.Write("{0:###}", _array[i, j].ToString());//conversion to string so that 0 is written
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)

                        Console.Write("{0:###}", _array[i, j].ToString());//conversion to string so that 0 is written
                    }

                }
                Console.WriteLine();

            }
            Console.ForegroundColor = oldColor;//restore old color

        }
    }
}
