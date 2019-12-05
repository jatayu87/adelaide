using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Adelaide.Trees;
using static System.Console;

namespace Practice2018.Trees
{
    public class TreeOperations
    {
        internal class CommonAncestorResult
        {
            public TreeNode ResultNode { get; set; }
            public bool isAncestor { get; set; }

            public CommonAncestorResult (TreeNode node, bool isAncestor )
            {
                ResultNode = node;
                this.isAncestor = isAncestor;
            }
        }

        private TreeNode InsertANodeInBinarySearchTree(TreeNode root, int data)
        {
            if (root == null)
            {
                return TreeNode.GetNode(data);
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

        private void InorderTraverseRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InorderTraverseRecursive(root.Left);
            Write($" {root.Data}");
            InorderTraverseRecursive(root.Right);
        }

        private void PreOrderTraverseRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Write($" {root.Data}");
            PreOrderTraverseRecursive(root.Left);
            PreOrderTraverseRecursive(root.Right);
        }

        private void PostOrderTraverseRecuresive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PostOrderTraverseRecuresive(root.Left);
            PostOrderTraverseRecuresive(root.Right);
            Write($" {root.Data}");
        }

        private bool SearchInBST(TreeNode root, int value)
        {
            if (root == null)
                return false;

            if (root.Data == value)
                return true;

            if (value < root.Data)
                return SearchInBST(root.Left, value);

            return SearchInBST(root.Right, value);
        }


        private TreeNode CreateMinimalBST(int[] list)
        {
            return CreateMinimalBSTRecursive(list, 0, list.Length-1); // NOTE: don't forget to do length -1 here.
        }

        private TreeNode CreateMinimalBSTRecursive(int[] list, int start, int end)
        {
            // NOTE: <= would skip elements. Dry run and learn how :)
            // ANSWER: end=start part, where the leaves get constructed. these are all
            // arrays of 1 element. 
            // If you add end <=start condition, you would miss all the leaf nodes. 
            if (end < start)
                return null;

            // NOTE: beware of paranthesis. Otherwise, it would just add start with end/2.
            var mid = (start + end) / 2;
            var root = TreeNode.GetNode(list[mid]);
            root.Left = CreateMinimalBSTRecursive(list, start, mid -1); // notice the mid-1
            root.Right = CreateMinimalBSTRecursive(list, mid + 1, end); // noteice the mid+1

            return root;
        }

        private int HeightOfTree(TreeNode root)
        {
            if (root == null)
            {
                return 0; // NOTE: in CTCI, it's return -1.
            }

            return 1 + Math.Max(HeightOfTree(root.Left), HeightOfTree(root.Right));
        }

        private int CheckHeightForBalanced(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            var leftHeight = CheckHeightForBalanced(root.Left);
            if(leftHeight == Int32.MinValue)
                return Int32.MinValue;

            var rightHeight = CheckHeightForBalanced(root.Right);
            if(rightHeight == Int32.MinValue)
                return Int32.MinValue;

            if (Math.Abs(rightHeight - leftHeight) > 1)
                return Int32.MinValue;

            return Math.Max(leftHeight, rightHeight) + 1; // Note the return value, its math.Max. 
        }

        bool IsBalanced(TreeNode root)
        {
            return CheckHeightForBalanced(root) != Int32.MinValue;
        }

        bool IsBST(TreeNode root, int max, int min)
        {
            // check for root. 
            if (root == null)
                return true;

            // check for current node.
            if((min != Int32.MaxValue && root.Data <= min) // condition for right side
                || (max != Int32.MinValue && root.Data > max)) // condition for left side
            {
                return false;
            }

            // check for subtrees
            if (!IsBST(root.Left, root.Data, min) || !IsBST(root.Right, max, root.Data))
            {
                return false;
            }

            return true;
        }

        bool IsBST(TreeNode root)
        {
            // for max we pass MinValue & for min we pass maxValue
            return IsBST(root, int.MinValue, int.MaxValue);
        }


        private CommonAncestorResult GetCommonAncestorHelper(TreeNode node, int p, int q)
        {
            if (node == null)
                return new CommonAncestorResult(null, false);    

            if(node.Data == p && node.Data == q)
                return new CommonAncestorResult(node, true);

            var resultLeft = GetCommonAncestorHelper(node.Left, p, q);
            if (resultLeft.isAncestor)
                return resultLeft;

            var resultRight = GetCommonAncestorHelper(node.Right, p, q);
            if (resultRight.isAncestor)
                return resultRight;


            if (resultLeft.ResultNode != null && resultRight.ResultNode != null)
            {
                // this means left and right both returned a node which is not an ancestor. 
                // that means current node is the common ancestor.
                return new CommonAncestorResult(node, true);
            }

            if (node.Data == p || node.Data == q)
            {
                // we are at either P or q. 
                // we also found p or q in our subtree. 
                var isAncestor = resultLeft.ResultNode != null || resultRight.ResultNode != null;
                return new CommonAncestorResult(node, isAncestor);
            }

            return new CommonAncestorResult(resultLeft.ResultNode ?? resultRight.ResultNode, false);
        }

        private TreeNode GetCommonAncestor(TreeNode root, int p, int q)
        {
            if (root == null)
                return root;

            if (!SearchInBST(root, p))
            {
                WriteLine($"value {p} is not found in tree.");
                return null;
            }

            if (!SearchInBST(root, q))
            {
                WriteLine($"value {q} is not found in tree.");
                return null;
            }

            var result = GetCommonAncestorHelper(root, p, q);
            return result.isAncestor ? result.ResultNode : null;
        }

        private bool IsSubTree(TreeNode parentRoot, TreeNode subTreeNodeRoot)
        {
            if (subTreeNodeRoot == null)
                return true;

            return CheckSubTree(parentRoot, subTreeNodeRoot);
        }

        private bool CheckSubTree(TreeNode parentRoot, TreeNode subTreeNodeRoot)
        {
            if (parentRoot == null)
                return false;

            // check if data matches & tree match returns true from root.
            if (parentRoot.Data == subTreeNodeRoot.Data && MatchTree(parentRoot, subTreeNodeRoot))
            {
                return true;
            }

            // call checkSubT
            return CheckSubTree(parentRoot.Left, subTreeNodeRoot)
                   || CheckSubTree(parentRoot.Right, subTreeNodeRoot); ;
        }

        private bool MatchTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;

            if (t1 == null || t2 == null)
                return false;

            if (t1.Data != t2.Data)
                return false;

            return MatchTree(t1.Left, t2.Left) || MatchTree(t1.Right, t2.Right);
        }


        private int CountPathsWithSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;

            var pathsFromRoot = CheckPathsWithSum(root, sum, 0);

            var pathsFromLeft = CountPathsWithSum(root.Left, sum);
            var pathsFromRight = CountPathsWithSum(root.Right, sum);

            return pathsFromRoot + pathsFromRight+ pathsFromLeft;

        }

        private int CheckPathsWithSum(TreeNode node, int targetSum, int currentSum)
        {
            if (node == null)
                return 0;

            int totalPaths = 0;

            currentSum = currentSum + node.Data;
            if (currentSum == targetSum)
                totalPaths += 1;

            return totalPaths + 
                CheckPathsWithSum(node.Left, targetSum, currentSum) + 
                CheckPathsWithSum(node.Right, targetSum, currentSum);
        }


        private List<List<TreeNode>> ListOfDepths(TreeNode root)
        {
            if (root == null)
                return null;

            var masterList = new List<List<TreeNode>>();
            var levelList = new List<TreeNode> {root};
            while (levelList.Count > 0)
            {
                masterList.Add(levelList);
                var currentLevelList = levelList;
                levelList = new List<TreeNode>();
                foreach (var treeNode in currentLevelList)
                {
                    AddChildren(treeNode, levelList);
                }
            }

            return masterList;
        }

        private void AddChildren(TreeNode node, List<TreeNode> list)
        {
            if(node.Left !=null) 
                list.Add(node.Left);

            if(node.Right != null)
                list.Add(node.Right);
        }

        //static void Main(string[] args)
        //{
        //    TreeOperations t = new TreeOperations();
        //    TreeNode root = t.InsertANodeInBinarySearchTree(null, 50);

        //    root = t.InsertANodeInBinarySearchTree(root, 20);
        //    root = t.InsertANodeInBinarySearchTree(root, 60);
        //    root = t.InsertANodeInBinarySearchTree(root, 25);
        //    root = t.InsertANodeInBinarySearchTree(root, 70);
        //    root = t.InsertANodeInBinarySearchTree(root, 10);
        //    root = t.InsertANodeInBinarySearchTree(root, 15);
        //    root = t.InsertANodeInBinarySearchTree(root, 5);
        //    root = t.InsertANodeInBinarySearchTree(root, 65);
        //    root = t.InsertANodeInBinarySearchTree(root, 80);


        //    WriteLine("\nInOrder traversing:");
        //    t.InorderTraverseRecursive(root);

        //    WriteLine("\nPreOrder traversing:");
        //    t.PreOrderTraverseRecursive(root);

        //    WriteLine("\nPostOrder traversing:");
        //    t.PostOrderTraverseRecuresive(root);
        //    WriteLine();


        //    // search a value in BST
        //    //var val = 20;
        //    //WriteLine($"Is value:{val} present in the tree?: {t.SearchInBST(root, val)}");

        //    //// returns minimal BST
        //    ////int[] a= {10, 20, 30, 40, 50, 60, 70, 80};
        //    ////var minBstRoot = t.CreateMinimalBST(a);
        //    ////t.InorderTraverseRecursive(minBstRoot);

        //    //// calculate height of the tree. 
        //    //WriteLine($"Height of the given tree is: {t.HeightOfTree(root)}");

        //    //// Check if balanced tree
        //    //WriteLine($"Is the tree with root: {root.Data}, balanced?: {t.IsBalanced(root)}");

        //    //// check if the binary tree is BST
        //    //WriteLine($"Is the tree with root:{root.Data}, a BST?:{t.IsBST(root)}");

        //    // common ancestor of the binary tree
        //    //int p = 55;
        //    //int q = 105;
        //    //WriteLine($"Common Ancestor of {p}, {q} is {t.GetCommonAncestor(root, p, q).Data}");


        //    // Check if a tree contains a subtree.
        //    //TreeNode subTreeNodeRoot = t.InsertANodeInBinarySearchTree(null, 20);
        //    //subTreeNodeRoot = t.InsertANodeInBinarySearchTree(subTreeNodeRoot, 10);
        //    //subTreeNodeRoot = t.InsertANodeInBinarySearchTree(subTreeNodeRoot, 15);
        //    //WriteLine($"TreeNode with root:{root.Data} contains subTree with root:{subTreeNodeRoot.Data}? :" +
        //    //          $"{t.IsSubTree(root, subTreeNodeRoot)}");

        //    //var sum = 1300;
        //    //WriteLine($"TreeNode with root:{root.Data} has {t.CountPathsWithSum(root, sum)}" +
        //    //          $" paths of of sum: {sum}");


        //    var listOfLists = t.ListOfDepths(root);
        //    foreach (var list in listOfLists)
        //    {
        //        WriteLine();
        //        foreach (var treeNode in list)
        //        {
        //            Write($" {treeNode.Data}");
        //        }
        //    }
        //    ReadKey();
        //}
    }
}
