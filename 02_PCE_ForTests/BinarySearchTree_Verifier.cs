using System;
using System.IO; // For the Console.Out stuff
using System.Text; // For StringBuilder

using NUnit.Framework;

/*
 * This file contains helper classes for the tests.  It does NOT contain any tests itself.
 * 
 * These helper routines are put here, in a separate file, so that it's easy to
 * copy-and-paste this single file between all the different starter projects that get
 * handed out, and yet still have a single, coherent copy of the code.
 * (Yeah, there's probably a better way to do this, but I wanted to keep things simple
 * for y'all :)  )
 */

namespace PCE_StarterProject
{
    public class BinarySearchTree_Verifier : BinarySearchTree
    {
        private string errorMessage = "";

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="serializedTree"></param>
        /// <returns>True, if the tree matches what's in the array
        ///         False otherwise (including if the array is null)</returns>
        public bool ValidateTree(int[] serializedTree)
        {
            Console.WriteLine("Beginning tree validation");

            if (serializedTree == null)
                return false; // probably an error in the test, but better to notice
            // an extra failure than to pass a bad test

            if (serializedTree.Length == 0 && this.top == null)
                return true;
            else
            {
                Console.WriteLine("top node: " + top.Data);
                return ValidateTree(this.top, serializedTree, 0);
            }
        }
        /// <summary>
        /// index 0 == top of tree
        /// index 1 = left child of 0
        /// index 2 = right child of 0
        /// index 3 = left child of 1
        /// index 4 = right child of 1
        /// index 5 = left child of 2
        /// index 6 = right child of 2
        /// therefore - 
        /// index left child = ( (index of current + 1) * 2  ) - 1
        /// index right child = ( (index of current + 1) * 2  )
        /// 
        /// Note that extra array slots (added so that there can be a node w/o children, 
        /// yet still have other nodes at that level) contain Int32.MinValue.  They're ignored
        /// in this code
        /// 
        /// </summary>
        /// <param name="cur">This must NOT be null</param>
        /// <param name="serializedTree"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private bool ValidateTree(BinarySearchTree.BSTNode cur, int[] serializedTree, int nodeNum)
        {
            Console.WriteLine("Current node: " + cur.Data + " nodeNum: " + nodeNum + " value@nodeNum: " + serializedTree[nodeNum]);

            if (cur.Data != serializedTree[nodeNum] ||
                serializedTree[nodeNum] == Int32.MinValue)
            {
                errorMessage = "Expected node #" + nodeNum + " to have the Data value " + serializedTree[nodeNum] + ", but actually found " + cur.Data + " instead";
                return false;
            }

            if (cur.Left != null &&
                ValidateTree(cur.Left, serializedTree, ((nodeNum + 1) * 2) - 1) == false)
                return false;

            if (cur.Right != null)
                return ValidateTree(cur.Right, serializedTree, ((nodeNum + 1) * 2));

            // this node is ok, any left/right children are ok, so this subtree is ok
            // return true to indicate that everything matches
            return true;
        }
    }
}