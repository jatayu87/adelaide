using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice2018
{
    class MultiStack
    {
        static int numberOfStacks = 3;
        static int totalCapacity = 9;
        int[] stack = new int[totalCapacity]; // note: in order to use 'totalCapacity' here, it must be declared static above.
        int[] stackTops = new int[numberOfStacks];
        int sizePerStack = totalCapacity / numberOfStacks;

        public void Push(int i, int stackNumber)
        {
            if (stackTops[stackNumber] >= sizePerStack)
            {
                Console.WriteLine($"stack number:{stackNumber} is full. Top is at:{stackTops[stackNumber] }. stack capacity: {sizePerStack}");
                return;
            }

            Console.WriteLine($"Pushing number:{i} at index:{stackTops[stackNumber]} of the stack. " +
                              $"which is global index: {stack[stackNumber*sizePerStack]}");
            stack[stackTops[stackNumber]+ (stackNumber* sizePerStack)] = i;
            stackTops[stackNumber] = stackTops[stackNumber] + 1;
        }

        public int Pop(int stackNumber)
        {
            if (stackTops[stackNumber] == 0)
            {
                Console.WriteLine($"stack number:{stackNumber} is empty. Top is at:{stackTops[stackNumber] }. stack capacity: {sizePerStack}");
                return -1;
            }

            stackTops[stackNumber] = stackTops[stackNumber] - 1;
            var popIndex = stackTops[stackNumber] + (stackNumber * sizePerStack);
            var returnValue = stack[popIndex];
            stack[popIndex] = 0; // setting default value back

            Console.WriteLine($"Popping number:{returnValue} at index:{stackTops[stackNumber]} of the stack:{stackNumber}." +
                              $"Global index: {popIndex}");
            return returnValue;
        }

        public void PrintArrayStack()
        {
            Console.Write("\nPrinting all the elements in stack:");
            for (int i = 0; i < totalCapacity; i++)
            {
                Console.Write($" {stack[i]}");
            }
            Console.Write("\n");
        }
    }

    class MultipleStacksInAnArray
    {
        //static void Main(string[] args)
        //{
        //    MultiStack m = new MultiStack();
        //    m.Push(1,0);
        //    m.Push(1,1);
        //    m.Push(1,2);
        //    m.PrintArrayStack();


        //    m.Push(2, 1);
        //    m.Push(3, 1);
        //    m.Push(4, 1);
        //    m.PrintArrayStack();

        //    m.Pop(1);
        //    m.PrintArrayStack();
        //    m.Pop(1);
        //    m.PrintArrayStack();
        //    m.Pop(1);
        //    m.PrintArrayStack();
        //    m.Pop(1);
        //    m.PrintArrayStack();
        //    m.Pop(1);
        //    m.PrintArrayStack();
        //    //m.Push(2, 0);
        //    //m.Push(2, 1);
        //    //m.Push(2, 2);
        //    //m.PrintArrayStack();

        //    //m.Push(3, 0);
        //    //m.Push(3, 1);
        //    //m.Push(3, 2);
        //    //m.PrintArrayStack();
        //    ReadKey();
        //}
    }
}
