using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            int size = 10;
            var matrix = Matrix.CreateRandomMatrix(size);
            matrix = Matrix.CreateSampleMatrix();

            System.Console.WriteLine("Matrix:");
            System.Console.WriteLine(matrix.ToString());

            matrix = matrix + 5;

            System.Console.WriteLine("Added 5:");
            System.Console.WriteLine(matrix.ToString());

            matrix = matrix - 10;

            System.Console.WriteLine("Substracted 10:");
            System.Console.WriteLine(matrix.ToString());

            System.Console.WriteLine($"Is square? {matrix.IsSquare}");
            System.Console.WriteLine($"Is unit? {matrix.IsUnit}");

            if(matrix.IsSquare)
            {
                System.Console.WriteLine($"Det: {matrix.Determinant}");
            }
        
            Console.WriteLine("Finish");
        }
    }
}
