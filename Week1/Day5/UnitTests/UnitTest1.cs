using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Day5;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestUniqueNumberGiven1SameNumber()
    {
        // Arrange
        List<int> input = new List<int>() { 4, 5, 2, 3, 2 };

        // Assert
        CollectionAssert.AllItemsAreUnique(Day5Tasks.GetUniqueNumbers(input));
    }

    [TestMethod]
    public void TestUniqueNumberGivenAllSameNumbers()
    {
        // Arrange
        List<int> input = new List<int>() { 2, 2, 2, 2, 2 };
        List<int> expected = new List<int>() { 2 };

        // Assert
        Assert.IsTrue(expected.SequenceEqual(Day5Tasks.GetUniqueNumbers(input)));
    }

    [TestMethod]
    public void TestRemoveMiddleNumberOddList()
    {
        // Arrange
        LinkedList<int> input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        LinkedList<int> expected = new LinkedList<int>(new[] { 1, 2, 4, 5 });

        //Act
        Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.IsTrue(expected.SequenceEqual(input));
    }

    [TestMethod]
    public void TestRemoveMiddleNumberEvenList()
    {
        // Arrange
        LinkedList<int> input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6 });
        LinkedList<int> expected = new LinkedList<int>(new[] { 1, 2, 3, 5, 6 });

        //Act
        Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.IsTrue(expected.SequenceEqual(input));
    }

    [TestMethod]
    public void TestIsMiddleNumberRemovedGivenEvenList()
    {
        // Arrange and Act
        LinkedList<int> input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6 });
        bool expected = true;
        bool actual = Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsMiddleNumberRemovedGivenOddList()
    {
        // Arrange and Act
        LinkedList<int> input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        bool actual = Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.AreEqual(true, actual);
    }

    [TestMethod]
    public void TestIsMiddleNumberRemovedGiven2NumberList()
    {
        // Arrange
        LinkedList<int> input = new LinkedList<int>(new[] { 1, 2 });

        //Act
        bool isRemoved = Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.AreEqual(false, isRemoved);
    }

    [TestMethod]
    public void TestIsMiddleNumberRemovedGivennEmptyList()
    {
        // Arrange
        LinkedList<int> input = new LinkedList<int>();

        //Act
        bool isRemoved = Day5Tasks.RemoveMiddleNumber(input);

        // Assert
        Assert.AreEqual(false, isRemoved);
    }

    [TestMethod]
    public void TestRemoveMiddleNumberGivenNullInput()
    {
        // Arrange and Assert
        Assert.ThrowsException<NullReferenceException>(() => Day5Tasks.ExpressionExpansion(null));
    }

    [TestMethod]
    public void TestHanoiTowersIfIsSuccessfullySolved()
    {
        // Arrange
        bool expected = true;
        bool actual = Day5Tasks.HanoiTower(3);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestExpressionExpansionGiven1Letter()
    {
        // Arrange
        string expected = "A";
        string actual = Day5Tasks.ExpressionExpansion("A");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestExpressionExpansionGiven1Number()
    {
        // Arrange
        string input = "1";

        // Assert
        Assert.ThrowsException<ArgumentException>(() => Day5Tasks.ExpressionExpansion(input));
    }

    [TestMethod]
    public void TestExpressionExpansionGiven3Letters()
    {
        // Arrange
        string expected = "ABC";
        string actual = Day5Tasks.ExpressionExpansion("ABC");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestExpressionExpansionGiven1NumberAnd3Letters()
    {
        // Arrange
        string expected = "AAABC";
        string actual = Day5Tasks.ExpressionExpansion("3ABC");

        // Assert
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void TestExpressionExpansionGiven2NumbersAnd3Letters()
    {
        // Arrange
        string expected = "AAABBC";
        string actual = Day5Tasks.ExpressionExpansion("3A2BC");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestExpressionExpansionGivenNumbersAndBracketsAndLetters()
    {
        // Arrange
        string expected = "AAABCBC";
        string actual = Day5Tasks.ExpressionExpansion("3A2(BC)");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestExpressionExpansionGivenNumbersAnd2BracketsAndLetters()
    {
        // Arrange
        string expected = "ABBBBeAAA";
        string actual = Day5Tasks.ExpressionExpansion("A4(B)e3(A)");

        // Assert
        Assert.AreEqual(expected, actual);
    }
}