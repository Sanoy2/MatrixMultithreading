#include <iostream>
#include "Matrix.hh"

using namespace std;

int main(int argc, char** argv) 
{
    std::srand(std::time(nullptr));
    std::cout << "start" << std::endl;

    Matrix matrix;
    cout << "Rows: " << matrix.NumberOfRows() << endl;  
    cout << "Cols: " << matrix.NumberOfCols() << endl;
    cout << "Det : " << matrix.Determinant() << endl;
    cout << matrix.ToString() << endl;

    Matrix submatrix = matrix.CreateSubmatrix(0,0);
    cout << "Rows: " << submatrix.NumberOfRows() << endl;  
    cout << "Cols: " << submatrix.NumberOfCols() << endl;
    cout << "Det : " << submatrix.Determinant() << endl;
    cout << submatrix.ToString() << endl;

    std::cout << "finish" << std::endl;
    return 0;
}