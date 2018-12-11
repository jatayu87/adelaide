using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace Practice2018.Bitwise
{
    class Bitwise
    {

        void MergeTwoNumbers(int n, int m, int i, int j)
        {
            WriteLine($"{Convert.ToString(n, 2)}");
            WriteLine($"{Convert.ToString(m, 2)}");
            WriteLine($"from:{i} to {j}");

            int allOnes = ~0;
            WriteLine($"AllOnes:{Convert.ToString(allOnes, 2)}");

            int leftOnes = allOnes << (j + 1);
            WriteLine($"leftOnes:{Convert.ToString(leftOnes, 2)}");

            int rightOnes = (1 << i)-1;
            WriteLine($"rightOnes:{Convert.ToString(rightOnes, 2)}");

            int mask = rightOnes | leftOnes;
            WriteLine($"mask:{Convert.ToString(mask, 2)}");

            int clearN = n & mask;
            WriteLine($"clearN:{Convert.ToString(clearN, 2)}");

            int shiftedM = m << i;
            WriteLine($"shiftedM:{Convert.ToString(shiftedM, 2)}");

            int merge = clearN | shiftedM;
            WriteLine($"merge:{Convert.ToString(merge, 2)}");
        }

        bool IsPowerOf2(int n)
        {
            int numberOfOnes = 0;
            while (n >0)
            {
                if ((1 & n) > 0)
                {
                    numberOfOnes += 1;
                }
                n = n >> 1;
            }

            return numberOfOnes == 1;
        }

        bool IsPowerOf2Faster(int n)
        {
            if ((n & (n - 1)) == 0)
                return true;

            return false;
        }

        int DifferentBitsIn2Numbers(int a, int b)
        {
            // step1: xor the two numbers. That will leave only the mismatched bits as 1s. 
            // step2: run a loop, clear the last 1 in the xor in each step
            // count the number of iterations it takes to make the xor turn to 0
           
            int numberOfOnes = 0;
            for (int i = a ^ b; i != 0; i = i & (i - 1)) // i=i&(i-1) clears the last 1 from LSB position.
            {
                numberOfOnes += 1;
            }

            return numberOfOnes;
        }

        int MSBPosition(int a)
        {
            int count = 0;
            for (int i = a; i != 0; i = i>>1) // Note we must do i>>1 to calculat the MSB length.
            {
                count += 1;
            }
            return count;
        }

        int SameBitsIn2Numbers(int a, int b)
        {
            // NOTE: to count the same number of bits in two numbers?
            // 1.Find the most significant set bit's position of both the numbers. 
            // 2.Get the greator one. 
            // 3.get the different bits in two numbers. 
            // 2-3 should be the answer.
            
            int bitsInA = MSBPosition(a); // 
            int bitsInB = MSBPosition(b);
            int differentBits = DifferentBitsIn2Numbers(a, b);

            if (bitsInA > bitsInB)
            {
                return bitsInA - differentBits;
            }

            return bitsInB - differentBits;
        }

        //static void Main(string[] args)
        //{
        //    Bitwise b = new Bitwise();

        //    // Merge two numbers in bitwise operations.
        //    //b.MergeTwoNumbers(20,7,1,3);

        //    // check if a given number is a power of 2
        //    //int n = 2;
        //    //WriteLine($"{n} is power of two?: {b.IsPowerOf2(n)}");
        //    //WriteLine($"{n} is power of two?: {b.IsPowerOf2Faster(n)}");

        //    // to calculate number of same and different bits in 2 numbers.
        //    int m = 10;
        //    int n = 100;
        //    WriteLine($"m:{Convert.ToString(m, 2)}");
        //    WriteLine($"n:{Convert.ToString(n, 2)}");
        //    WriteLine($"Same bits in {m} & {n} are: {b.SameBitsIn2Numbers(m,n)}");
        //    WriteLine($"Different bits in {m} & {n} are: {b.DifferentBitsIn2Numbers(m, n)}");

        //    ReadKey();
        //}
    }
}
