using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            int size = 3;
            var matrix = Matrix.CreateRandomMatrix(size);
            System.Console.WriteLine(matrix.ToString());
            System.Console.WriteLine($"Is square? {matrix.IsSquare}");
            System.Console.WriteLine($"Is unit? {matrix.IsUnit}");

            if(matrix.IsSquare)
            {
                System.Console.WriteLine($"Det: {matrix.Determinant}");
            }

            System.Console.WriteLine(matrix.CreateSubmatrix(2,2).ToString());
        
            Console.WriteLine("Finish");
        }
    }
}
