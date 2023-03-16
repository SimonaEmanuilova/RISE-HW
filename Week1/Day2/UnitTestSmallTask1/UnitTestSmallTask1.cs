using SmallTasks;

namespace UnitTestSmallTasks
{
    [TestClass]
    public class UnitTestSmallTask1
    { 
        [TestMethod]
        public void TestIfMaxValueTypeIsInt()
        {
            // Arrange
            int MaxNumber = SmallTasks.SmallTask1.Main();

            // Assert
            Assert.AreEqual(typeof(int), MaxNumber.GetType());
        }

        [TestMethod]
        public void TestMaxValueGivenActualMaxValue()
        {
            // Arrange
            int actualMaxNumber = int.MaxValue;
            int expectedMaxNumber;    
            
            // Act
             expectedMaxNumber = SmallTasks.SmallTask1.Main();

            // Assert
            Assert.AreEqual(expectedMaxNumber, actualMaxNumber);
        }

        [TestMethod]
        public void TestMaxValueGivenNumberGreaterThanMaxValue()
        {
            // Arrange
            int expectedMaxNumber = SmallTasks.SmallTask1.Main();
            int overload;

            // Act
            overload=expectedMaxNumber + 2;

            // Assert
            Assert.AreEqual(int.MaxValue, Math.Abs(overload));
        }

    }
}
