import threading

import matrix


def compute_determinants(matrixes, number_of_threads):
    print("{0} threads".format(number_of_threads))

    threads = []
    dets = []
    matrixes2d = split_list(matrixes, number_of_threads)
    output_from_threads = [None] * number_of_threads

    for i in range(number_of_threads):
        t = threading.Thread(target=job, args=(matrixes2d[i], output_from_threads, i))
        threads.append(t)
        t.start()

    for i in range(number_of_threads):
        threads[i].join()

    for collection in output_from_threads:
        for element in collection:
            dets.append(element)

    return dets


def job(matrixes, output, i):
    dets = matrix.determinants(matrixes)
    output[i] = dets


def split_list(alist, wanted_parts=1):
    length = len(alist)
    return [ alist[i*length // wanted_parts: (i+1)*length // wanted_parts] 
             for i in range(wanted_parts) ]
