#define TESTING
using System;
using System.Collections.Generic;

/*
 * STUDENTS: Your answers (your code) goes into this file!!!!
 * 
  * NOTE: In addition to your answers, this file also contains a 'main' method, 
 *      in case you want to run a normal console application.
 * 
 * If you want to / have to put something into 'Main' for these PCEs, then put that 
 * into the Program.Main method that is located below, 
 * then select this project as startup object 
 * (Right-click on the project, then select 'Set As Startup Object'), then run it 
 * just like any other normal, console app: use the menu item Debug->Start Debugging, or 
 * Debug->Start Without Debugging
 * 
 */

namespace PCE_StarterProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            BinarySearchTree bst = new BinarySearchTree();

        }
    }
    public class BinarySearchTree
    {
        // Protected so that the BST_Verifier subclass can get at it
        // and verify that the tree looks right (for NUnit tests)
        // Normally this should be private.
        protected BSTNode top; // also (semi-)traditional to name this 'root', instead of 'top'

        // You should make the BSTNode class a nested class
        // Normally should be private; it's protected for the reasons explained above
        protected class BSTNode
        {
            public BSTNode Left;
            public BSTNode Right;
            public int Data;
            public BSTNode(int val)
            {
                Data = val;
            }
        }

        public void Add(int newValueToAdd)
        {
            if(top==null)
            {
                top = new BSTNode(newValueToAdd);
                return;
            }


            BSTNode cur = top;
            while (true)
            {
                if (newValueToAdd < cur.Data)
                {
                    if (cur.Left == null)
                    {
                        cur.Left = new BSTNode(newValueToAdd);
                        break;
                    }
                    else
                        cur = cur.Left;
                }
                else if (newValueToAdd > cur.Data)
                {
                    if (cur.Right == null)
                    {
                        cur.Right = new BSTNode(newValueToAdd);
                        break;
                    }
                    else
                        cur = cur.Right;
                }
                else
                    throw new Exception("No duplicates!");
            }
        }

        public bool Find(int target)
        {
            if (top == null)
                return false;
        
            BSTNode cur = top;
            while (cur != null)
            {
                if (target == cur.Data)
                    return true;
                else if (target < cur.Data)
                    cur = cur.Left;
                else
                    cur = cur.Right;
            }

            return false;
        }

        public void Print()
        {
            if (top == null)
                return;

            Print(top);

        }
        private void Print(BSTNode cur)
        {
            if (cur.Left != null)
                Print(cur.Left);

            Console.WriteLine(cur.Data);

            if (cur.Right != null)
                Print(cur.Right);


        }


        public void PrintIterative()
        {
            Stack<BSTNode> s = new Stack<BSTNode>();
            Console.WriteLine("PRINT IS NOT YET IMPLEMENTED!!!!\nYou need to implement this method, iteratively (using a loop)!");
        }


        public bool FindR(int target)
        {
            if (top == null)
                return false;

           return FindR(target, top);
           
            
        }
    
        private bool FindR(int target, BSTNode cur)
        {

            if (cur.Data ==target)
                return true;

            if (target < cur.Data)
                if (cur.Left != null)
                    return FindR(target, cur.Left);
                else
                    return false;
            if (target > cur.Data)
                if (cur.Right != null)
                    return FindR(target, cur.Right);
                else
                    return false;
            

            return false;
        }

        public void AddR(int newValueToAdd)
        {
            BSTNode temp = new BSTNode(newValueToAdd);

            if (top == null)
            {
                top = temp;
                return;
            }
            AddR(top, temp);

                    
        }
        private void AddR(BSTNode cur, BSTNode nodeToAdd)
        {
            if (nodeToAdd.Data > cur.Data)
            {
                if (cur.Right == null)
                {
                    cur.Right = nodeToAdd;
                    return;
                }
                AddR(cur.Right, nodeToAdd);
                return;
            }
            if (nodeToAdd.Data < cur.Data)
            {
                if(cur.Left == null)
                {
                    cur.Left = nodeToAdd;
                    return;
                }
                AddR(cur.Left, nodeToAdd);
                return;
            }
           
            throw new Exception("Duplicate found!");
        }

        public void PrintBeneathNode(int target)
        {
            Console.WriteLine("NOT YET IMPLEMENTED");
            return;

        }
    }
}