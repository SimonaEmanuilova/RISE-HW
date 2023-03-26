using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace L8_GraphSolution.Graphs
{
    public class Graph
    {
        public int VertexCount { get; set; }
        List<List<int>> Matrix { get; set; }

        public Graph(int count)
        {

            VertexCount = count;
            Matrix = new List<List<int>>();

            for (int i = 0; i < VertexCount; i++)
            {

                Matrix.Add(new List<int>());
                for (int j = 0; j < VertexCount; j++)
                {
                    Matrix[i].Add(0);
                }
            }
        }
        public void AddEdge(int start, int end)
        {
            Matrix[start][end] = 1;
            Matrix[end][start] = 1;
        }

        public void DFSIterative(int start)
        {
            Stack<int> orderedNodes = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();

            orderedNodes.Push(start);

            while (orderedNodes.Count > 0)
            {

                var current = orderedNodes.Pop();
                visited.Add(current);
                Console.WriteLine(current);

                for (int i = 0; i < VertexCount; i++)
                {
                    if (Matrix[current][i] == 1 && !visited.Contains(i))
                    {  // if it has a peak and it is not yet visited:
                        orderedNodes.Push(i);
                    }

                }
            }
        }

        public bool DFSHasCycle()
        {
            Stack<int> orderedNodes = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            int[] parentNodeArr = new int[VertexCount];

            for (int k = 0; k < VertexCount; k++)  //to iterate the DFS through all nodes as starting points
            {
                if (visited.Contains(k))
                { 
                    continue; 
                }

                orderedNodes.Push(k);
                visited.Add(k);

                while (orderedNodes.Count > 0)  //using the iterative DFS from the example in class
                {
                    int current = orderedNodes.Pop();

                    for (int i = 0; i < VertexCount; i++)
                    {
                        if (Matrix[current][i] == 1)
                        {
                            int neighbor = i;
                            if (visited.Contains(neighbor) && parentNodeArr[current] != neighbor)
                            {
                                return true;
                            }
                            else if (!visited.Contains(neighbor))
                            {
                                orderedNodes.Push(neighbor);
                                visited.Add(neighbor);
                                parentNodeArr[neighbor] = current;
                            }
                        }
                    }
                }

            }

            return false;
        }
    }

}

