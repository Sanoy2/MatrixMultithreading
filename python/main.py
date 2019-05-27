# from matrix import Matrix
import matrix

def main():
    print("start")
    mat = matrix.create_sample_matrix()
    print(mat.__str__())
    small_mat = mat.create_submatrix(2,1)
    print(small_mat.__str__())
    print("finish") 


if __name__ == "__main__":
    main()