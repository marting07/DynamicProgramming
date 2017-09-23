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

            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < M + 1; j++)
                {
                    if (sequenceX[i] == sequenceY[j])
                        C[i, j] = C[i - 1, j - 1] + 1;
                    else
                        C[i, j] = Math.Max(C[i - 1, j], C[i, j - 1]);
                }
            }

            return GetLCS(sequenceX, sequenceY, C, N, M);
        }

        public static List<char> GetLCS(List<char> sequenceX, List<char> sequenceY, int [,] C, int i, int j)
        {
            if (i == 0 || j == 0)
                return new List<char>();
            else if (sequenceX[i] == sequenceY[j])
                return new List<char>() { sequenceX[i] }.Concat(GetLCS(sequenceX, sequenceY, C, i - 1, j - 1)).ToList();
            else if (C[i - 1, j] >= C[i, j - 1])
                return GetLCS(sequenceX, sequenceY, C, i - 1, j);
            else
                return GetLCS(sequenceX, sequenceY, C, i, j - 1);
        }
    }
}
