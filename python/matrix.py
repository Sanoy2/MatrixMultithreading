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