using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static  System.Console;
namespace Practice2018.StackAndQueue
{
    class QueueUsingStacks
    {
        BasicStack simpleStack, reverseStack;

        QueueUsingStacks()
        {
            simpleStack = new BasicStack();
            reverseStack = new BasicStack();
        }

        public void Push(int i)
        {
            simpleStack.Push(i);
        }

        public int Pop()
        {
            if (reverseStack.Count() != 0)
            {
                return reverseStack.Pop();
            }

            TransferElements();
            return reverseStack.Pop();
        }

        private void TransferElements()
        {
            while (simpleStack.Count() > 0)
            {
                reverseStack.Push(simpleStack.Pop());
            }
        }

        public void PrintQueueWithStacks()
        {
            WriteLine("Printing SimpleStack:");
            simpleStack.PrintStack();
            WriteLine("Printing ReverseStack");
            reverseStack.PrintStack();
        }

        public void PrintReverseOrder()
        {
            //todo
        }

        public void PrintInOrder()
        {
            //todo
        }

        //static void Main(string[] args)
        //{
        //    QueueUsingStacks q = new QueueUsingStacks();

        //    q.Push(50);
        //    q.Push(20);
        //    q.PrintQueueWithStacks();

        //    q.Pop();
        //    q.PrintQueueWithStacks();

        //    ReadKey();
        //}
    }
}
