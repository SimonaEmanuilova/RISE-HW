using FindMissingNumber;

namespace TestFibonacciTask
{
    [TestClass]
    public class TestFibonacciMatrix
    {
        [TestMethod]
        public void TestFindMissingNumber1GivenPassingInput()
        {
            // Arrange
            int[] inputArr = { 103, 101 };
            int predicted = 102;

            //Act 
            int actual = Program.FindMissingNumber1(inputArr);    

            // Assert
            Assert.AreEqual(predicted, actual);

        }


        [TestMethod]
        public void TestFindMissingNumber1Given0()
        {
            // Arrange
            int[] inputArr = { 0 };

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindMissingNumber1(inputArr), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindMissingNumber1Given1()
        {
            // Arrange
            int[] inputArr = { 1 };

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindMissingNumber1(inputArr), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindMissingNumber2GivenPassingInput()
        {
            // Arrange
            int[] inputArr = { 103, 101 };
            int predicted = 102;

            //Act 
            int actual = Program.FindMissingNumber2(inputArr);

            // Assert
            Assert.AreEqual(predicted, actual);

        }

        [TestMethod]
        public void TestFindMissingNumber2Given0()
        {
            // Arrange
            int[] inputArr = { 0 };

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindMissingNumber2(inputArr), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindMissingNumber2Given1()
        {
            // Arrange
            int[] inputArr = { 1 };

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindMissingNumber2(inputArr), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindRoot3GivenPassingInput()
        {
            // Arrange
            int num = 27;
            int predicted = 3;
            int actual = Program.FindRoot3(num);


            // Assert
            Assert.AreEqual(predicted, actual);
        }


        [TestMethod]
        public void TestFindRoot3GivenNegativeNum()
        {
            // Arrange
            int num = -27;

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindRoot3(num), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindRoot3GivenNotPerfectCube()
        {
            // Arrange
            int num = 26;

            // Act and Assert
            Assert.ThrowsException<Exception>(() => Program.FindRoot3(num), "Expected exception was not thrown.");
        }

        [TestMethod]
        public void TestFindRoot3Given0()
        {
            // Arrange
            int num = 0;
            int predicted = 0;
            int actual = Program.FindRoot3(num);


            // Assert
            Assert.AreEqual(predicted, actual);
        }

        [TestMethod]
        public void TestFindRoot3Given1()
        {
            // Arrange
            int num = 1;
            int predicted = 1;
            int actual = Program.FindRoot3(num);


            // Assert
            Assert.AreEqual(predicted, actual);
        }

    }
}