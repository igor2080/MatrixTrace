using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    class Program
    {
        static void GetUserNumberInput(string text, out int result)
        {
            result = -1;
            while (result <= 0)
            {
                Console.Write(text+" ");
                int.TryParse(Console.ReadLine(), out result);
            }
        }
        static void Main()
        {
            GetUserNumberInput("Please enter the amount of rows(number must be bigger than zero):", out int rows);
            GetUserNumberInput("Please enter the amount of columns(number must be bigger than zero):", out int columns);
            Matrix matrix = new Matrix(rows, columns);

            matrix.PrintMatrix(ConsoleColor.Red);
           
            Console.ReadKey();
        }
    }
}
