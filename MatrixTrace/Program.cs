using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    public class Program
    {
        public int GetUserNumberInput(string text)
        {
            Console.Write(text + " ");

            if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
            {
                return result;
            }

            Console.WriteLine("You have entered invalid input, please try again or press ctrl+c to exit");
            return GetUserNumberInput(text);
        }

        public void Start()
        {
            int rows, columns;
            do
            {
                rows = GetUserNumberInput("Please enter the amount of rows(number must be bigger than zero): ");
                columns = GetUserNumberInput("Please enter the amount of columns(number must be bigger than zero): ");

            } while (rows < 1 || columns < 1);

            Matrix matrix = new Matrix(rows, columns);
            Console.WriteLine("The trace sum is: " + matrix.MatrixTraceSum);
            matrix.PrintMatrix(ConsoleColor.Red);
        }

        static void Main()
        {
            Program program = new Program();
            program.Start();
            Console.ReadKey();
        }
    }
}
