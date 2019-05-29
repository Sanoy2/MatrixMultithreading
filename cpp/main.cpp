#include <iostream>
#include <vector>

#include "Matrix.hh"

using namespace std;

int main(int argc, char** argv) 
{
    std::srand(std::time(nullptr));

    int numberOfMatrixes = strtol(argv[1], NULL, 10);
    int matrixDimensions =  strtol(argv[2], NULL, 10);

    std::vector<Matrix> matrixes;
    std::vector<double> dets;

    for (int i = 0; i < numberOfMatrixes; i++)
    {
        Matrix matrix(matrixDimensions);
        matrix.Randomize();
        matrixes.push_back(matrix);
    }
    
    dets = Determinants(matrixes);    
    return 0;
}