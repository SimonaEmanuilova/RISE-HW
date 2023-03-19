using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Collections;
using System;


namespace Day5
{
    public class Day5Tasks
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 1, 2, 3, 1, 1 };
            List<int> resultList = new List<int>(GetUniqueNumbers(inputList));

            LinkedList<int> input = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
            RemoveMiddleNumber(input);

            HanoiTower(3);

            Console.WriteLine("\n\nProblem 4: Expression expansion \nType an expression to be expanded:");
            string inputExpression = Console.ReadLine();
            ExpressionExpansion(inputExpression);
        }

        public static List<int> GetUniqueNumbers(List<int> listTest)
        {
            HashSet<int> result = new HashSet<int>();

            foreach (int item in listTest)
            {
                result.Add(item);
            }

            Console.WriteLine("Problem 1: Unique numbers:");
            foreach (int item in result)
            {
                Console.Write(item + " ");
            }

            List<int> resultList = result.ToList();

            return resultList;
        }

        public static LinkedList<int> RemoveMiddleNumber(LinkedList<int> input)
        {
            LinkedList<int> tempList = new LinkedList<int>();

            bool removed = false;
            decimal initialSize = input.Count;
            decimal middle = Math.Floor(initialSize / 2);

            Console.WriteLine("\n\nProblem 2: Remove middle number:");

            for (int i = 0; i <= (int)initialSize; i++)
            {
                if (input.Count == 0)
                {
                    break;
                }
                int temp = input.First();
                tempList.AddLast(temp);
                input.RemoveFirst();


                if (removed != true && i == (int)middle)
                {
                    tempList.RemoveLast();
                    removed = true;
                }
            }
            Console.WriteLine($"The new linked list is:");

            foreach (var num in tempList)
            {
                Console.Write(" " + num);
            }

            return tempList;
        }

        public static bool HanoiTower(int numberOfDiscs)
        {
            bool isSuccessfullySolved = false;
            int numberOfSteps = (int)Math.Pow(2, numberOfDiscs) - 1;
            Stack<int> startRod = new Stack<int>();
            Stack<int> helpRod = new Stack<int>();
            Stack<int> endRod = new Stack<int>();

            for (int i = numberOfDiscs; i >= 1; i--)
            {
                startRod.Push(i);
            }

            Console.WriteLine($"\n\nProblem 3: Hanoi Towers\nYou start the game with {numberOfDiscs} disks on rod A:");

            foreach (int num in startRod)
            {
                Console.WriteLine(" " + num);
            }
            Console.WriteLine($"The number of steps to solve the Hanoi Tower with {numberOfDiscs} disks is {numberOfSteps}.");

            char startRodName = 'A';
            char helpRodName = 'B';
            char endRodName = 'C';

            isSuccessfullySolved = SolveTowers(numberOfDiscs, startRodName, endRodName, helpRodName, startRod, endRod, helpRod);
            return isSuccessfullySolved;
        }

        public static bool SolveTowers(int numberOfDiscs, char startRodName, char endRodName, char helpRodName, Stack<int> startRod, Stack<int> endRod, Stack<int> helpRod)
        {
            bool isFinished = false;

            if (startRod.Count > 0 && numberOfDiscs > 0)
            {
                SolveTowers(numberOfDiscs - 1, startRodName, helpRodName, endRodName, startRod, helpRod, endRod);
                Console.WriteLine($"\nNext Step : move disk from {startRodName} to {endRodName}.");

                int temp = startRod.Pop();
                endRod.Push(temp);

                Console.WriteLine($"On rod {startRodName}:");
                foreach (int num in startRod)
                {
                    Console.WriteLine(" " + num);
                }

                Console.WriteLine($"On rod {helpRodName}:");
                foreach (int num in helpRod)
                {
                    Console.WriteLine(" " + num);
                }

                Console.WriteLine($"On rod {endRodName}:");
                foreach (int num in endRod)
                {
                    Console.WriteLine(" " + num);
                }

                SolveTowers(numberOfDiscs - 1, helpRodName, endRodName, startRodName, helpRod, endRod, startRod);
            }

            if (startRod.Count == 0 && helpRod.Count == 0 && endRod.Count == numberOfDiscs)
            {
                Console.WriteLine("The game has finished!");
                isFinished = true;
            }
            return isFinished;
        }

        //the following method doesn't take bracket in bracket expression cases
        public static string ExpressionExpansion(string input)
        {
            Stack<char> expandedExpression = new Stack<char>();

            if (input.Length == 1 && char.IsDigit(input[0]))
            {
                {
                    throw new ArgumentException("There has to be an expression following the number.");
                }
            }


            for (int i = 0; i <= input.Length - 1; i++)
            {
                char singleChar = input[i];

                if (char.IsDigit(singleChar))
                {
                    i = ManageReplication(expandedExpression, input, i, singleChar);
                }
                else
                {
                    expandedExpression.Push(input[i]);
                }
            }

            string result = string.Concat(expandedExpression);
            Console.WriteLine(ReverseString(result));

            return ReverseString(result);
        }

        private static int ManageReplication(Stack<char> expandedExpression, string input, int i, char singleChar)
        {
            char nextChar = input[i + 1];
            int displacement = 0;

            if (nextChar == '(')
            {
                ManageBrackets(expandedExpression, input, ref i, singleChar, ref displacement);
            }
            else
            {
                for (int k = 1; k < char.GetNumericValue(singleChar); k++)
                {
                    expandedExpression.Push(input[i + 1]);
                }
            }

            return i;
        }

        private static void ManageBrackets(Stack<char> expandedExpression, string input, ref int i, char singleChar, ref int displacement)
        {
            for (int numberOfCopies = 1; numberOfCopies <= char.GetNumericValue(singleChar); numberOfCopies++)
            {
                displacement = i + 1;

                while (input[displacement + 1] != ')')
                {
                    expandedExpression.Push(input[displacement + 1]);
                    displacement++;
                }
            }
            i += displacement;
        }

        //Using a function from the homework on Day2 from the bootcamp that is already tested:
        public static string ReverseString(string inputString)
        {
            string resultString = "";

            for (int i = inputString.Length - 1; i >= 0; i--)
            {

                resultString += inputString[i];
            }

            return resultString;
        }

    }
}





//public static class MyExtensions
//{

//    public static LinkedList<T> ToLinkedList<T>(this T[] a)
//    {

//        return new LinkedList<T>(a);

//    }


//}
