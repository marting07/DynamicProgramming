using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public static class BruteForceLCS
    {
        public static List<char> LCS(List<char>[] subSequencesX, List<char>[] subSequencesY)
        {
            int N = subSequencesX.Length;
            int M = subSequencesY.Length;
            List<char> lcs = subSequencesX[0];
            int index = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var seqX = new string(subSequencesX[i].ToArray());
                    var seqY = new string(subSequencesY[j].ToArray());

                    if (seqX.Equals(seqY))
                    {
                        if (subSequencesX[i].Count > lcs.Count)
                        {
                            lcs = subSequencesX[i];
                            index = i;
                        }
                    }
                }
            }

            return lcs;
        }

        public static void GenerateSubSequences(List<char> sequence, List<char>[] subSequences)
        {
            int N = subSequences.Length;

            for (int i = 0; i < N; i++)
            {
                subSequences[i] = new List<char>();
                StoreSubSequence(i, i + 1, sequence, subSequences);
            }
        }

        public static void StoreSubSequence(int i, int n, List<char> sequence, List<char>[] subSequences)
        {
            for (int j = 0; j < n; j++)
            {
                if (((j + 1) & n) == (j + 1))
                {
                    subSequences[i].Add(sequence[j]); 
                }
            }
        }

        public static void InitMemory(List<char>[] subSequences)
        {
            int N = subSequences.Length;

            for (int i = 0; i < N; i++)
            {
                subSequences[i] = new List<char>();
            }
        }
    }
}
