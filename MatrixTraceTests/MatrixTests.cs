using MatrixTrace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MatrixTraceTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixTrace_Diagonal_Number_Sum()
        {
            Matrix input = new Matrix(3, 5);
            int expectedOutput = input.Array[0,0]+input.Array[1,1]+input.Array[2,2];
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

    }
}
