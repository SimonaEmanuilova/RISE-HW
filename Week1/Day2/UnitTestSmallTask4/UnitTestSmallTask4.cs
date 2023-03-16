using SmallTasks;

namespace UnitTestSmallTasks
{
    [TestClass]
    public class UnitTestSmallTask4
    {
        [TestMethod]
        public void TestWhenGivenSameNumbers()
        {
            int[] arr = { 7, 4, 3, 3, 8 };

            int min = SmallTask4.Min(arr);

            Assert.AreEqual(3, min);
        }

        [TestMethod]
        public void TestWhenGivenPositiveNumbers()
        {
            int[] arr = { 77, 4, 9, 3, 17 };

            int min = SmallTask4.Min(arr);

            Assert.AreEqual(3, min);
        }

        [TestMethod]
        public void TestWhenGivenNegativeNumbers()
        {

            int[] arr = { -5, -2, -8, -1, -9 };

            int min = SmallTask4.Min(arr);

            Assert.AreEqual(-9, min);
        }

    }
}
