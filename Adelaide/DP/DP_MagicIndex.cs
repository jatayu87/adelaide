using static System.Console;
using static System.Math;

namespace Adelaide.DP
{
    class DP_MagicIndex
    {
        private int GetMagicIndex(int[] numbers) 
        {
            return GetMagicIndex(numbers, 0, numbers.Length-1); // we are interested in index and hence length-1
        }

        // assumes numbers are unique
        private int GetMagicIndex(int[] numbers, int start, int end) 
        {
            // end condition
            if (end < start)
                return -1;

            int mid = (start + end) / 2;
            if (numbers[mid] == mid)
                return mid;

            if (numbers[mid] > mid)
                return GetMagicIndex(numbers, start, mid - 1);

            return GetMagicIndex(numbers, mid+1, end);

        }


        private int GetMagicIndexNonUniqueNumbers(int[] numbers)
        {
            return GetMagicIndexNonUniqueNumbers(numbers, 0, numbers.Length - 1); // we are interested in index and hence length-1
        }

        private int GetMagicIndexNonUniqueNumbers(int[] numbers, int start, int end) 
        {
            if (end < start)
                return -1;

            int mid = (start + end) / 2;
            if (numbers[mid] == mid)
                return mid;


            // search left
            int leftIndex = Min(numbers[mid], mid-1);
            int left = GetMagicIndexNonUniqueNumbers(numbers, start, leftIndex);
            if (left >= 0)
                return left;

            // search right
            int rightIndex = Max(numbers[mid], mid + 1);
            
            int right = GetMagicIndexNonUniqueNumbers(numbers, rightIndex, end);
            if (right < numbers.Length)
                return right;

            return -1;
        }

       /* public static void Main(string[] args)
        {
            DP_MagicIndex program = new DP_MagicIndex();

            int[] numbers = new int[] { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13};
            WriteLine($"Magic index in given array:{program.GetMagicIndex(numbers)}");
            ReadKey();


            numbers = new int[] { -40, -5, 2, 2, 2, 3, 5, 7, 9, 12, 13 };
            WriteLine($"Magic index in given array:{program.GetMagicIndexNonUniqueNumbers(numbers)}");
            ReadKey();
        }*/
    }
}
