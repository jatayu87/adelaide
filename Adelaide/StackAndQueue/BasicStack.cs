using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice2018.StackAndQueue
{
    class BasicStack
    {
        List<int> stack;
        int capacity =10;

        internal BasicStack()
        {
            stack = new List<int>();
        }

        public BasicStack(int capacity) 
        {
            this.capacity = capacity;
        }

        public bool Push(int i)
        {
            if (stack.Count == capacity)
            {
                //WriteLine($"Can't push. stack is full. capacity:{capacity}, Actual size: {stack.Count}");
                return false;
            }

            stack.Add(i);
            WriteLine($"Pushed element: {i} at index: {stack.Count - 1} successfully.");
            return true;
        }

        public int Peek()
        {
            if (stack.Count == 0)
            {
                //WriteLine("Can't Pop. stack is empty.");
                return -1;
            }
            return stack[stack.Count - 1];
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                //WriteLine("Can't Pop. stack is empty.");
                return -1;
            }
            int top = stack.Count - 1;
            int returnValue = stack[top];
            stack.RemoveAt(top);

            WriteLine($"Popped element: {returnValue} from index: {top} successfully.");
            return returnValue;
        }

        public int Count()
        {
            return stack.Count;
        }

        public void PrintStack()
        {
            WriteLine("Printing the stack:");
            foreach (int i in stack)
            {
                Write($" {i}");
            }
            WriteLine("");
        }
    }
}
