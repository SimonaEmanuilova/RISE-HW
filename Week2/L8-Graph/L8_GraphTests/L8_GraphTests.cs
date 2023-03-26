using L8_GraphSolution.Graphs;

namespace UnitTestsDay8Graphs
{
    [TestClass]
    public class L8_GraphTests
    {
        [TestMethod]
        public void TestHasCycleGivenNoCycleGraph()
        {
            //           0
            //         / | \
            //        1  2  3
            //               \
            //                4

            // Arrange and Act
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);

            bool expected = false;
            bool actual = graph.DFSHasCycle();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHasCycleGivenCycleGraph()
        {
            //           0
            //         / |  \
            //        1  2 - 3
            //                \
            //                 4

            // Arrange and Act
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 3);

            bool expected = true;
            bool actual = graph.DFSHasCycle();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHasCycleGivenTwoCycleGraph()
        {
            //           0
            //        /  |  \
            //       1 - 2 - 3
            //                \
            //                 4

            // Arrange and Act
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(1, 2);

            bool expected = true;
            bool actual = graph.DFSHasCycle();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHasCycleGivenOuterCycleGraph()
        {
            //           0
            //        /  |  \
            //       1   2   3
            //            \    \
            //              - - 4

            // Arrange and Act
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 4);

            bool expected = true;
            bool actual = graph.DFSHasCycle();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}