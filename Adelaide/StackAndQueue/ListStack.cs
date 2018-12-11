using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice2018
{
    public class ListStack
    {
        class Stack
        {
            List<int> stack;
            int capacity = 3;

            internal Stack()
            {

            }

            public Stack(int capacity)
            {
                stack = new List<int>();
                this.capacity = capacity;
            }

            public bool Push(int i)
            {
                if (stack.Count == capacity)
                {
                    WriteLine($"Can't push. stack is full. capacity:{capacity}, Actual size: {stack.Count}");
                    return false;
                }

                stack.Add(i);
                WriteLine($"Pushed element: {i} at index: {stack.Count - 1} successfully.");
                return true;
            }

            public int Pop()
            {
                if (stack.Count == 0)
                {
                    WriteLine("Can't Pop. stack is empty.");
                    return -1;
                }
                int top = stack.Count - 1;
                int returnValue = stack[top];
                stack.RemoveAt(top);

                WriteLine($"Popped element: {returnValue} from index: {top} successfully.");
                return returnValue;
            }

            public void PrintStack()
            {
                WriteLine($"Printing the stack:");
                foreach (int i in stack)
                {
                    Write($" {i}");
                }
                WriteLine("");
            }
        }


        class StackWithMin : Stack
        {
            int capacity = 3;
            List<int> stack;

            internal StackWithMin(int capacity) : base(capacity)
            {
                this.capacity = capacity;
                this.stack = new List<int>();
            }

            public void Push(int i)
            {
                // first element would always be minimum
                if (stack.Count == 0)
                {
                    if(base.Push(i))
                    stack.Add(i);
                    return;
                }

                // base stack's push is not succesful.
                if (!base.Push(i))
                {
                    WriteLine($"Not adding element in MinStack, as Base stack is full.");
                    return;
                }

                //base push successful, check if i is minmimum so far.
                if (i <= Peek())
                {
                    stack.Add(i);
                }
            }

            public int Pop()
            {
                int baseReturnValue = base.Pop();

                if (baseReturnValue == -1)
                {
                    WriteLine("Empty Stack. Can't pop.");
                }

                if (baseReturnValue == Peek())
                {
                    stack.RemoveAt(stack.Count - 1);
                    WriteLine($"Popped from min value stack. Popped Value:{baseReturnValue}");
                }
                return baseReturnValue;
            }

            public int Min()
            {
                if (stack.Count > 0)
                {
                    return stack[stack.Count - 1];
                }

                return Int32.MaxValue;
            }

            public int Peek()
            {
                if (stack.Count > 0)
                {
                    return stack[stack.Count - 1];
                }

                return Int32.MaxValue;
            }

            public void PrintStack()
            {
                base.PrintStack();
                foreach (int i in stack)
                {
                    Write($" {i}");
                }
                WriteLine("");
            }
        }

        //static void Main(string[] args)
        //{
        //    // Basic ArrayList with basic push and pop
        //    //Stack s = new Stack(4);
        //    //s.Push(1);
        //    //s.Push(2);
        //    //s.Push(3);
        //    //s.Push(4);
        //    //s.Push(5);

        //    //s.PrintStack();

        //    //s.Pop();
        //    //s.Pop();
        //    //s.PrintStack();
        //    //s.Pop();
        //    //s.PrintStack();
        //    //s.Pop();
        //    //s.Pop();


        //    // ArrayList stack with Min, pop and push.
        //    StackWithMin sm = new StackWithMin(6);
        //    sm.Push(10);
        //    sm.PrintStack();

        //    sm.Push(11);
        //    sm.PrintStack();

        //    sm.Push(4);
        //    sm.PrintStack();

        //    sm.Push(25);
        //    sm.PrintStack();

        //    sm.Push(1);
        //    sm.PrintStack();

        //    sm.Pop();
        //    sm.PrintStack();

        //    sm.Pop();
        //    sm.PrintStack();

        //    sm.Pop();
        //    sm.PrintStack();

        //    sm.Pop();
        //    sm.PrintStack();

        //    sm.Pop();
        //    sm.PrintStack();

        //    ReadKey();
        //}
    }
}
