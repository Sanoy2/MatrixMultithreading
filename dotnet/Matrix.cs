using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet
{
    public class Matrix
    {
        private static readonly int maxValue = 10000;
        private static readonly int minValue = -10000;

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

        public static Matrix CreateSampleMatrix()
        {
            var matrix = new Matrix(3, 4);
            matrix.Content[0][0] = 1;
            matrix.Content[0][1] = 5;
            matrix.Content[0][2] = 4;

            matrix.Content[0][3] = 19;

            matrix.Content[1][0] = -9;
            matrix.Content[1][1] = 3;
            matrix.Content[1][2] = -8;

            matrix.Content[1][3] = -99;

            matrix.Content[2][0] = -1;
            matrix.Content[2][1] = 9;
            matrix.Content[2][2] = 5;

            matrix.Content[2][3] = 999;

            return matrix;
        }

        public Matrix Transpose()
        {
            var matrix = new Matrix(this.NumberOfCols, this.NumberOfRows);

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCols; j++)
                {
                    matrix.Content[j][i] = Content[i][j];
                }
            }

            return matrix;
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

        public static List<double> Determinants(IEnumerable<Matrix> matrixes)
        {
            List<double> determinants = new List<double>();
            foreach (var matrix in matrixes)
            {
                determinants.Add(matrix.Determinant);
            }
            return determinants;
        }

        private double ComputeDeterminant()
        {
            if(!IsSquare)
            {
                throw new Exception("Not a square matrix!");
            }

            if(NumberOfCols == 1)
            {
                return Content[0][0];
            }

            int row = 0;
            double det = 0;
            for (int col = 0; col < NumberOfCols; col++)
            {
                var minor = this.CreateSubmatrix(row, col);
                var minorDet = minor.Determinant;

                det += Math.Pow(-1, row + col) * Content[row][col] * minorDet;
            }
            
            return det;
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

        public static Matrix operator +(Matrix matrix, int number)
        {
            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfCols; j++)
                {
                    matrix.Content[i][j] += number;
                }
            }
            return matrix;
        }

        public static Matrix operator -(Matrix matrix, int number)
        {
            return matrix + (-number);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var row in Content)
            {
                builder.Append("|");
                foreach (var value in row)
                {
                    builder.Append($"{String.Format(" {0: 000.00;-000.00}", value)} |");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}