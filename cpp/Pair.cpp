#include "Pair.hh"

Pair::Pair()
{
    matrix = Matrix(0);
    detetminant = 0.0;
}

Pair::Pair(Matrix _matrix)
{
    matrix = _matrix;
    detetminant = 0.0;
}

Pair::Pair(Matrix _matrix, double det)
{
    matrix = _matrix;
    detetminant = det;
}

std::string Pair::ToString()
{
    std::string result  = matrix.ToString();
    result += "Det: ";
    result += std::to_string(detetminant);
    result += "\n";

    return result;
}