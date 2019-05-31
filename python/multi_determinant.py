import threading

import matrix
from pair import pair

def compute_determinants(matrixes, number_of_threads):
    print("{0} threads".format(number_of_threads))

    pairs = []
    dets = []
    for matrix in matrixes:
        pairs.append(pair(matrix))

    threads = []
    pairs_lists = split_list(pairs, number_of_threads)

    for i in range(number_of_threads):
        t = threading.Thread(target=job, args=(pairs_lists[i],))
        threads.append(t)
        t.start()

    for i in range(number_of_threads):
        threads[i].join()

    for p in pairs:
        dets.append(p.det)

    return dets


def job(pairs):
    for pair in pairs:
        pair.det = pair.matrix.determinant()


def split_list(alist, wanted_parts=1):
    length = len(alist)
    return [ alist[i*length // wanted_parts: (i+1)*length // wanted_parts] 
             for i in range(wanted_parts) ]
