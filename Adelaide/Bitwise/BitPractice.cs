using System;
using static System.Console;

namespace Adelaide.Bitwise
{
    class BitPractice {


        private int LeftShift(int number, int position)
        {
            return number << position;
        }

        private int RightShift(int number, int position)
        {
            return number >> position;
        }

        private int SetASpecificBit(int number, int position)
        {   
            return number | (1 << position); // to set, we should or with 1.
        }

        private int ClearASpecificBit(int number, int position)
        {
            return number & (0 << position); // to clear, we should AND with 0.
        }

        private string ShowInBinary(int number)
        {
            return Convert.ToString(number, 2);
        }

        /*static void Main(string[] args)
        {
            var b = new BitPractice();

            //int m = 7;
            //WriteLine($"Given Number: {m}");
            //WriteLine($"Given Number in Binary:{b.ShowInBinary(m)}");

            //int pos = 2;
            //WriteLine($"Left shifted by {pos}: {b.ShowInBinary(b.LeftShift(m, pos))}");
            //WriteLine($"Right shifted by {pos}: {b.ShowInBinary(b.RightShift(m, pos))}");

            // setting 2nd bit from the LSB
            int number = 8;
            WriteLine($"Given Number: {number}");
            WriteLine($"Given Number in Binary:{b.ShowInBinary(number)}");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            WriteLine($"Setting 2nd bit from LSB to 1:{b.ShowInBinary(b.SetASpecificBit(number, 1))}");
            WriteLine($"Clearing 4th bit from LSB to 0:{b.ShowInBinary(b.ClearASpecificBit(number, 3))}");

        }*/
    }
}
