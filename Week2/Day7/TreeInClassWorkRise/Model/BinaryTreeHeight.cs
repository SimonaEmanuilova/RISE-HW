namespace Day7Trees.Model
{
    public class BinaryTreeHeight
    {
       
        public static int CalcBinaryTreeHeight(BinaryTreeNode root)
        {
            ;
            if (root == null)
            {
                return 0;
            }
            else if (IsNodeLeaf(root))
            {
                return 0;
            }
            ;
            int heightRight = CalcBinaryTreeHeight(root.Right);
            ;
            int heightLeft = CalcBinaryTreeHeight(root.Left);
            ;
            int maxHeight = Math.Max(heightRight, heightLeft);

            return 1 + maxHeight;
        }

        public static bool IsNodeLeaf(BinaryTreeNode root)
        {
            return (root.Right == null && root.Left == null);
        }
        

    }
}
