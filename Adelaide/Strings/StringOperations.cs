using System;
using static System.Console;

namespace Adelaide.Strings
{
    class StringOperations
    {

        bool IsOneDistanceAway(string first, string second)
        {
            if (string.IsNullOrEmpty(first) && (string.IsNullOrEmpty(second)))
                return true;

            if (string.IsNullOrEmpty(first))
                return false;

            if (string.IsNullOrEmpty(second))
                return false;

            // the difference in legnths of the two strings cannot be more than 1.
            if(Math.Abs(first.Length - second.Length) > 1)
                return false;

            var index1 = 0;
            var index2 = 0;
            var mismatchFound = false;

            var s1 = string.Empty;
            var s2 = string.Empty;

            if (first.Length > second.Length)
            {
                s1 = second;
                s2 = first;
            }
            else 
            {
                s1 = first;
                s2 = second;
            }

            while (index1 < s1.Length && index2 < s2.Length)
            {
                // check the strings character by character
                if (s1[index1] != s2[index2])
                {
                    if (mismatchFound)
                        return false;

                    mismatchFound = true;

                    // the characters didn't match
                    if (s1.Length == s2.Length)
                    {  
                        // update case
                        index1++;
                    }
                    else 
                    {
                        // insert or remove case
                        //do nothing
                    }
                }
                else
                {
                    // the characters matched
                    index1++;
                }

                index2++;
            }

            return true;
        }

        void TestOneDistanceAway()
        {
            var s1 = "apple";
            var s2 = "pple";
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");

            s1 = "bale";
            s2 = "pale";
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");


            s1 = "Ball";
            s2 = "Call";
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");

            s1 = "all";
            s2 = "Call";
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");

            // False cases
            s1 = "pale";
            s2 = "bae";
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");

            s1 = null;
            s2 = null;
            Console.WriteLine($"strings to compare:{s1} & {s2}. Result: {IsOneDistanceAway(s1, s2)}");
        }

        static void Main(string[] args)
        {
            var s = new StringOperations();
            s.TestOneDistanceAway();
        }
    }
}
