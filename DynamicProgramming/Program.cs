using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        public static void exampleBruteForce(List<char> seqX, List<char> seqY, Stopwatch sw)
        {
            Console.WriteLine();
            Console.WriteLine("Brute Force");

            var subSequencesX = new List<char>[(int)Math.Pow(2, seqX.Count)-1];
            var subSequencesY = new List<char>[(int)Math.Pow(2, seqY.Count)-1];

            BruteForceLCS.GenerateSubSequences(seqX, subSequencesX);
            BruteForceLCS.GenerateSubSequences(seqY, subSequencesY);

            sw.Start();
            var lcs = BruteForceLCS.LCS(subSequencesX, subSequencesY);
            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;
            Console.WriteLine($"Elapsed time: {elapsedTime}");

            Console.WriteLine();
            PrintSequence(lcs, "LCS");
        }

        public static void exampleDynamicProgramming(List<char> seqX, List<char> seqY, Stopwatch sw)
        {
            Console.WriteLine();
            Console.WriteLine("Dynamic Programming");

            sw.Start();
            var lcs = DynamicProgrammingLCS.LCS(seqX, seqY);
            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;
            Console.WriteLine($"Elapsed time: {elapsedTime}");

            Console.WriteLine();
            PrintSequence(lcs, "LCS backtracking");
            Console.WriteLine();
            lcs.Reverse();
            PrintSequence(lcs, "LCS");
        }

        public static void PrintSequence(List<char> sequence, string name)
        {
            Console.WriteLine($"{name}: {String.Join(", ", sequence.ToArray())}");

        }

        static void Main(string[] args)
        {
            var dataGenerator = new DataGenerator();

            var seqX = dataGenerator.GetSequence(20);
            var seqY = dataGenerator.GetSequence(20);

            PrintSequence(seqX, "seqX");
            PrintSequence(seqY, "seqY");

            Stopwatch sw = new Stopwatch();

            exampleBruteForce(seqX, seqY, sw);

            exampleDynamicProgramming(seqX, seqY, sw);

            Console.ReadLine();
        }
    }
}
