

using static System.Console;

namespace Adelaide.DP
{
    class ClimbStairsNonRecursive
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
                return -1;

          
            memo[0] = 1; memo[1] = 1;
            memo[2] = 2;
            memo[3] = 4;
            

            for(int i=4; i<=n; i++)
            {                   
                memo[i] = memo[i - 3] + memo[i - 2] + memo[i - 1];
                // simplified version of following condition
                // memo[n] = (memo[n - 3] + memo[3]) + (memo[n - 2] + memo[2]) + (memo[n - 1] + memo[1]);                    

                WriteLine($"For number={i}, possible ways={memo[i]}");
            }

            return memo[n]; 

        }
        
        //static void Main(string[] s)
        //{
        //    ClimbStairsNonRecursive c = new ClimbStairsNonRecursive();
        //    int number = 7;
        //    int answer = c.ClimbStairs(number);
        //    WriteLine($"For input= {number}, answer={answer}");
        //    ReadKey();
        //}
    }
}
