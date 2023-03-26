namespace Day7Trees.Model
{
    public class Traversal
    {
        public Traversal()
        {
            this.Values = new List<int>();

        }
        public List<int> Values { get; set; }
        public void PreOrder(BinaryTreeNode root)
        {

            if (root != null)
            {
                Values.Add(root.Value);
                Console.Write("" + root.Value);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }

        }

        public void PostOrder(BinaryTreeNode root)
        {

            if (root != null)

            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Values.Add(root.Value);
                Console.Write("" + root.Value);
            }

        }

        public void InOrder(BinaryTreeNode root)
        {
            if (root != null)

            {
                InOrder(root.Left);
                Values.Add(root.Value);
                Console.Write("" + root.Value);
                InOrder(root.Right);
            }
        }


    }


   
}
