using Tasks;


namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReverseGivenFiveLetterWord()
        {
            //Arrange
            string input = "Hello";
            string expected = "olleH";


            //Act
            string actual = Tasks.Task.Reverse(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReverseGivenOneLetterWord()
        {
            //Arrange
            string input = "H";
            string expected = "H";


            //Act
            string actual = Tasks.Task.Reverse(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReverseGivenEmptyString()
        {
            //Arrange
            string input = "";
            string expected = "";

            //Act
            string actual = Tasks.Task.Reverse(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}