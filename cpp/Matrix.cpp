#include "Matrix.hh"

Matrix::Matrix()
{
    InitMatrix(3); // procudes square matrix
    content[0][0] = 1;
    content[0][1] = 5;
    content[0][2] = 4;

    content[1][0] = -9;
    content[1][1] = 3;
    content[1][2] = -8;

    content[2][0] = -1;
    content[2][1] = 9;
    content[2][2] = 5;
}

Matrix::Matrix(int rows)
{
    InitMatrix(rows);
}

Matrix::Matrix(int rows, int cols)
{
    InitMatrix(rows, cols);
}

void Matrix::InitMatrix(int rows)
{
    InitMatrix(rows, rows);
}
 
void Matrix::InitMatrix(int rows, int cols)
{ 
    std::vector<std::vector<double>> v(rows, std::vector<double>(cols, 0));
    content = v;
}

int Matrix::NumberOfRows()
{

}

int Matrix::NumberOfCols()
{

}

std::string Matrix::ToString()
{
    std::string result;
    std::string row = "";
    for (int i = 0; i < NumberOfRows(); i++)
    {
        row = "";
        for (int j = 0; j < NumberOfCols(); j++)
        {
            row += "|" + std::to_string(content[i][j]);
        }
        result += row + "|\n";
    }
    return result;
}