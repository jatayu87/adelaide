
using System;
using System.Collections.Generic;

namespace Practice2018
{
    class SingleLinkedList
    {
        class Node
        {
            public int value;
            public Node next;
        }

        private Node BuildLinkedList(int[] values)
        {
            Node head = null;
            Node tail = head;

            for (int i = 0; i < values.Length; i++)
            {
                var newNode = new Node()
                {
                    value = values[i],
                    next = null
                };

                if (i == 0)
                {
                    head = tail = newNode;
                }
                else
                {
                    tail.next = newNode;
                    tail = newNode;
                }
            }
            return head;
        }

        private void PrintLinkedList(Node node)
        {
            while (node != null)
            {
                if (node.next == null)
                {
                    Console.Write($"{node.value}.\n");
                    break;
                }

                Console.Write($"{node.value}->");

                node = node.next;
            }
        }

        private void PrintKthElementInList(Node head, int k)
        {
            Console.WriteLine($"Value of K: {k}. \nPrinting Given Linked list:");
            PrintLinkedList(head);

            // get a new pointer
            Node tempHead = head;
            Node kThNodeFinder = head;

            // move the new pointer to K positions ahead.
            for (int i = 0; i < k; i++)
            {
                if (tempHead == null)
                {
                    Console.WriteLine($"Given list doesn't have {k} elements");
                    return;
                }

                kThNodeFinder = tempHead;
                tempHead = tempHead.next;
            }

            Console.WriteLine($"Set the KthNodeFinder on node:{kThNodeFinder.value}");

            tempHead = head;
            while (kThNodeFinder.next != null)
            {
                tempHead = tempHead.next;
                kThNodeFinder = kThNodeFinder.next;
            }

            Console.WriteLine($"{k}-th node from the last node is, node with value: {tempHead.value}");
        }

        private Node DeleteRepeatingNodeInList(Node head)
        {
            Console.WriteLine($"Printing Given Linked list:");
            PrintLinkedList(head);

            HashSet<int> map = new HashSet<int>();

            if (head == null || head.next == null)
            {
                return head;
            }

            // Set up
            Node trackerNode = head;
            Node previous = null;

            while (trackerNode != null)
            {
                if (map.Contains(trackerNode.value))
                {
                    // duplicate detected
                    if (previous != null)
                    {
                        previous.next = trackerNode.next;
                    }
                }
                else
                {
                    // add to map
                    map.Add(trackerNode.value);
                    previous = trackerNode;
                }

                trackerNode = trackerNode.next;
            }

            return head;
        }

        private Node CreateReverseList(Node head)
        {
            Console.WriteLine($"Printing Given Linked list:");
            PrintLinkedList(head);


            Node previous = null;
            while (head != null)
            {
                var newNode = new Node() {
                    value = head.value,
                    next = previous,
                };

                previous = newNode;
                head = head.next;
            }

            return previous;
        }


        private void FindAMidPointOfAList(Node head)
        {
            Console.WriteLine($"Printing Given Linked list:");
            PrintLinkedList(head);

            if (head == null || head.next == null || head.next.next == null)
            {
                Console.WriteLine("No midpoint for a linked list that's null or less than 3 nodes.");
                return;
            }

            Node slowRunner = head;
            Node fastRunner = head.next;

            // NOTE: the sequence of these check matters.
            while (fastRunner != null && fastRunner.next != null)
            {
                slowRunner = slowRunner.next;
                fastRunner = fastRunner.next.next;
            }

            Console.WriteLine($"Mid node is {slowRunner.value}");

            //// NOTE: condition here matters. Can't test for odd numbers check (it would be fastRunner.next == null, 
            //// which would through null reference for even linked lists. 
            //if (fastRunner == null)
            //{
            //    //list had even numbers
            //    Console.WriteLine($"Since it's an even linked list. We take 2 mid nodes. " +
            //        $"Midnode1: {slowRunner.value}, Midnode2: {slowRunner.next.value}");

            //}
            //else
            //{
            //    // list had odd numbers
            //    Console.WriteLine($"Mid node is {slowRunner.value}");
            //}
        }

        private bool IsAPalindrome(Node head)
        {
            Console.WriteLine($"Printing Given Linked list:");
            PrintLinkedList(head);

            if (head == null || head.next == null )
            {
                Console.WriteLine("List is either null or has only 1 element. Hence returning true as a palindrome.");
                return true;
            }

            // data structure intialization.
            Node slowRunner = head;
            Node fastRunner = head.next;
            Stack<int> firstHalfData = new Stack<int>();

            // load the stack till midpoint.
            // NOTE: the sequence of these check matters.
            // fastRunner != null will be true for odd sized linked lists.
            // fastRunner.next != null will be true for even sized linked lists. 
            while (fastRunner != null && fastRunner.next != null)
            {
                firstHalfData.Push(slowRunner.value);
                slowRunner = slowRunner.next;
                fastRunner = fastRunner.next.next;
            }

            Console.WriteLine($"Mid node is {slowRunner.value}");

            // for even linked list, we need to add the mid point in stack before we move the pointer. 
            if (fastRunner != null)
            {
                firstHalfData.Push(slowRunner.value);
            }

            // move slowRunner to a node after midpoint
            slowRunner = slowRunner.next;


            //compare the stack with second half. 
            while (slowRunner != null)
            {
                int poppedValue = firstHalfData.Pop();

                Console.WriteLine($"PoppedValue: {poppedValue}, SlowRunner's value:{slowRunner.value}");
                if (poppedValue != slowRunner.value)
                {
                    Console.WriteLine($"PoppedValue: {poppedValue} doesn't match with SlowRunner's value: {slowRunner.value}. Not a palindrome.");
                    return false;
                }
                else
                {
                    Console.WriteLine("matched.");
                }

                slowRunner = slowRunner.next;
            }


            Console.WriteLine("All values matched, it's a palindrome!");
            return true;
        }


        private Node SumTwoLists(Node list1, Node list2)
        {
            Node head = null;
            Node answer = null;

            int carry = 0;

            while (list1 != null && list2 != null)
            {
                int sum = list1.value + list2.value + carry;
                int lastDigit = sum % 10;
                carry = sum / 10;

                Node n = new Node() {
                    value = lastDigit,
                    next = null
                };

                if (answer == null)
                {
                    answer = n;
                    head = answer;
                }
                else
                {
                    answer.next = n;
                    answer = answer.next;
                }

                list1 = list1.next;
                list2 = list2.next;
            }

            // both are of equal lengths, check if we need to create a new node for leftover carry.
            if (list1 == null && list2 == null)
            {
                if (carry > 0)
                {
                    Node n = new Node()
                    {
                        value = carry,
                        next = null
                    };

                    answer.next = n;
                }
            }

            // just run over the longer list.
            Node longerList = null;
            longerList = (list1 != null) ? list1 : list2;
            while (longerList !=null)
            {
                // optimize here.
                int sum = longerList.value + carry;
                int lastDigit = sum % 10;
                carry = sum / 10;

                Node n = new Node()
                {
                    value = lastDigit,
                    next = null
                };
                answer.next = n;
                answer = answer.next;

                longerList = longerList.next;
            }

            return head;
        }

        private int FindLengthOfTheLinkedList(Node head)
        {
            Console.WriteLine($"Printing Given Linked list:");
            PrintLinkedList(head);

            int length = 0;

            while (head != null)
            {
                length = length +1;
                head = head.next;
            }
            return length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    SingleLinkedList p = new SingleLinkedList();
        //    int[] listNumbers = { 1, 2, 3};
        //    var list = p.BuildLinkedList(listNumbers);
        //    //p.PrintLinkedList(list);

        //    //p.PrintKthElementInList(list, 10);


        //    // Remove duplicates in linked list.
        //    //int[] duplicateListNumbers = { 2, 2, 2, 4, 4, 6, 6 };
        //    //var duplicateList = p.BuildLinkedList(duplicateListNumbers);
        //    //var uniqueList = p.DeleteRepeatingNodeInList(duplicateList);
        //    //Console.WriteLine("Printing list with all unique elements:");
        //    //p.PrintLinkedList(uniqueList);


        //    // Create a reverse linked List.
        //    //var reversedList = p.CreateReverseList(list);
        //    //Console.WriteLine("Printing newly created reversed list:");
        //    //p.PrintLinkedList(reversedList);

        //    // Find a midpoint of a list
        //    //p.FindAMidPointOfAList(list);

        //    // Check if the list is a palindrome
        //    //var isPalindrome = p.IsAPalindrome(list);
        //    //Console.WriteLine(isPalindrome);

        //    // Sum of the 2 linked lists. Single digit being at head.
        //    //int[] number1 = { 1, 2};
        //    //var numberList1 = p.BuildLinkedList(number1);

        //    //int[] number2 = { 0,0,0,9};
        //    //var numberList2 = p.BuildLinkedList(number2);
        //    //Node sumOf2Lists = p.SumTwoLists(numberList2, numberList1);
        //    //p.PrintLinkedList(sumOf2Lists);

        //    //Checking the length of the linked list.
        //    int length = p.FindLengthOfTheLinkedList(list);
        //    Console.WriteLine($"Length: {length}");

        //    Console.ReadKey();
        //}
    }
}
