import sys

import matrix
import multi_determinant as md


def main():
    matrixes_number = int(sys.argv[1])
    matrixes_dimension = int(sys.argv[2])
    number_of_threads = int(sys.argv[3])
    matrixes = []

    for i in range(matrixes_number):
        matrixes.append(matrix.create_random_matrix(matrixes_dimension, matrixes_dimension))

    # for m in matrixes:
    #     print(m.__str__())

    dets = []
    if number_of_threads > 1:
        dets = md.compute_determinants(matrixes, number_of_threads)
    else:
        dets = matrix.determinants(matrixes)

    # print(dets)


if __name__ == "__main__":
    main()