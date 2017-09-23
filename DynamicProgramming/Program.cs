using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        public static void exampleBruteForce()
        {
            var dataGenerator = new DataGenerator();

            var seqX = dataGenerator.GetSequence(100);
            var seqY = dataGenerator.GetSequence(100);

            var subSequencesX = new List<char>[(int)Math.Pow(2, seqX.Count)-1];
            var subSequencesY = new List<char>[(int)Math.Pow(2, seqY.Count)-1];

            BruteForceLCS.GenerateSubSequences()
        }

        public static void exampleDynamicProgramming()
        {
            var dataGenerator = new DataGenerator();

            var seqX = dataGenerator.GetSequence(100);
            var seqY = dataGenerator.GetSequence(100);
        }

        static void Main(string[] args)
        {
            exampleBruteForce();

            exampleDynamicProgramming();
        }
    }
}
