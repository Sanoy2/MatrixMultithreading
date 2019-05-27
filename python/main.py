# from matrix import Matrix
import matrix

def main():
    print("start")
    mat = matrix.create_sample_matrix()
    print(mat.__str__())
    print("det: {0}".format(mat.determinant()))
    print("finish") 


if __name__ == "__main__":
    main()