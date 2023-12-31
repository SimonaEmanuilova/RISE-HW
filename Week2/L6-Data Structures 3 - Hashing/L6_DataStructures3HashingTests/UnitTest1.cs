using System.Collections;
using System.Collections.Generic;
using Day6;

namespace UnitTestDay6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTestManageCarToOwnerGivenOwnersWith1Car()
        {
            // Arrange
            Hashtable input = new Hashtable
            {
                { "H3035AM", "Stoyan Stoyanov" },
                { "H2065AM", "Ivan Petrov" },
                { "A42035AM", "Viktor Gusterov" },
                { "G5034AM", "Dilyana Gocheva" }
            };

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Day6Hashing.ManageCarNumberToOwner(input));
        }

        [TestMethod]
        public void TestTestManageCarToOwnerGiven2OwnersWithMultipleCars()
        {
            // Arrange
            Hashtable input = new Hashtable
            {
                { "H3035AM", "Stoyan Stoyanov" },
                { "CB2035AM", "Ivan Petrov" },
                { "H2065AM", "Ivan Petrov" },
                { "A42035AM", "Viktor Gusterov" },
                { "H5034AM", "Dilyana Gocheva" },
                { "G5034AM", "Dilyana Gocheva" }
            };
            HashSet<string> expected = new HashSet<string> { "Ivan Petrov", "Dilyana Gocheva" };

            //Act
            HashSet<string> real = Day6Hashing.ManageCarNumberToOwner(input);


            // Assert
            CollectionAssert.AreEquivalent(expected.ToList(), real.ToList());
        }

        [TestMethod]
        public void TestHumanWithCoolestNameGivenAnExistingPlateNumber()
        {
            // Arrange
            Hashtable inputHT = new Hashtable
            {
                { "H3035AM", "Stoyan Stoyanov" },
                { "CB2035AM", "Ivan Petrov" },
                { "H2065AM", "Ivan Petrov" },
                { "A42035AM", "Viktor Gusterov" },
                { "H5034AM", "Dilyana Gocheva" },
                { "G5034AM", "Dilyana Gocheva" }
            };
            string plateNumber = "H3035AM";
            string expected = "Stoyan Stoyanov";

            // Act and Assert
            Assert.IsTrue(expected.SequenceEqual(Day6Hashing.HumanWithCoolestPlate(inputHT, plateNumber)));
        }

        [TestMethod]
        public void TestHumanWithCoolestPlateGivenNonExistingPlate()
        {
            // Arrange
            Hashtable input = new Hashtable
            {
                { "H3035AM", "Stoyan Stoyanov" },
                { "H2065AM", "Ivan Petrov" },
                { "A42035AM", "Viktor Gusterov" },
                { "G5034AM", "Dilyana Gocheva" }
            };
            string nonExistingPlateNumber = "AAAAAAA";

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Day6Hashing.HumanWithCoolestPlate(input, nonExistingPlateNumber));
        }


        [TestMethod]
        public void TestFindIntersectionGivenNormalInput()
        {
            // Arrange
            int[] arr1 = new int[] { 1, 2, 9, 3, 4 };
            int[] arr2 = new int[] { 1, 3, 5, 2, 7 };

            int[] expected = new int[] { 1, 2, 3 };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected, Day6Hashing.FindIntersection(arr1, arr2));
        }

        [TestMethod]
        public void TestFindIntersectionGivenNoIntersection()
        {
            // Arrange
            int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr2 = new int[] { 6, 7, 8, 9, 10 };

            int[] expected = new int[] { };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected, Day6Hashing.FindIntersection(arr1, arr2));
        }

        [TestMethod]
        public void TestFindNonRepeatingCharsGivenRepeatingChar()
        {
            // Arrange
            string input = "hello";
            List<char> expected = new List<char>() { 'h', 'e', 'o' };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected.ToList(), Day6Hashing.FindNonRepeatingChars(input));
        }

        [TestMethod]
        public void TestFindNonRepeatingCharsGivenNonRepeatingChar()
        {
            // Arrange
            string input = "helo";
            List<char> expected = new List<char>() { 'h', 'e', 'l', 'o' };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected.ToList(), Day6Hashing.FindNonRepeatingChars(input));
        }

        [TestMethod]
        public void TestFindNonRepeatingCharsGivenOnlyRepeatingChar()
        {
            // Arrange
            string input = "hheelloo";
            List<char> expected = new List<char>() { };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected.ToList(), Day6Hashing.FindNonRepeatingChars(input));
        }

        [TestMethod]
        public void TestFirstNonRepeatingGivenRepeatingChar()
        {
            // Arrange
            string input = "hello";
            List<char> nonRepeatingChars = new List<char>() { 'h', 'e', 'o' };
            int expectedIndex = 0;

            // Act and Assert
            Assert.AreEqual(expectedIndex, Day6Hashing.FirstNonRepeating(nonRepeatingChars, input));
        }

        [TestMethod]
        public void TestSpellCheckerGivenWrongWord()
        {
            // Arrange
            HashSet<string> dictionaryExample = new HashSet<string>() { "this", "is", "a", "test" };
            string wrongSentence = "This is a tessst";
            List<string> expected = new List<string>() { "tessst" };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected.ToList(), Day6Hashing.SpellChecker(dictionaryExample, wrongSentence));
        }

        [TestMethod]
        public void TestSpellCheckerGivenTwoWrongWords()
        {
            // Arrange
            HashSet<string> dictionaryExample = new HashSet<string>() { "this", "is", "a", "test" };
            string wrongSentence = "This isss a tessst";
            List<string> expected = new List<string>() { "isss", "tessst" };

            // Act and Assert
            CollectionAssert.AreEquivalent(expected.ToList(), Day6Hashing.SpellChecker(dictionaryExample, wrongSentence));
        }


        [TestMethod]
        public void TestAreTwoWordsAnagramsGivenTwoAnagrams()
        {
            // Arrange
            string word1 = "hero";
            string word2 = "ohre";
            bool expected = true;

            // Act and Assert
            Assert.AreEqual(expected, Day6Hashing.AreTwoWordsAnagrams(word1, word2));
        }

        [TestMethod]
        public void TestAreTwoWordsAnagramsGivenTwoNotAnagrams()
        {
            // Arrange
            string word1 = "hero";
            string word2 = "ohme";
            bool expected = false;

            // Act and Assert
            Assert.AreEqual(expected, Day6Hashing.AreTwoWordsAnagrams(word1, word2));
        }

        [TestMethod]
        public void TestAreTwoWordsAnagramsGivenTwoWordsWithDifferentLength()
        {
            // Arrange
            string word1 = "hero";
            string word2 = "ohm";
            bool expected = false;

            // Act and Assert
            Assert.AreEqual(expected, Day6Hashing.AreTwoWordsAnagrams(word1, word2));
        }

        [TestMethod]
        public void TestFindAnagramsGivenTwoWordsWithDifferentLength()
        {
            // Arrange
            List<string> listWithAnagrams = new List<string>() { "arc", "more", "car", "erom", "bone", "rac" };
            bool areThereAnagrams = true;
            
            // Act and Assert
            Assert.AreEqual(areThereAnagrams, Day6Hashing.FindAnagrams(listWithAnagrams));
        }


    }
}