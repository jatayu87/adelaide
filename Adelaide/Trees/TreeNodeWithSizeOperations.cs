using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice2018.Trees;
using static System.Console;

namespace Adelaide.Trees
{
    class TreeNodeWithSizeOperations
    {

        /// <summary>
        /// Build a binary search tree with property size at each node. 
        /// size would indicate, how many nodes are below the current node + 1. 
        /// size = size(leftSubtree) + size(rightSubTree) +1
        /// </summary>
        /// <param name="args"></param>
        private TreeNodeWithSize InsertInBinarySearchTreeWithSize(TreeNodeWithSize node, int value)
        {
            if (node == null)
                return TreeNodeWithSize.GetNode(value);

            if (value <= node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = TreeNodeWithSize.GetNode(value);
                }
                else
                {
                    InsertInBinarySearchTreeWithSize(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = TreeNodeWithSize.GetNode(value);
                }
                else
                {
                    InsertInBinarySearchTreeWithSize(node.Right, value);
                }
            }
            node.Size += 1;
            return node;
        }

        private void InOrderTravseralRecursive(TreeNodeWithSize root)
        {
            if(root == null)
                return;

            InOrderTravseralRecursive(root.Left);
            WriteLine($" {root.Data} has size:{root.Size}");
            InOrderTravseralRecursive(root.Right);
        }

        private void PreOrderTravseralRecursive(TreeNodeWithSize root)
        {
            if (root == null)
                return;

            WriteLine($" {root.Data} has size:{root.Size}");
            PreOrderTravseralRecursive(root.Left);
            PreOrderTravseralRecursive(root.Right);
        }

        private TreeNodeWithSize GetRandomNode(TreeNodeWithSize root)
        {
            if (root == null)
                return null;

            Random random = new Random();
            // Assume root's size is 10. then we need to generate random number from 1 to 10. 
            // to do that we need to call random.Next(1, 11). Hence below logic.
            var randomIndex = random.Next(1, root.Size+1); 
            WriteLine($"Random Index:{randomIndex}");
            return GetNodeAt(root, randomIndex);
        }

        private TreeNodeWithSize GetNodeAt(TreeNodeWithSize node, int index)
        {
            var leftSize = node.Left?.Size ?? 0;

            if (index == node.Size)
                return node;

            if (index <= leftSize)
                return GetNodeAt(node.Left, index);

            return GetNodeAt(node.Right, index - leftSize);
        }

        //static void Main(string[] args)
        //{
        //    TreeNodeWithSizeOperations t = new TreeNodeWithSizeOperations();
        //    var root = t.InsertInBinarySearchTreeWithSize(null, 50);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 20);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 60);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 25);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 70);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 10);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 15);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 5);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 65);
        //    root = t.InsertInBinarySearchTreeWithSize(root, 80);


        //    WriteLine("\nInOrder traversing:");
        //    t.InOrderTravseralRecursive(root);

        //    WriteLine("\nPreOrder traversing:");
        //    t.PreOrderTravseralRecursive(root);

        //    //for (int i = 1; i <=10; i++)
        //    //{
        //    //    Random r = new Random();
        //    //    WriteLine($"RandomNumber:{r.Next(1,11)}");
        //    //    WriteLine($"i={i}");
        //    //}
        //    WriteLine($"Randomly printing node: {t.GetRandomNode(root).Data}");



        //    ReadKey();
        //}
    }
}
