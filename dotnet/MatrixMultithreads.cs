using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet
{
    public class MatrixMultithreads
    {
        public static List<double> Determinants(IEnumerable<Matrix> matrixes, int numberOfThreads)
        {
            var pairs = new List<Pair>();
            var tasks = new List<Task>();
            var dets = new List<double>();

            foreach (var matrix in matrixes)
            {
                pairs.Add(new Pair
                {
                    Matrix = matrix
                });
            }

            var pairLists = splitList(pairs, numberOfThreads);
            foreach (var p in pairLists)
            {
                Task task = new Task(() => Job(p));
                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var p in pairLists)
            {
                foreach (var pair in p)
                {
                    dets.Add(pair.Determinant);
                }
            }

            return dets;
        }

        private static IEnumerable<List<T>> splitList<T>(List<T> locations, int nSize=30)  
        {        
            for (int i=0; i < locations.Count; i+= nSize) 
            { 
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i)); 
            }  
        } 

        private static void Job(IList<Pair> pairs)
        {
            foreach (var pair in pairs)
            {
                pair.Determinant = pair.Matrix.Determinant;
            }
        }
    }
}