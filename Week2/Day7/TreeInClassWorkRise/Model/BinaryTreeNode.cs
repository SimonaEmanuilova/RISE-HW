using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInClassWorkRise.Model
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value, BinaryTreeNode left, BinaryTreeNode right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public int Value { get; set; }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public bool IsLeaf()
        {
            return (Right == null && Left == null);
        }

    }
}
