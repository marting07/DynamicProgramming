using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class DataGenerator
    {
        const string DATA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rnd;

        public DataGenerator()
        {
            rnd = new Random();
        }

        public List<char> GetSequence(int N)
        {
            List<char> sequence = new List<char>(N);

            for (int i = 0; i < N; i++)
            {
                var index = rnd.Next(DATA.Length);
                sequence.Add(DATA[index]);
            }

            return sequence;
        }
    }
}
