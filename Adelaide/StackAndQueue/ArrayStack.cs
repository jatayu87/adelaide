using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2018
{
    public class ArrayStack
    {
        static int capacity = 3;
        int[] stack = new int[capacity]; // note: in order to use 'capacity' here, it must be declared static above.
        int top = 0;

        void Push(int i)
        {
            if (top >= capacity)
            {
                Console.WriteLine($"MultiStack is full. Top is at:{top}. capacity: {capacity}");
                return;
            }

            Console.WriteLine($"Pushing number:{i} at index:{top} of the stack");
            stack[top++] = i;
           
        }

        int Pop()
        {
            if (top == 0)
            {
                Console.WriteLine($"MultiStack is empty. Top is at: {top}");
                return -1;
            }

            top = top - 1; 
            var returnValue = stack[top];
            
            Console.WriteLine($"Popping number:{returnValue} at index:{top} of the stack");
            return returnValue;
        }

        void PrintArrayStack()
        {
            Console.Write("\nPrinting all the elements in stack:");
            for(int i=0;i<top; i++)
            {
                Console.Write($" {stack[i]}");
            }
            Console.Write("\n");
        }
        //static void Main(string[] args)
        //{
        //    ArrayStack s = new ArrayStack();
        //    s.Push(1);
        //    s.Push(2);
        //    s.Push(3);
        //    s.Push(4);
        //    s.Push(5);
        //    s.Push(6);
        //    s.PrintArrayStack();

        //    s.Pop();
        //    s.Pop();
        //    s.PrintArrayStack();
        //    s.Pop();
        //    s.Pop();
        //    s.Pop();
        //    s.Pop();

        //    Console.ReadKey();
        //}
    }
}
