using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.Sorting
{
    class MergeIntoBigArray
    {
        void Test()
        {
            Console.WriteLine("All is well");
        }

        // not used
        int[] CopyElementsInto(int[] source, int sourceIndex, int[] target, int targetIndex)
        {
            while (sourceIndex < source.Length)
            {
                target[targetIndex] = source[sourceIndex];
                sourceIndex++;
                targetIndex++;
            }

            return target;
        }

        int[] MergeSortedArrays(int[] source1, int[] source2)
        {
            int[] target = new int[source1.Length + source2.Length];

            // handle conrner cases here, later. 

            // main logic
            int source1Index = 0;
            int source2Index = 0;
            int targetIndex = 0;

            while ((source1Index < source1.Length) && (source2Index < source2.Length))
            {
                if (source1[source1Index] < source2[source2Index])
                {
                    target[targetIndex] = source1[source1Index];
                    source1Index += 1;
                }
                else 
                {
                    target[targetIndex] = source2[source2Index];
                    source2Index += 1;
                }
                targetIndex += 1;
            }

            int[] leftOverArray = source1Index < source1.Length ? source1 : source2;
            int leftOverArrayIndex = source1Index < source1.Length ? source1Index : source2Index;

            while (leftOverArrayIndex < leftOverArray.Length)
            {
                target[targetIndex] = leftOverArray[leftOverArrayIndex];
                leftOverArrayIndex++;
                targetIndex++;
            }
          
            return target;
        }

        void PrintArray(int [] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($" {numbers[i]}");
            }
        }

        public static void Main(String[] args)
        {
            MergeIntoBigArray m = new MergeIntoBigArray();

            // set up input
            int[] a = { 1, 3, 5, 7 };
            int[] b = { };

            // show input
            Console.WriteLine($" Array1:");
            m.PrintArray(a);
            
            Console.WriteLine($"\n Array2:");
            m.PrintArray(b);

            // call main logic method & print the result.
            var result = m.MergeSortedArrays(a, b);
            Console.WriteLine($"\n \n merged and sorted array length:{result.Length}");
            Console.WriteLine("\n merged and sorted array:");
            m.PrintArray(result);

            // wait for keystroke
            Console.ReadKey();
        }
    }
}
