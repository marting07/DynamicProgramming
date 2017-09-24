using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        public static void exampleBruteForce(List<char> seqX, List<char> seqY)
        {
            Console.WriteLine();
            Console.WriteLine("Brute Force");

            var subSequencesX = new List<char>[(int)Math.Pow(2, seqX.Count)-1];
            var subSequencesY = new List<char>[(int)Math.Pow(2, seqY.Count)-1];

            BruteForceLCS.GenerateSubSequences(seqX, subSequencesX);
            BruteForceLCS.GenerateSubSequences(seqY, subSequencesY);

            var lcs = BruteForceLCS.LCS(subSequencesX, subSequencesY);

            Console.WriteLine();
            PrintSequence(lcs, "LCS");
        }

        public static void exampleDynamicProgramming(List<char> seqX, List<char> seqY)
        {
            Console.WriteLine();
            Console.WriteLine("Dynamic Programming");

            var lcs = DynamicProgrammingLCS.LCS(seqX, seqY);

            Console.WriteLine();
            PrintSequence(lcs, "LCS");
        }

        public static void PrintSequence(List<char> sequence, string name)
        {
            Console.WriteLine($"{name}: {String.Join(", ", sequence.ToArray())}");

        }

        static void Main(string[] args)
        {
            var dataGenerator = new DataGenerator();

            var seqX = dataGenerator.GetSequence(10);
            var seqY = dataGenerator.GetSequence(10);

            PrintSequence(seqX, "seqX");
            PrintSequence(seqY, "seqY");

            exampleBruteForce(seqX, seqY);

            exampleDynamicProgramming(seqX, seqY);

            Console.ReadLine();
        }
    }
}
