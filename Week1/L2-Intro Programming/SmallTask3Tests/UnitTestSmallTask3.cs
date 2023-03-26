using SmallTasks;

namespace UnitTestSmallTasks
{
    [TestClass]
    public class UnitTestSmallTask3
    {
        [TestMethod]
        public void TestIfTypeIsBool()
        {
            // Arrange
            int n = 4;

            // Assert
            Assert.AreEqual(typeof(bool), SmallTasks.SmallTask3.IsNumberPrime(n).GetType());
        }

        [TestMethod]
        public void TestWhenGivenPrime()
        {
             // Arrange
            int n = 83;
            bool isPrimeCheck = SmallTasks.SmallTask3.IsNumberPrime(n);

            // Assert
            Assert.IsTrue(isPrimeCheck, "83 should be prime.");
        }

        [TestMethod]
        public void TestWhenGivenNotPrime()
        {
            // Arrange
            int n = 85;
            bool isPrimeCheck = SmallTasks.SmallTask3.IsNumberPrime(n);

            // Assert
            Assert.IsFalse(isPrimeCheck, "85 should not be prime.");
        }

    }
}
