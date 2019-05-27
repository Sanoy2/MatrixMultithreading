# from matrix import Matrix
import matrix

def main():
    print("start")
    mat = matrix.create_random_matrix(3,3)
    print(mat.__str__())
    print("finish") 


if __name__ == "__main__":
    main()