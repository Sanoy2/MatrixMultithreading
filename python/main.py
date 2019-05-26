import sys

from password_breaker import password_breaker
import password_getter
import result_saver


def main():

    chars = sys.argv[1]
    max_length = int(sys.argv[2])
    digests_to_break_filepath = sys.argv[3]
    results_filepath = "../results/pythonBroken.txt";

    digests = password_getter.get_passwords_hashes(digests_to_break_filepath)

    breaker = password_breaker(chars, digests, max_length)
    result = breaker.start_breaking()

    result_saver.save_results(results_filepath, result)

if __name__ == "__main__":
    main()