#include <iostream>
#include <vector>

#include "Matrix.hh"
#include "MatrixesListDeterminant.hh"
#include "Pair.hh"

using namespace std;

int main(int argc, char** argv) 
{
    std::srand(std::time(nullptr));

    int numberOfMatrixes = strtol(argv[1], NULL, 10);
    int matrixDimensions =  strtol(argv[2], NULL, 10);
    int numberOfThreads =  strtol(argv[3], NULL, 10);

    std::vector<Matrix> matrixes;
    std::vector<double> dets;

    for (int i = 0; i < numberOfMatrixes; i++)
    {
        Matrix matrix(matrixDimensions);
        matrix.Randomize();
        matrixes.push_back(matrix);
    }
    
    // dets = Determinants(matrixes);    

    // for (int i = 0; i < matrixes.size(); i++)
    // {
    //     std::cout << dets[i] << std::endl;
    //     std::cout << matrixes[i].ToString() << std::endl;
    // }

    // std::cout << "Now counter" << std::endl;

    MatrixesListDeterminant matrixesCounter;

    std::vector<Pair> pairs = matrixesCounter
        .ComputeDeterminantsMultithreading(matrixes, numberOfThreads);


    std::cout << "BACK IN MAIN:" << std::endl;
    for (int i = 0; i < pairs.size(); i++)
    {
        // std::cout << pairs[i].ToString() << std::endl;
        std::cout << pairs[i].detetminant << std::endl;
    }


    return 0;
}