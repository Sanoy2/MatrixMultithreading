using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet
{
    public class MatrixesListDeterminant
    {
        public static List<Pair> Determinants(List<Matrix> matrixes, int numberOfThreads)
        {
            var tasks = new List<Task>();

            var smallPairLists = CreatePairs(matrixes, numberOfThreads);

            foreach (var pairList in smallPairLists)
            {
                tasks.Add(Task.Run(() =>
                {
                    // pairsForThread[i].detetminant = pairsForThread[i].matrix.Determinant();
                    foreach (var pair in pairList)
                    {
                        pair.Determinant = pair.Matrix.Determinant;
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            // Parallel.ForEach(smallPairLists, smallPairList =>
            // {
            //     Job(smallPairList);
            // });

            return MergePairs(smallPairLists);
        }

        private static List<List<Pair>> CreatePairs(List<Matrix> matrixes, int parts)  
        {
            var smallPairLists = new List<List<Pair>>();
            for (int i = 0; i < parts; i++)
            {
                smallPairLists.Add(new List<Pair>());
            }
            for(int i = 0, j = 0; i < matrixes.Count; i++, j++) 
            {
                if(j == parts)
                {
                    j = 0;
                }
                smallPairLists[j].Add(new Pair(matrixes[i]));
            }

            return smallPairLists;
        }

        private static List<Pair> MergePairs(List<List<Pair>> pairsLists)
        {
            var pairs = new List<Pair>();
            for (int i = 0; i < pairsLists.Count; i++)
            {
                for (int j = 0; j < pairsLists[i].Count; j++)
                {
                    pairs.Add(pairsLists[i][j]);
                }
            }
            return pairs;
        }
    }
}