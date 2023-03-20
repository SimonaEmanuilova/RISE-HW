using Tasks;


namespace TestTask2
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
            string actual = Task2.ReverseEveryWord(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReverseGivenTwoWords()
        {
            //Arrange
            string input = "Hello world";
            string expected = "olleH dlrow";


            //Act
            string actual = Task2.ReverseEveryWord(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReverseGivenThreeWords()
        {
            //Arrange
            string input = "What is this";
            string expected = "tahW si siht";


            //Act
            string actual = Task2.ReverseEveryWord(input);

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
            string actual = Task2.ReverseEveryWord(input);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}