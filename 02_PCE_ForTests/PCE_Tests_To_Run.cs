using System;
using NUnit.Framework;

/*
 * This file contains all the tests that will be run.
 * 
 * If you want to find out what a test does (or why it's failing), look in here
 * 
 */

namespace PCE_StarterProject
{

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_BST_Print_Recursive : TestHelpers
    {
        BinarySearchTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree();
        }

        // Basic Test Cases:
        //
        //  * Printing an empty tree, 
        //  * Printing a tree with a single element, 
        //  * Printing a balanced tree
        //  * Printing a tree that has more elements on the left (is "left-heavy")
        //  * Printing a tree that has more elements on the right (is "right-heavy")


        [Test]
        [Category("BST Print Recursive")]
        public void PrintEmptyTree()
        {
            string rightAnswer = "";

            StartOutputCapturing();
            tree.Print();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "An empty tree should produce no output, instead it produced \"" + sOut + "\"");
        }

        [Test]
        [Category("BST Print Recursive")]
        public void PrintSingletonTree()
        {
            string rightAnswer = "20";

            tree.Add(20);

            StartOutputCapturing();
            tree.Print();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Recursive")]
        public void PrintBalancedTree()
        {
            string rightAnswer = "1\n\n5\r\n\r\n7\n20\n22\n25\n30";

            tree.Add(20);
            tree.Add(5);
            tree.Add(25);
            tree.Add(1);
            tree.Add(7);
            tree.Add(22);
            tree.Add(30);

            StartOutputCapturing();
            tree.Print();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Recursive")]
        public void PrintLeftHeavyTree()
        {
            string rightAnswer = "1\n\n5\r\n\r\n7\n20\n25";

            tree.Add(20);
            tree.Add(5);
            tree.Add(25);
            tree.Add(1);
            tree.Add(7);

            StartOutputCapturing();
            tree.Print();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Recursive")]
        public void PrintRightHeavyTree()
        {
            string rightAnswer = "7\n20\n22\n25\n30";

            tree.Add(20);
            tree.Add(7);
            tree.Add(25);
            tree.Add(22);
            tree.Add(30);

            StartOutputCapturing();
            tree.Print();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_BST_Find_Recursive : TestHelpers
    {
        BinarySearchTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree();
            tree.Add(1000);
            tree.Add(500);
            tree.Add(1500);
            tree.Add(100);
            tree.Add(300);
        }

        [Test]
        [Category("BST Find Recursive")]
        public void Find_Present([Values(1000, 500, 1500, 100, 300)]int targetThatIsPresentInTheTree)
        {
            Assert.That(tree.FindR(targetThatIsPresentInTheTree),
                "Unable to find " + targetThatIsPresentInTheTree + ", despite the fact that the value is in the tree!");
        }

        [Test]
        [Category("BST Find Recursive")]
        public void Find_Absent([Values(1001, -500, 150000, 1400, 600, 99, 199, 301)]int targetThatIsNOTPresentInTheTree)
        {
            Assert.That(false == tree.FindR(targetThatIsNOTPresentInTheTree),
                "Somehow found " + targetThatIsNOTPresentInTheTree + ", despite the fact that the value is NOT in the tree!");
        }

        [Test]
        [Category("BST Find Recursive")]
        public void Find_In_Empty_Tree()
        {
            tree = new BinarySearchTree();
            int target = 10;
            Assert.That(false == tree.FindR(target),
                "Somehow found " + target + ", despite the fact that the tree is empty!");
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_BST_Add_Recursive : TestHelpers
    {
        // By using this 'Verifier" subclass, we can make use of the ValidateTree method
        // ValidateTree can access the proteced members of the BST, most importantly
        // the BST nodes themselves.  Therefore, it can verify that the actual 
        // STRUCTURE of the tree is correct (not just that it prints out the right thing)
        BinarySearchTree_Verifier tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree_Verifier();
        }

        const int BLANK = Int32.MinValue; // easier to read :)
        [TestCase(new int[] { 100 })]
        [TestCase(new int[] { 100, 50 })]
        [TestCase(new int[] { 100, BLANK, 200 })]
        [TestCase(new int[] { 100, 50, 200 })]
        [TestCase(new int[] { 100, 50, 200, BLANK, BLANK, BLANK, 250 })]
        [TestCase(new int[] { 100, 50, 200, BLANK, BLANK, 150, 250 })]
        [TestCase(new int[] { 100, 50, 200, 20, 75, 150, 250 })]
        [Category("BST Add Recursive")]
        public void Add_Values(int[] valuesToAdd)
        {
            for (int i = 0; i < valuesToAdd.Length; i++)
                if (valuesToAdd[i] != BLANK)
                    tree.AddR(valuesToAdd[i]);

            Console.WriteLine("The tree:");
            tree.Print();
            Console.WriteLine("The array:");
            PrintArray(valuesToAdd);

            bool result = tree.ValidateTree(valuesToAdd);
            Assert.That(result == true, "Problem verifying tree for test case " + Array_ToString(valuesToAdd) +
                "Error message: " + tree.ErrorMessage);
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_IGNORE_DESC)] // this exercise will NOT be graded
    public class NUnit_Tests_BST_Print_Beneath_Node : TestHelpers
    {
        BinarySearchTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree();
            tree.Add(10);
            tree.Add(12);
            tree.Add(5);
            tree.Add(1);
            tree.Add(7);
            tree.Add(2);
        }

        [Test]
        [Category("BST PrintBeneathNode")]
        public void PrintTree( [Values(1, 5, 7, 12, 15)]int target)
        {
            string rightAnswer = "";
            switch (target)
            {
                case 1:
                    rightAnswer = "1\n2";
                    break;
                case 5:
                    rightAnswer = "1\n2\n5\n7";
                    break;
                case 7:
                    rightAnswer = "7";
                    break;
                case 12:
                    rightAnswer = "12";
                    break;
                case 15:
                    rightAnswer = "";
                    break;
            }

            StartOutputCapturing();
            tree.PrintBeneathNode(target);
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should produce no output, instead it produced \"" + sOut + "\"");
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_IGNORE_DESC)] // this exercise will NOT be graded
    public class NUnit_Tests_BST_Print_Iterative : TestHelpers
    {
        BinarySearchTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree();
        }

        // Basic Test Cases:
        //
        //  * Printing an empty tree, 
        //  * Printing a tree with a single element, 
        //  * Printing a balanced tree
        //  * Printing a tree that has more elements on the left (is "left-heavy")
        //  * Printing a tree that has more elements on the right (is "right-heavy")


        [Test]
        [Category("BST Print Iterative")]
        public void PrintEmptyTree()
        {
            string rightAnswer = "";

            StartOutputCapturing();
            tree.PrintIterative();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "An empty tree should produce no output, instead it produced \"" + sOut + "\"");
        }

        [Test]
        [Category("BST Print Iterative")]
        public void PrintSingletonTree()
        {
            string rightAnswer = "20";

            tree.Add(20);

            StartOutputCapturing();
            tree.PrintIterative();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Iterative")]
        public void PrintBalancedTree()
        {
            string rightAnswer = "1\n\n5\r\n\r\n7\n20\n22\n25\n30";

            tree.Add(20);
            tree.Add(5);
            tree.Add(25);
            tree.Add(1);
            tree.Add(7);
            tree.Add(22);
            tree.Add(30);

            StartOutputCapturing();
            tree.PrintIterative();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Iterative")]
        public void PrintLeftHeavyTree()
        {
            string rightAnswer = "1\n\n5\r\n\r\n7\n20\n25";

            tree.Add(20);
            tree.Add(5);
            tree.Add(25);
            tree.Add(1);
            tree.Add(7);

            StartOutputCapturing();
            tree.PrintIterative();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }

        [Test]
        [Category("BST Print Iterative")]
        public void PrintRightHeavyTree()
        {
            string rightAnswer = "7\n20\n22\n25\n30";

            tree.Add(20);
            tree.Add(7);
            tree.Add(25);
            tree.Add(22);
            tree.Add(30);

            StartOutputCapturing();
            tree.PrintIterative();
            string sOut = StopOutputCapturing();

            Assert.That(EqualsFuzzyString(sOut, rightAnswer), "Printing the tree should have produced\n" + rightAnswer + "\nInstead it produced\n" + sOut);
        }
    }
}