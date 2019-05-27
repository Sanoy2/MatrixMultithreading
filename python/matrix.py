import random

class Matrix:
    def __init__(self, rows, cols):
        self.init_content(rows, cols)

    def init_content(self, rows, cols):
        self.content = [[0] * cols for i in range(rows)]

    def number_of_rows(self):
        return len(self.content)

    def number_of_cols(self):
        return len(self.content[0])

    def determinant(self):
        return 0

    def create_submatrix(self, row, col):
        mat = Matrix(self.number_of_rows() - 1, self.number_of_cols() - 1)
        k = 0
        l = 0
        i = 0
        j = 0
        while i < self.number_of_rows():
            l = 0
            j = 0
            if i == row:
                i = i + 1
            if i >= self.number_of_rows():
                continue
            while j < self.number_of_cols():
                if j == col:
                    j = j + 1
                if j >= self.number_of_cols():
                    continue
                if k < self.number_of_rows() - 1 and l < self.number_of_cols() - 1:
                    mat.content[k][l] = self.content[i][j]
                l = l + 1
                j = j + 1
            k = k + 1
            i = i + 1
        return mat

    def __str__(self):
        result = ""
        for row in self.content:
            row_result = ""
            for value in row:
                row_result = "{0}|{1}".format(row_result, value)
            result = result + row_result + "|" + "\n"
        return result

def create_random_matrix(rows):
    return create_random_matrix(rows, rows)

def create_random_matrix(rows, cols):
    min_value = -9
    max_value = 9
    mat = Matrix(rows, cols)
    for row in range(mat.number_of_rows()):
        for col in range(mat.number_of_cols()):
            value = random.uniform(min_value, max_value)
            mat.content[row][col] = value

    return mat

def create_sample_matrix():
    min_value = -9
    max_value = 9
    mat = Matrix(3, 3)

    mat.content[0][0] = 1
    mat.content[0][1] = 5
    mat.content[0][2] = 4

    mat.content[1][0] = -9 
    mat.content[1][1] = 3
    mat.content[1][2] = -8

    mat.content[2][0] = -1
    mat.content[2][1] = 9
    mat.content[2][2] = 5

    return mat