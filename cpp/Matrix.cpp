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

Matrix Matrix::CreateSubmatrix(int row, int col)
{
    Matrix newMatrix(NumberOfRows() - 1, NumberOfCols() - 1);

    for (int i = 0, k = 0; i < NumberOfRows(); i++, k++)
    {
        if(i == row)
            ++i;
        if(i == NumberOfRows())
            continue;
        for (int j = 0, l = 0; j < NumberOfCols(); j++, l++)
        {
            if(j == col)
                ++j;
            if(j == NumberOfCols())
                continue;
            newMatrix.content[k][l] = content[i][j];
        }
    }

    return newMatrix;
}

double Matrix::Determinant()
{
    if(!IsSquare())
    {
        throw "Not a square matrix!";
    }

    if(NumberOfCols() == 1)
    {
        return content[0][0];
    }

    int row = 0;
    double det = 0;
    for (int col = 0; col < NumberOfCols(); col++)
    {
        Matrix minor = CreateSubmatrix(row, col);
        double minorDet = minor.Determinant();
        det += pow(-1, row + col) * content[row][col] * minorDet;
    }
    
    return det;
}

int Matrix::NumberOfRows()
{
    return content.size();
}

int Matrix::NumberOfCols()
{
    if(NumberOfRows() == 0)
    {
        return 0;
    }
    return content[0].size();
}

bool Matrix::IsSquare()
{
    return NumberOfRows() == NumberOfCols();
}

void Matrix::Randomize()
{
    for (int i = 0; i < NumberOfRows(); i++)
    {
        for (int j = 0; j < NumberOfCols(); j++)
        {
            content[i][j] = GetRandomNumber();
        }
    }
}

double Matrix::GetRandomNumber()
{
    double f = (double)rand() / RAND_MAX;
    return min_value + f * (max_value - min_value);
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

std::vector<double> Determinants(std::vector<Matrix> matrixes)
{
    std::vector<double> determinants;

    for (int i = 0; i < matrixes.size(); i++)
    {
        determinants.push_back(matrixes[i].Determinant());
    }

    return determinants;
}