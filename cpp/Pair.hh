#ifndef PAIR_HH
#define PAIR_HH

#include <string>

#include "Matrix.hh"

class Pair
{
    public:
        double detetminant;
        Matrix matrix;
        Pair();
        Pair(Matrix);
        Pair(Matrix, double);
        std::string ToString();
};

#endif