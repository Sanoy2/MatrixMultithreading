#include <iostream>
#include "Matrix.hh"

using namespace std;

int main(int argc, char** argv) 
{
    std::srand(std::time(nullptr));
    std::cout << "start" << std::endl;

    Matrix matrix;
    
    // cout << matrix.content.size() << endl;  
    // cout << matrix.content[0].size() << endl;

    matrix.Randomize();
    cout << matrix.ToString() << endl;

    std::cout << "finish" << std::endl;
    return 0;
}