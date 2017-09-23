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
            List<char> lcs = new List<char>();
            int index = 0;

            for (int i = 0; i < N; i++)
            {
                var seqX = new string(subSequencesX[i].ToArray());
                for (int j = 0; j < M; j++)
                {
                    var seqY = new string(subSequencesY[j].ToArray());

                    if (seqY.Equals(seqX))
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
            int M = subSequences.Length;

            for (int i = 0; i < M; i++)
            {
                subSequences[i] = new List<char>();
                StoreSubSequence(i, i + 1, sequence, subSequences);
            }
        }

        public static void StoreSubSequence(int i, int mask, List<char> sequence, List<char>[] subSequences)
        {
            int N = sequence.Count;

            for (int j = 0; j < N; j++)
            {
                if (((1 << j) & mask) != 0)
                {
                    subSequences[i].Add(sequence[j]); 
                }
            }
        }
    }
}
