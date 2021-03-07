

using static System.Console;

namespace Adelaide.DP
{
    class DP
    {
        private int[] FillAndReturn(int[] memo, int value)
        {
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = value;
            }
            return memo;
        }

        private void PrintArray(int[] memo)
        {
            for (int i = 0; i < memo.Length; i++)
            {
                Write($"{memo[i]} ");
            }
        }

        public int ClimbStairs(int n)
        {
            int[] memo = FillAndReturn(new int[n + 1], -1);
            PrintArray(memo);

            return ClimbStairs(n, memo);
        }

        public int ClimbStairs(int n, int[] memo)
        {
            if (n < 0)
                return 0;
            
            if (n == 0 || n == 1)
                return 1;
            
            if (memo[n] > -1)
                return memo[n];
            
            memo[n] = ClimbStairs(n-1, memo) + ClimbStairs(n-2, memo);
            return memo[n];

        }


        private void Test()
        {
            WriteLine("All is well");
        }

        //static void Main(string[] s)
        //{
        //    DP dp = new DP();
        //    int answer = dp.ClimbStairs(2);
        //    WriteLine($"Answer={answer}");
        //    ReadKey();
        //}
    }
}
