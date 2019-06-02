import matrix

class Pair:
    def __init__(self, _matrix):
        self.matrix = _matrix
        self.det = 0.0

    def __str__(self):
        result = self.matrix.__str__()
        result = result + "Det: "
        result = result + self.det.__str__()
        result = result + "\n"
        return result

