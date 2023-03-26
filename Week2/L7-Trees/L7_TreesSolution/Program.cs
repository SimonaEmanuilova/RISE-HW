using System.Xml.Linq;
using Day7Trees.Model;


namespace Day7Trees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var node76 = new BinaryTreeNode(76, null, null);
            var node61 = new BinaryTreeNode(61, null, null);
            var node69 = new BinaryTreeNode(69, node61, node76);

            var node35 = new BinaryTreeNode(35, null, null);
            var node38 = new BinaryTreeNode(38, node35, null);
            var node52 = new BinaryTreeNode(52, node38, node69);

            var node24 = new BinaryTreeNode(24, null, null);
            var node11 = new BinaryTreeNode(11, null, node24);

            var binaryTree = new BinaryTreeNode(25, node11, node52);

            var traversal =new Traversal();

            Console.WriteLine("\nPre Order: ");
            traversal.PreOrder(binaryTree);
            traversal.Values.Clear();
           
            Console.WriteLine("\n\nPost Order: ");
            traversal.PostOrder(binaryTree);
            traversal.Values.Clear();

            Console.WriteLine("\n\nIn Order: ");
            traversal.InOrder(binaryTree);
            traversal.Values.Clear();
           

            int heightResult = BinaryTreeHeight.CalcBinaryTreeHeight(binaryTree);
            Console.WriteLine("\n\nHeight: " + heightResult);
        }

    }
}