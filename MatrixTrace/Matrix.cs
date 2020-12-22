using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTrace
{
    public class Matrix
    {
        public int[,] Array { get; }
        private Queue<Tuple<int, int>> _diagonalCoordinates;
        public int MatrixTraceSum { get; }

        public Matrix(int rows, int columns)
        {
            if (rows < 0)
                throw new ArgumentOutOfRangeException(nameof(rows), "rows must be 0 or greater");
            if (columns < 0)
                throw new ArgumentOutOfRangeException(nameof(columns), "columns must be 0 or greater");

            this.Array = FillMatrix(rows, columns);

            MatrixTraceSum = GetMatrixTrace();
        }

        private int[,] FillMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = new Random().Next(0, 101);
                }
            }
            return matrix;
        }

        private int GetMatrixTrace()
        {
            int rows = 0;
            int columns = 0;
            int diagonalTraceSum = 0;
            _diagonalCoordinates = new Queue<Tuple<int, int>>();
            while (rows < Array.GetLength(0) && columns < Array.GetLength(1))
            {
                _diagonalCoordinates.Enqueue(new Tuple<int, int>(rows, columns));
                diagonalTraceSum += Array[rows, columns];
                rows++;
                columns++;
            }
            return diagonalTraceSum;
        }
        public void PrintMatrix(ConsoleColor diagonalColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;//store what the color was before
            if (_diagonalCoordinates.Count < 1)//empty matrix
                return;
            
            Queue<Tuple<int, int>> coordinateCopy = new Queue<Tuple<int, int>>(_diagonalCoordinates);
            Tuple<int, int> currentCoordinate = coordinateCopy.Dequeue();

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (currentCoordinate.Item1 == i && currentCoordinate.Item2 == j)
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)
                        Console.ForegroundColor = diagonalColor;
                        Console.Write("{0:###}", Array[i, j].ToString());//conversion to string so that 0 is written
                        Console.ForegroundColor = ConsoleColor.White;
                        if (coordinateCopy.Count != 0)
                            currentCoordinate = coordinateCopy.Dequeue();
                        else
                            currentCoordinate = new Tuple<int, int>(-1, -1);//out of diagonal pieces
                    }
                    else
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)
                        Console.Write("{0:###}", Array[i, j].ToString());//conversion to string so that 0 is written
                    }

                }
                Console.WriteLine();

            }
            Console.ForegroundColor = oldColor;//restore old color

        }
    }
}
