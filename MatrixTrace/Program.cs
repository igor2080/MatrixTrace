using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    public class Program
    {
        const string ContinueKey = "1";
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
            Console.Clear();
            int rows, columns;
            rows = GetUserNumberInput("Please enter the amount of rows(number must be bigger than zero): ");
            columns = GetUserNumberInput("Please enter the amount of columns(number must be bigger than zero): ");
            Matrix matrix = new Matrix(rows, columns);
            Console.WriteLine("The trace sum is: " + matrix.MatrixTraceSum);
            matrix.PrintMatrix(ConsoleColor.Red);
        }
        public bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new matrix? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        static void Main()
        {
            Program program = new Program();
            do
            {
                program.Start();
            }
            while (program.PromptTryAgain());
            Console.ReadKey();
        }
    }
}
