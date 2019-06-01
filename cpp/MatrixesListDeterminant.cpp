#include "MatrixesListDeterminant.hh"

std::vector<Pair> MatrixesListDeterminant::ComputeDeterminants(std::vector<Matrix> matrixes)
{
    std::vector<Pair> pairs;
    for (int i = 0; i < matrixes.size(); i++)
    {
        pairs.push_back(Pair(matrixes[i], matrixes[i].Determinant()));
    }

    return pairs;
}

std::vector<Pair> MatrixesListDeterminant::ComputeDeterminantsMultithreading
    (std::vector<Matrix> matrixes, int numberOfThreads)
{
    if(numberOfThreads == 1)
    {
        return ComputeDeterminants(matrixes);
    }

    if(numberOfThreads < 1)
    {
        throw "Number of threads lower than 1!";
    }

    
}

