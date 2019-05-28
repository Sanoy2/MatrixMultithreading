#ifndef MATRIX_HH
#define MATRIX_HH

#include <iostream>
#include <vector>

class Matrix
{
    private:
        void InitMatrix(int rows, int cols);
        void InitMatrix(int rows);

    public:
        Matrix();           // sample matrix
        Matrix(int);
        Matrix(int, int);
        std::vector<std::vector<double>> content;
        void Randomize();

        int NumberOfRows();
        int NumberOfCols();
        double Determinant();
        bool IsSquare();

        Matrix CreateSubmatrix(int, int);

        std::string ToString();
};

#endif