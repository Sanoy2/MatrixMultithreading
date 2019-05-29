#ifndef MATRIX_HH
#define MATRIX_HH

#include <vector>
#include <cstdlib>
#include <ctime>
#include <string>
#include <cmath>

class Matrix
{
    private:
        int min_value = -9;
        int max_value = 9;
        void InitMatrix(int rows, int cols);
        void InitMatrix(int rows);
        double GetRandomNumber();

    public:
        std::vector<std::vector<double>> content;

        Matrix();           // sample matrix
        Matrix(int);
        Matrix(int, int);
        
        void Randomize();

        int NumberOfRows();
        int NumberOfCols();
        double Determinant();
        bool IsSquare();

        Matrix CreateSubmatrix(int, int);

        std::string ToString();
};

std::vector<double> Determinants(std::vector<Matrix> matrixes);

#endif