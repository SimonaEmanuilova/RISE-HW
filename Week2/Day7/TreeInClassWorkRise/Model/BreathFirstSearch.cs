using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInClassWorkRise.Model
{
    internal class BreathFirstSearch
    {
        public void Search(BinaryTreeNode root)
        {
            var elementsToTraverse = new Queue<BinaryTreeNode>();

            elementsToTraverse.Enqueue(root);

            while (elementsToTraverse.Count > 0)
            {
                var currentNode = elementsToTraverse.Dequeue();

                Console.WriteLine(currentNode.Value);

                if (currentNode.Left != null)
                {
                    elementsToTraverse.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    elementsToTraverse.Enqueue(currentNode.Right);
                }
            }
        }
    }
}
