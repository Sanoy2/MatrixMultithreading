import sys

import matrix

def main():
    matrixes_number = int(sys.argv[1])
    matrixes_dimension = int(sys.argv[2])
    matrixes = []

    for i in range(matrixes_number):
        matrixes.append(matrix.create_random_matrix(matrixes_dimension, matrixes_dimension))

    dets = matrix.determinants(matrixes)


if __name__ == "__main__":
    main()