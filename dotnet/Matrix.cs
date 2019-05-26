using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet
{
    public class Matrix
    {
        private static readonly int maxValue = 9;
        private static readonly int minValue = -9;

        public List<List<double>> Content { get; set; }
        public bool IsSquare { get => CheckIfIsSquare(); }
        public bool IsUnit { get => CheckIfIsUnit(); }
        public double Determinant { get => ComputeDeterminant(); }

        public int NumberOfRows { get => Content.Count; }
        public int NumberOfCols 
        { 
            get 
            {
                if(NumberOfRows == 0)
                    return 0;
                return Content[0].Count;
            }
        }

        public Matrix CreateSubmatrix(int row, int col)
        {
            var newMatrix = new Matrix(NumberOfRows - 1);

            for (int i = 0, k = 0; i < NumberOfRows; i++, k++)
            {
                if(i == row)
                    ++i;
                if(i == NumberOfRows)
                    continue;
                for (int j = 0, l = 0; j < NumberOfCols; j++, l++)
                {
                    if(j == col)
                        ++j;
                    if(j == NumberOfCols)
                        continue;
                    newMatrix.Content[k][l] = Content[i][j];
                }
            }

            return newMatrix;
        }

        private double ComputeDeterminant()
        {
            if(!IsSquare)
            {
                throw new Exception("Not a square matrix!");
            }
            if(NumberOfCols == 1)
                return Content[0][0];

            
            return 0;
        }

        private Matrix(int rows)
        {
            InitMatrix(rows, rows);
        }

        private Matrix(int rows, int cols)
        {
            InitMatrix(rows, cols);
        }

        private void InitMatrix(int rows, int cols)
        {
            Content = new List<List<double>>();
            for (int i = 0; i < rows; i++)
            {
                Content.Add(new List<double>());
            }

            foreach (var row in Content)
            {
                for (int i = 0; i < cols; i++)
                {
                    row.Add(0);
                }
            }
        }
        
        public static Matrix CreateUnitMatrix(int size)
        {
            var matrix = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                matrix.Content[i][i] = 1;
            }

            return matrix;
        }

        public static Matrix CreateRandomMatrix(int rows)
        {
            return CreateRandomMatrix(rows, rows);
        }

        public static Matrix CreateRandomMatrix(int rows, int cols)
        {
            var matrix = new Matrix(rows, cols);
            var random = new Random();

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfCols; j++)
                {
                    matrix.Content[i][j] = random.Next(minValue, maxValue) * random.NextDouble();
                }
            }

            return matrix;
        }

        private bool CheckIfIsSquare()
        {
            return NumberOfRows == NumberOfCols;
        }

        private bool CheckIfIsUnit()
        {
            if(IsSquare == false)
                return false;
            
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCols; j++)
                {
                    if(i == j)
                    {
                        if(Content[i][j] != 1)
                            return false;
                    }
                    else
                    {
                        if(Content[i][j] != 0)
                            return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var row in Content)
            {
                builder.Append("|");
                foreach (var value in row)
                {
                    builder.Append($"{String.Format("{0:0.0}", value)}|");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}