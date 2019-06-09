import threading

from matrix import Matrix
from pair import Pair

def compute_determinants_multithreading(matrixes, number_of_threads):
    # print("{0} threads".format(number_of_threads))
    if number_of_threads < 1:
        print("Number of threads lower than 1!")
        exit()
    
    small_pair_lists =  create_pairs(matrixes, number_of_threads)
    threads = []

    for i in range(number_of_threads):
        t = threading.Thread(target=job, args=(small_pair_lists[i],))
        threads.append(t)
        t.start()

    for i in range(number_of_threads):
        threads[i].join()

    return merge_pairs(small_pair_lists)


def job(pairs):
    for pair in pairs:
        pair.det = pair.matrix.determinant()


def create_pairs(matrixes, parts):
    small_pair_lists = []
    for i in range(parts):
        small_pair_lists.append([])

    j = 0
    for i in range(len(matrixes)):
        if j == parts:
            j = 0
        small_pair_lists[j].append(Pair(matrixes[i]))
        j = j + 1

    return small_pair_lists


def merge_pairs(pairs_lists):
    pairs = []
    for i in range(len(pairs_lists)):
        for j in range(len(pairs_lists[i])):
            pairs.append(pairs_lists[i][j])

    return pairs