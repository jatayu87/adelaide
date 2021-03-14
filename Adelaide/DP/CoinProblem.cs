using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.DP
{
    class CoinProblem
    {

        public void Test()
        {
            Console.WriteLine("All is well");
        }

        int[] GetCombinationArray(int amount)
        {
            int[] combinations = new int[amount+1];
            combinations[0] = 1;
            return combinations;
        }

        int[] GetChangeWays(int amount, int [] coins)
        {
            int[] ways = GetCombinationArray(amount);

            for (int i=0; i < coins.Length; i++)
            {
                int coin = coins[i];

                for (int j = 1; j < ways.Length; j++)
                {
                    
                    if (j >= coin)
                    {
                        ways[j] = ways[j] + ways[j-coin];
                    }
                }
            }

            return ways;
        }

        public void PrintWays(int[] ways, int[]coins)
        {
            Console.WriteLine("Coins to use:");
            foreach (int coin in coins)
            {
                Console.WriteLine($"\t {coin}");
            }

            for (int i=0;i<ways.Length;i++)
            {
                Console.WriteLine($"for amount:{i}, number of ways:{ways[i]}");
            }
        }

        public static void Main(string[] args)
        {
            CoinProblem cp = new CoinProblem();
            //cp.Test();

            int[] coins = { 1, 2, 5 };
            int amount = 12;

            int[] ways = cp.GetChangeWays(amount, coins);

            cp.PrintWays(ways, coins);
            
            Console.ReadKey();
        }
    }
}
