using SmallTasks;

namespace UnitTestSmallTask2
{
    [TestClass]
    public class UnitTestSmallTask2
    {
        [TestMethod]
        public void TestIfTypeIsBool()
        {
            // Arrange
            int n = 5;

            // Assert
            Assert.AreEqual(typeof(bool), SmallTasks.SmallTask2.IsOdd(n).GetType());
        }

        [TestMethod]
        public void TestOutputGivenOddNumber()
        {
            // Arrange
            bool isOddCheck = SmallTasks.SmallTask2.IsOdd(7);

            // Assert
            Assert.IsTrue(isOddCheck, "7 should be odd.");

        }

        [TestMethod]
        public void TestOutputGivenEvenNumber()

        {
            // Arrange
            bool isOddCheck = SmallTasks.SmallTask2.IsOdd(6);

            // Assert
            Assert.IsFalse(isOddCheck, "6 should be even.");

        }

    }
}
