#ifndef MATRIXES_LIST_DETERMIMANT_HH
#define MATRIXES_LIST_DETERMIMANT_HH

#include <thread>
#include <vector>
    #include <iostream>
#include "Pair.hh"

void SayHello();

class MatrixesListDeterminant
{
    public:
        std::vector<Pair> ComputeDeterminants(std::vector<Matrix>);
        std::vector<Pair> ComputeDeterminantsMultithreading(std::vector<Matrix>, int);
};

std::vector<std::vector<Pair>> CreatePairs(std::vector<Matrix> matrixes, int parts);
std::vector<Pair> MergePairs(std::vector<std::vector<Pair>> pairsLists);
#endif