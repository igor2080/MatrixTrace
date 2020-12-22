using System;
using System.Collections.Generic;

namespace MatrixTrace
{
    public class Program
    {
        public bool GetUserNumberInput(string text, out int result)
        {
            Console.Write(text + " ");
            return int.TryParse(Console.ReadLine(), out result);            
        }
        public bool PromptTryAgain()
        {
            Console.WriteLine("You have entered invalid input, press 1 to try again, or any other key to exit");
            string input = Console.ReadLine();
            if (input == "1")
                return true;
            else return false;
        }
        static void Main()
        {
            Program program = new Program();
            int rows, columns;

            do
            {
                program.GetUserNumberInput("Please enter the amount of rows(number must be bigger than zero): ", out rows);
                program.GetUserNumberInput("Please enter the amount of columns(number must be bigger than zero): ", out columns);

                if (rows < 1 || columns < 1)
                {
                    if (!program.PromptTryAgain())
                        Environment.Exit(0);
                    else continue;
                }

            } while (rows < 1 && columns < 1);

            Matrix matrix = new Matrix(rows, columns);

            matrix.PrintMatrix(ConsoleColor.Red);

            Console.ReadKey();
        }
    }
}
