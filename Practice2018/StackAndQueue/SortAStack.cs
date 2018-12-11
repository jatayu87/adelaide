using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice2018.StackAndQueue
{
    class SortAStack
    {
        BasicStack s1, s2;

        SortAStack()
        {
            s1 = new BasicStack();
            s2 = new BasicStack();
        }

        public void Push(int val)
        {
            s1.Push(val);
        }

        public void Sort()
        {
            while (s1.Count() != 0)
            {
                int val = s1.Pop();

                while (s2.Count() != 0 && val < s2.Peek())
                {
                    s1.Push(s2.Pop());
                }

                s2.Push(val);
            }

            while (s2.Count() != 0)
            {
                s1.Push(s2.Pop());
            }

            s1.PrintStack();
        }

        public int Pop()
        {
            return s1.Pop();
        }

        public void PrintStack()
        {
            s1.PrintStack();
        }

        //static void Main(string[] args)
        //{
        //    SortAStack s = new SortAStack();
        //    s.Push(10);
        //    s.Push(12);
        //    s.Push(8);
        //    s.Push(6);

        //    s.Sort();

        //    WriteLine(s.Pop());
        //    s.PrintStack();
        //    ReadKey();
        //}
    }
}
