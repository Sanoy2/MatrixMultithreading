using System;
using System.Collections.Generic;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixesNumber = Int32.Parse(args[0]);
            int matrixesDimension = Int32.Parse(args[1]);

            List<Matrix> matrixes = new List<Matrix>();

            for (int i = 0; i < matrixesNumber; i++)
            {
                matrixes.Add(Matrix.CreateRandomMatrix(matrixesDimension));
            }

            var determinants = Matrix.Determinants(matrixes);
        }
    }
}
