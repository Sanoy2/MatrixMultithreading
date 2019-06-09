import sys

import matrix
import pair
import matrixes_list_determinant as mld


def main():
    matrixes_number = int(sys.argv[1])
    matrixes_dimension = int(sys.argv[2])
    number_of_threads = int(sys.argv[3])
    matrixes = []

    for i in range(matrixes_number):
        matrixes.append(matrix.create_random_matrix(matrixes_dimension, matrixes_dimension))

    pairs = mld.compute_determinants_multithreading(matrixes, number_of_threads)

    # for pair in pairs:
    #     print(pair.__str__())


if __name__ == "__main__":
    main()