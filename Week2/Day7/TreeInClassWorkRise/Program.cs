using System.Xml.Linq;
using TreeInClassWorkRise.Model;



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

            var binaryTree1 = new BinaryTreeNode(25, node11, node52);

            var bfs = new BreathFirstSearch();


            //simple checker tree
            var node3 = new BinaryTreeNode(3, null, null);
            var node4 = new BinaryTreeNode(4, null, null);
            var node2 = new BinaryTreeNode(2, node3, node4);
            var node5 = new BinaryTreeNode(5, null, null);
            var binaryTree2 = new BinaryTreeNode(1, node2, node5);

            List<int> preOrderList = new List<int>();
            Console.WriteLine("Pre Order:");
            PreOrder(binaryTree1, preOrderList);

            List<int> postOrderList = new List<int>();

            Console.WriteLine("Post Order:");
            PostOrder(binaryTree1, postOrderList);

            List<int> inOrderList = new List<int>();

            Console.WriteLine("In Order:");
            InOrder(binaryTree1, inOrderList);
        }
        
        public static List<int> PreOrder(BinaryTreeNode root, List<int> preOrderList)
        {

            if (root != null)
            {
                preOrderList.Add(root.Value);
                Console.WriteLine(root.Value);
                PreOrder(root.Left, preOrderList);
                PreOrder(root.Right, preOrderList);
            }

            return preOrderList;
        }

        public static List<int> PostOrder(BinaryTreeNode root, List<int> postOrderList)
        {


            if (root != null)

            {
                PostOrder(root.Left,postOrderList);
                PostOrder(root.Right, postOrderList);
                postOrderList.Add(root.Value);
                Console.WriteLine(root.Value);
            }

            return postOrderList;
        }

        public static List<int> InOrder(BinaryTreeNode root, List<int> inOrderList)
        {


            if (root != null)

            {
                InOrder(root.Left,inOrderList);
                inOrderList.Add(root.Value);
                Console.WriteLine(root.Value);
                InOrder(root.Right, inOrderList);
            }

            return inOrderList;
        }


    }
}