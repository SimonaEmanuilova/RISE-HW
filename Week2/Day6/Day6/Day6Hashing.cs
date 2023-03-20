using System.Collections;
using System.Runtime.CompilerServices;

namespace Day6
{
    public class Day6Hashing
    {
        public static void Main(string[] args)
        {

        }

        public static HashSet<string> ManageCarNumberToOwner(Hashtable plateNumberToOwner)
        {
            HashSet<string> seenNames = new HashSet<string>();
            HashSet<string> haveMultipleCars = new HashSet<string>();
            bool isSeen = false;

            foreach (var value in plateNumberToOwner.Values)
            {
                if (!seenNames.Add(value.ToString()))
                {
                    isSeen = true;
                    haveMultipleCars.Add(value.ToString());
                }
            }

            if (haveMultipleCars.Count == 0)
            {
                throw new ArgumentException("There is no one with more than one car. Inflation is hard on everybody.");
            }

            foreach (var value in haveMultipleCars)
            {
                Console.WriteLine(value);
            }

            return haveMultipleCars;
        }

        public static string HumanWithCoolestPlate(Hashtable plateNumberToOwner, string plateNumber)
        {
            if (!plateNumberToOwner.ContainsKey(plateNumber))
            {

                throw new ArgumentException("There is no such number.");
            };


            string name = plateNumberToOwner[plateNumber].ToString();

            return name;
        }

        public static int[] FindIntersection(int[] arr1, int[] arr2)
        {

            HashSet<int> numbers1 = new HashSet<int>();
            HashSet<int> numbers2 = new HashSet<int>();


            for (int i = 0; i < arr1.Length - 1; i++)
            {
                numbers1.Add(arr1[i]);
            }

            for (int k = 0; k < arr2.Length - 1; k++)
            {
                numbers2.Add(arr2[k]);
            }


            int[] intersectedNumbers = numbers1.Intersect(numbers2).ToArray();


            if (intersectedNumbers.Length == 0)
            {
                return new int[0];
            }

            return intersectedNumbers;
        }

        public static List<char> FindNonRepeatingChars(string inputStr)
        {
            char[] charsArr = inputStr.ToCharArray();

            Dictionary<char, int> nonRepeatingCharsDict = new Dictionary<char, int>();
            List<char> nonRepeatingChars = new List<char>();
            for (int i = 0; i < charsArr.Length; i++)
            {

                if (!nonRepeatingCharsDict.ContainsKey(charsArr[i]))
                {
                    nonRepeatingCharsDict.Add(charsArr[i], 1);
                }
                else
                {
                    nonRepeatingCharsDict[charsArr[i]]++;
                }
            }

            foreach (var kvp in nonRepeatingCharsDict)
            {
                if (kvp.Value == 1)
                {
                    nonRepeatingChars.Add(kvp.Key);
                }
            }

            FirstNonRepeating(nonRepeatingChars, inputStr);

            return nonRepeatingChars;

        }
        public static int FirstNonRepeating(List<char> nonRepeatingChars, string inputStr)
        {
            if (!nonRepeatingChars.Any())
            {

                return -1;
            }

            else { Console.WriteLine("The first non repeating character's index is " + inputStr.IndexOf(nonRepeatingChars.First())); }

            return inputStr.IndexOf(nonRepeatingChars.First());
        }


        public static List<string> SpellChecker(HashSet<string> wordDictionary, string inputSentence)
        {

            string[] singleWords = inputSentence.Split(' ');

            List<string> wrongWords = new List<string>();

            foreach (var word in singleWords)
            {
                if (!wordDictionary.Contains(word.ToLower()))
                {
                    wrongWords.Add(word);
                }
            }

            foreach (var word in wrongWords)
            {
                Console.WriteLine("Wrong word:" + word);
            }

            if (wordDictionary.Count == 0)
            {
                return new List<string>() { "" };
            }

            return wrongWords;
        }


    }

}