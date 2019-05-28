#include <iostream>
#include <vector>
#include "Matrix.hh"

using namespace std;

int main(int argc, char** argv) 
{
    std::cout << "start" << std::endl;

    Matrix matrix;
    cout << matrix.content.size() << endl;  
    cout << matrix.content[0].size() << endl;


    std::cout << "finish" << std::endl;
    return 0;
}