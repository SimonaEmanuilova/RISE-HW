
using Day7Trees.Model;


namespace UnitTestsDay7
{
    public static class InputTree
    {
        public static BinaryTreeNode binaryTree;

        static InputTree()
        {
            var node76 = new BinaryTreeNode(76, null, null);
            var node61 = new BinaryTreeNode(61, null, null);
            var node69 = new BinaryTreeNode(69, node61, node76);

            var node35 = new BinaryTreeNode(35, null, null);
            var node38 = new BinaryTreeNode(38, node35, null);
            var node52 = new BinaryTreeNode(52, node38, node69);

            var node24 = new BinaryTreeNode(24, null, null);
            var node11 = new BinaryTreeNode(11, null, node24);

            binaryTree = new BinaryTreeNode(25, node11, node52);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPreOrder()
        {
            var traversal = new Traversal();
            List<int> expected = new List<int>() { 25, 11, 24, 52, 38, 35, 69, 61, 76 };

            traversal.PreOrder(InputTree.binaryTree);

            Assert.IsTrue(expected.SequenceEqual(traversal.Values));

        }

        [TestMethod]
        public void TestPostOrder()
        {
            var traversal = new Traversal();
            List<int> expected = new List<int>() { 24, 11, 35, 38, 61, 76, 69, 52, 25 };

            traversal.PostOrder(InputTree.binaryTree);

            Assert.IsTrue(expected.SequenceEqual(traversal.Values));

        }

        [TestMethod]
        public void TestInOrder()
        {
            var traversal = new Traversal();
            List<int> expected = new List<int>() { 11, 24, 25, 35, 38, 52, 61, 69, 76 };

            traversal.InOrder(InputTree.binaryTree);

            Assert.IsTrue(expected.SequenceEqual(traversal.Values));

        }

        [TestMethod]
        public void TestBinaryTreeHeight()
        {
            int expected = 3;
            int actual = BinaryTreeHeight.CalcBinaryTreeHeight(InputTree.binaryTree);

            Assert.AreEqual(expected, actual);
        }




    }
}