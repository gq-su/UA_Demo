using System;
using System.Linq;

namespace PairingSocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("$$$--- UA Pairing Socks Demo! ---$$$");
            Console.WriteLine("The program tries to calculate how many pairs of Socks can be sold. For details refer to Readme.");
            Console.WriteLine("Enter an integer n:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[n];

            while (true)
            {
                Console.WriteLine($"Please enter {n} space-separated integers each represents a color:");
                string colors = Console.ReadLine();
                ar = Array.ConvertAll(colors.Split(' '), int.Parse);
                if (ar.Length == n)
                    break;
            }                     

            int matchingCount = GetMatchingPairsCount(ar);

            Console.WriteLine(string.Format("Total number of matching pairs of socks that John can sell: {0}", matchingCount));
            Console.WriteLine("Hit Enter to exit.");
            Console.ReadLine();
        }

        private static int GetMatchingPairsCount(int[] ar)
        {
            var arDist = ar.ToList().Distinct();

            int n = 0;
            arDist.ToList().ForEach(color =>
            {
                n += (int)Math.Floor(ar.Count(o => o == color) / 2d);
            });

            return n;
        }
    }
}
