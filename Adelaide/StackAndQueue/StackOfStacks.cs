using System.Collections;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace Practice2018.StackAndQueue
{
    class StackOfStacks 
    {
        List<BasicStack> stacks = new List<BasicStack>();
        int individualStackCapacity = 3;

        public void Push(int i)
        {
            if (stacks.Count == 0)
            {
                var s = new BasicStack(individualStackCapacity);
                s.Push(i);
                stacks.Add(s);
                return;
            }

            var stack = Peek();
            if (!stack.Push(i))
            {
                var s = new BasicStack(individualStackCapacity);
                s.Push(i);
                stacks.Add(s);
            }
        }

        public int Pop()
        {
            if (stacks.Count == 0)
            {
                return -1;
            }

            var latestStack = stacks[stacks.Count-1];
            var returnValue = latestStack.Pop();

            if (returnValue == -1)
            {
                // latest stack is empty, delete this stack and get the latest value from previous one.
                stacks.RemoveAt(stacks.Count -1);
                return Pop();
            }
            return returnValue;
        }

        public BasicStack Peek()
        {
            if (stacks == null || stacks?.Count == 0)
            {
                return null;
            }

             return stacks[stacks.Count - 1];
        }

        public void PrintStacksOfStack()
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                WriteLine($"Printing stack number:{i}");
                stacks[i].PrintStack();
            }
        }

        //static void Main(string[] args)
        //{
        //    var stackOfStacks = new StackOfStacks();
        //    stackOfStacks.Push(5);
        //    stackOfStacks.Push(4);
        //    stackOfStacks.Push(3);
        //    stackOfStacks.Push(2);

        //    stackOfStacks.PrintStacksOfStack();


        //    stackOfStacks.Pop();
        //    stackOfStacks.PrintStacksOfStack();

        //    stackOfStacks.Pop();
        //    stackOfStacks.PrintStacksOfStack();

        //    stackOfStacks.Pop();
        //    stackOfStacks.PrintStacksOfStack();

        //    stackOfStacks.Pop();
        //    stackOfStacks.PrintStacksOfStack();

        //    ReadKey();
        //}
    }
}
