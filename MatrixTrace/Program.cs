using System;
using System.Collections.Generic;
using static MatrixTrace.Matrix;

namespace MatrixTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = -1;
            int columns = -1;
            Random rng = new Random();
            while (rows <= 0)
            {
                Console.WriteLine("Please enter the amount of rows(number must be bigger than zero):");
                int.TryParse(Console.ReadLine(), out rows);
            }

            while (columns <= 0)
            {
                Console.WriteLine("Please enter the amount of columns(number must be bigger than zero):");
                int.TryParse(Console.ReadLine(), out columns);
            }

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rng.Next(0, 101);
                }
            }

            Queue<Tuple<int, int>> diagonalCoordinates = new Queue<Tuple<int, int>>();
            GetMatrixTrace(matrix, out diagonalCoordinates);
            Tuple<int, int> currentCoordinate = diagonalCoordinates.Dequeue();

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    if (currentCoordinate.Item1 == i && currentCoordinate.Item2 == j)
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0:###}", matrix[i, j].ToString());//conversion to string so that 0 is written
                        Console.ForegroundColor = ConsoleColor.White;
                        if (diagonalCoordinates.Count != 0)
                            currentCoordinate = diagonalCoordinates.Dequeue();
                        else
                            currentCoordinate = new Tuple<int, int>(-1, -1);//out of diagonal pieces
                    }
                    else
                    {
                        if (j != 0)
                            Console.Write("\t");//gives everything equal spacing (without a tab at the end)
                        Console.Write("{0:###}", matrix[i, j].ToString());//conversion to string so that 0 is written
                    }

                }
                Console.WriteLine();

            }

            Console.ReadKey();
        }
    }
}
