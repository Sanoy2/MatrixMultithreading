#include "MatrixesListDeterminant.hh"

std::vector<Pair> MatrixesListDeterminant::ComputeDeterminants(std::vector<Matrix> matrixes)
{
    return ComputeDeterminantsMultithreading(matrixes, 1);
}

std::vector<Pair> MatrixesListDeterminant::ComputeDeterminantsMultithreading
    (std::vector<Matrix> matrixes, int numberOfThreads)
{
    if(numberOfThreads < 1)
    {
        throw "Number of threads lower than 1!";
    }

    // std::cout << "SMALL LISTS:" << std::endl;
    std::vector<std::vector<Pair>> smallPairLists = CreatePairs(matrixes, numberOfThreads);
    
    // for (int i = 0; i < smallPairLists.size(); i++)
    // {
    //     std::cout << "List: " << i << std::endl;
    //     for (int j = 0; j < smallPairLists[i].size(); j++)
    //     {
    //         std::cout << smallPairLists[i][j].ToString() << std::endl;
    //     }
    // }
    // std::cout << "SMALL LISTS OVER:" << std::endl;

    std::vector<std::thread> threads;

    for (int i = 0; i < smallPairLists.size(); i++)
    {
        // std::vector<Pair> pairs = ;
        threads.push_back(std::thread ([](std::vector<Pair>& pairsForThread)
        {   
            for(int i = 0; i < pairsForThread.size(); i++)
            {
                pairsForThread[i].detetminant = pairsForThread[i].matrix.Determinant();
                // std::cout << "THREAD" << std::endl;
                // std::cout << pairsForThread[i].ToString() << std::endl;
            }
        }, std::ref(smallPairLists[i])));
    }

    for (int i = 0; i < threads.size(); i++)
    {
        threads[i].join();
    }
    
    return MergePairs(std::ref(smallPairLists));
}

std::vector<std::vector<Pair>> CreatePairs(std::vector<Matrix> matrixes, int parts)
{
    // std::cout << "ENTER CREATE PAIRS" << std::endl;
    std::vector<std::vector<Pair>> smallPairLists(parts, std::vector<Pair>(0));

    for(int i = 0, j = 0; i < matrixes.size(); i++, j++) 
    {
        if(j == parts)
        {
            j = 0;
        }
        // std::cout << j << std::endl;
        smallPairLists[j].push_back(Pair(matrixes[i]));
    }
    // std::cout << "END CREATE PAIRS" << std::endl;
    return smallPairLists;
}

std::vector<Pair> MergePairs(std::vector<std::vector<Pair>>& pairsLists)
{
    std::vector<Pair> pairs;
    for (int i = 0; i < pairsLists.size(); i++)
    {
        for (int j = 0; j < pairsLists[i].size(); j++)
        {
            pairs.push_back(pairsLists[i][j]);
        }
    }
    return pairs;
}