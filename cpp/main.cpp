#include <iostream>
#include <vector>
#include <map>
#include "Hasher.hh"
#include "PasswordGetter.hh"
#include "PasswordBreaker.hh"
#include "ResultSaver.hh"

int main(int argc, char** argv) 
{
    std::string chars = std::string(argv[1]);
    int maxLength = strtol(argv[2], NULL, 10);
    std::string filepath = std::string(argv[3]);

    PasswordGetter passwordGetter;
    std::vector<std::string> digests = passwordGetter.GetPasswordsHashes(filepath);
    
    std::string resultsPath = "../results/cppBroken.txt";

    // for (int i = 0; i < digests.size(); i++)
    // {
    //     std::cout << digests[i] << std::endl;
    // }

    PasswordBreaker passwordBreaker(chars, digests, maxLength);
    std::map<std::string, std::string> brokenPasswords = passwordBreaker.StartBreaking();

    ResultSaver resultSaver;
    resultSaver.SaveResults(resultsPath, brokenPasswords);
    return 0;
}