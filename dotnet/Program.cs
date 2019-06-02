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
            int numberOfThreads = Int32.Parse(args[2]);

            List<Matrix> matrixes = new List<Matrix>();

            for (int i = 0; i < matrixesNumber; i++)
            {
                matrixes.Add(Matrix.CreateRandomMatrix(matrixesDimension));
            }

            var pairs = MatrixesListDeterminant.Determinants(matrixes, numberOfThreads);
            
            foreach (var pair in pairs)
            {
                System.Console.WriteLine(pair.ToString());
            }
        }
    }
}
