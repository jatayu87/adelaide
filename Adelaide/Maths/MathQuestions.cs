using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.Maths
{
    class MathQuestions
    {

        public void Test()
        {
            Console.WriteLine("All is well");
        }

        int AdditionWithoutPlus(int a, int b)
        {
            while (b !=0)
            {
                int carry = a & b; // just finds the carry
                a = a ^ b; // do the sum without carry and assign it to 'a'
                b = carry << 1; // move the carry to left (where it's actually going to be applied) and assign it to Y. 
            }

            return a;  // return sum

        }


        //public static void Main(string[] args)
        //{
        //    var ap = new MathQuestions();

        //    int a = -4;
        //    int b = -5;

        //    Console.WriteLine($"{a}+{b}={ap.AdditionWithoutPlus(a, b)}");

        //    Console.ReadKey();
        //}
    }
}
