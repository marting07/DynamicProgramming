using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public static class DynamicProgrammingLCS
    {
        public static List<char> LCS(List<char> sequenceX, List<char> sequenceY)
        {
            int N = sequenceX.Count;
            int M = sequenceY.Count;
            int[,] C = new int[N + 1, M + 1];

            for (int i = 0; i < N + 1; i++)
            {
                C[i, 0] = 0;
            }

            for (int j = 0; j < M + 1; j++)
            {
                C[0, j] = 0;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int i_p = i + 1;
                    int j_p = j + 1;
                    if (sequenceX[i] == sequenceY[j])
                        C[i_p, j_p] = C[i_p - 1, j_p - 1] + 1;
                    else
                        C[i_p, j_p] = Math.Max(C[i_p - 1, j_p], C[i_p, j_p - 1]);
                }
            }

            return GetLCS(sequenceX, sequenceY, C, N - 1, M - 1);
        }

        public static List<char> GetLCS(List<char> sequenceX, List<char> sequenceY, int [,] C, int i, int j)
        {
            int i_p = i + 1;
            int j_p = j + 1;
            if (i == -1 || j == -1)
                return new List<char>();
            else if (sequenceX[i] == sequenceY[j])
                return new List<char>() { sequenceX[i] }.Concat(GetLCS(sequenceX, sequenceY, C, i - 1, j - 1)).ToList();
            else if (C[i_p - 1, j_p] >= C[i_p, j_p - 1])
                return GetLCS(sequenceX, sequenceY, C, i - 1, j);
            else
                return GetLCS(sequenceX, sequenceY, C, i, j - 1);
        }
    }
}
