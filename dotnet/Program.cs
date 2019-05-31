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

            if(numberOfThreads > 1)
            {
                System.Console.WriteLine("Multi");
                var dets = MatrixMultithreads.Determinants(matrixes, numberOfThreads);
            }
            else
            {
                System.Console.WriteLine("Single");
                var dets = Matrix.Determinants(matrixes);
            }

            

            // var determinants_mt = MatrixMultithreads.Determinants(matrixes, numberOfThreads);
            // var determinants = Matrix.Determinants(matrixes);

            // if(determinants.Count != determinants_mt.Count)
            // {
            //     System.Console.WriteLine("Error");
            // }

            // for (int i = 0; i < determinants.Count; i++)
            // {
            //     System.Console.WriteLine($"Det   : {determinants[i]}");
            //     System.Console.WriteLine($"Det_mt: {determinants_mt[i]}");
            // }
        }
    }
}
