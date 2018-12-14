using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2018.Trees
{
    public class TreeNode
    {
        public int Data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode Parent { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public static TreeNode GetNode(int value)
        {
            return new TreeNode(value);
        }
    }
}
