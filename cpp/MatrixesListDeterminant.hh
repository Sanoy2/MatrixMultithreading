#ifndef MATRIXES_LIST_DETERMIMANT_HH
#define MATRIXES_LIST_DETERMIMANT_HH

#include "Pair.hh"
#include <vector>

class MatrixesListDeterminant
{
    public:
        std::vector<Pair> ComputeDeterminants(std::vector<Matrix>);
        std::vector<Pair> ComputeDeterminantsMultithreading(std::vector<Matrix>, int);
};

#endif