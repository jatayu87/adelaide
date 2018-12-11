using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2018.Trees
{
    public class Tree
    {
        public int Data { get; set; }

        public Tree Left { get; set; }

        public Tree Right { get; set; }

        public Tree Parent { get; set; }

        public static Tree GetNode(int value)
        {
            return new Tree()
            {
                Data = value,
                Left = null,
                Right = null
            };
        }
    }
}
