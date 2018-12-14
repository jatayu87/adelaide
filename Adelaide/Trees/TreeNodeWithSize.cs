using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice2018.Trees;

namespace Adelaide.Trees
{
    class TreeNodeWithSize 
    {
        public int Size { get; set; }
        public int Data { get; set; }

        public TreeNodeWithSize Left { get; set; }

        public TreeNodeWithSize Right { get; set; }

        public TreeNodeWithSize Parent { get; set; }

        public TreeNodeWithSize(int data)
        {
            Data = data;
            Left = null;
            Right = null;
            Size = 1;
        }
       
        public static TreeNodeWithSize GetNode(int value)
        {
            return new TreeNodeWithSize(value);
        }
    }
}
