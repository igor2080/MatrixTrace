using MatrixTrace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace MatrixTraceTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixTrace_Diagonal_Number_Sum()
        {
            Matrix input = new Matrix(3, 5);
            int expectedOutput = input.GetArray[0, 0] + input.GetArray[1, 1] + input.GetArray[2, 2];
            int actualOutput = input.MatrixTraceSum;
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void MatrixTrace_Sum_Empty_Matrix()
        {
            Matrix input = new Matrix(0, 0);
            int expectedOutput = 0;
            int actualOutput = input.MatrixTraceSum;
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "columns must be 0 or greater")]
        public void Matrix_Invalid_Columns()
        {
            Matrix input = new Matrix(35, -15);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "rows must be 0 or greater")]
        public void Matrix_Invalid_Rows()
        {
            Matrix input = new Matrix(-5, 15);

        }

        [TestMethod]
        public void GetUserNumberInput_Invalid_Input()
        {
            Program input = new Program();
            Console.SetIn(new StringReader("asdf"));
            int actualResult=input.GetUserNumberInput("test");
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetUserNumberInput_Valid_Input()
        {
            Program input = new Program();
            Console.SetIn(new StringReader("15"));
            int actualResult = input.GetUserNumberInput("test");
            int expectedResult = 15;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void PromptTryAgain_Continues()
        {
            Program input = new Program();
            Console.SetIn(new StringReader("1"));
            bool actualResult = input.PromptTryAgain();
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void PromptTryAgain_Exits()
        {
            Program input = new Program();
            Console.SetIn(new StringReader("e"));
            bool actualResult = input.PromptTryAgain();
            Assert.IsFalse(actualResult);
        }

    }
}
