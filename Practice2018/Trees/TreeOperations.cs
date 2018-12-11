using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice2018.Trees
{
    class TreeOperations
    {
        private Tree InsertANodeInBinarySearchTree(Tree root, int data)
        {
            if (root == null)
            {
                return Tree.GetNode(data);
            }

            if (root.Data == data)
            {
                WriteLine($"Node with value:{data} already exists in the tree.");
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertANodeInBinarySearchTree(root.Left, data);
            }
            else
            {
                root.Right = InsertANodeInBinarySearchTree(root.Right, data);
            }
            return root;
        }

        private void InorderTraverseRecursive(Tree root)
        {
            if (root == null)
            {
                return;
            }

            InorderTraverseRecursive(root.Left);
            Write($" {root.Data}");
            InorderTraverseRecursive(root.Right);
        }

        private void PreOrderTraverseRecursive(Tree root)
        {
            if (root == null)
            {
                return;
            }

            Write($" {root.Data}");
            PreOrderTraverseRecursive(root.Left);
            PreOrderTraverseRecursive(root.Right);
        }

        private void PostOrderTraverseRecuresive(Tree root)
        {
            if (root == null)
            {
                return;
            }

            PostOrderTraverseRecuresive(root.Left);
            PostOrderTraverseRecuresive(root.Right);
            Write($" {root.Data}");
        }

        private bool SearchInBST(Tree root, int value)
        {
            if (root == null)
                return false;

            if (root.Data == value)
                return true;

            if (value < root.Data)
                return SearchInBST(root.Left, value);

            return SearchInBST(root.Right, value);
        }


        private Tree CreateMinimalBST(int[] list)
        {
            return CreateMinimalBSTRecursive(list, 0, list.Length-1); // NOTE: don't forget to do length -1 here.
        }

        private Tree CreateMinimalBSTRecursive(int[] list, int start, int end)
        {
            // NOTE: <= would skip elements. Dry run and learn how :)
            // ANSWER: end=start part, where the leaves get constructed. these are all
            // arrays of 1 element. 
            // If you add end <=start condition, you would miss all the leaf nodes. 
            if (end < start)
                return null;

            // NOTE: beware of paranthesis. Otherwise, it would just add start with end/2.
            var mid = (start + end) / 2;
            var root = Tree.GetNode(list[mid]);
            root.Left = CreateMinimalBSTRecursive(list, start, mid -1); // notice the mid-1
            root.Right = CreateMinimalBSTRecursive(list, mid + 1, end); // noteice the mid+1

            return root;
        }

        static void Main(string[] args)
        {
            TreeOperations t = new TreeOperations();
            Tree root = t.InsertANodeInBinarySearchTree(null, 50);

            root = t.InsertANodeInBinarySearchTree(root, 20);
            root = t.InsertANodeInBinarySearchTree(root, 60);
            root = t.InsertANodeInBinarySearchTree(root, 10);
            root = t.InsertANodeInBinarySearchTree(root, 30);
            root = t.InsertANodeInBinarySearchTree(root, 70);
            root = t.InsertANodeInBinarySearchTree(root, 80);
            root = t.InsertANodeInBinarySearchTree(root, 55);

            WriteLine("\nInOrder traversing:");
            t.InorderTraverseRecursive(root);

            WriteLine("\nPreOrder traversing:");
            t.PreOrderTraverseRecursive(root);

            WriteLine("\nPostOrder traversing:");
            t.PostOrderTraverseRecuresive(root);
            WriteLine();


            // search a value in BST
            var val = 20;
            WriteLine($"Is value:{val} present in the tree?: {t.SearchInBST(root, val)}");

            // returna minimal BST
            int[] a= {10, 20, 30, 40, 50, 60, 70, 80};
            var minBstRoot = t.CreateMinimalBST(a);
            t.InorderTraverseRecursive(minBstRoot);
            ReadKey();
        }

    }
}
