using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static MatrixTrace.Matrix;

namespace MatrixTraceTests
{
    [TestClass]
    public class MatrixTests
    {

        [TestMethod]
        public void MatrixTrace_Diagonal_Number_Sum()
        {
            Queue<Tuple<int, int>> diagonalCoordinates;
            int[,] input = new int[3, 5]
            {
                {1,2,3,4,5 },
                {6,7,8,9,10 },
                {11,12,13,14,15 } };
            int expectedOutput = 21;
            int actualOutput = GetMatrixTrace(input, out diagonalCoordinates);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The matrix has at least one side that is smaller than 1")]
        public void MatrixTrace_Empty_matrix()
        {
            Queue<Tuple<int, int>> diagonalCoordinates;
            int[,] input = new int[0, 0];
            GetMatrixTrace(input, out diagonalCoordinates);
        }

    }
}
