using System.ComponentModel;

namespace FindMissingNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] inputArr = { 103, 101 };
            FindMissingNumber1(inputArr);
            FindMissingNumber2(inputArr);


            int number = 27;
            FindRoot3(number);
        }

        public static int FindMissingNumber1(int[] input)
        {

            if (input.Length <= 1)
            {
                throw new Exception("The array must have at least 2 numbers.");
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = 0; j < input.Length - i - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        int store = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = store;
                    }
                }
            }


            string numsFromArrAsString = string.Join(", ", input);
            Console.WriteLine($"We search the missing number from the sequence {numsFromArrAsString}.");



            int result = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] - input[i] != 1)
                {

                    result = input[i] + 1;
                    Console.WriteLine($"First Solution: The missing number from the array is {result}.\n");
                }
            }

            return result;
        }

        public static int FindMissingNumber2(int[] input)
        {
            if (input.Length <= 1)
            {
                throw new Exception("The array must have at least 2 numbers.");
            }

            int minNum = input[0];
            int maxNum = input[0];
            int inputArraySum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < minNum)
                {
                    minNum = input[i];
                }

                if (input[i] > maxNum)
                {
                    maxNum = input[i];
                }

                inputArraySum += input[i];
            }

            int totalSum = ((minNum + maxNum) / 2) * (input.Length + 1);
            int result = totalSum - inputArraySum;
            Console.WriteLine($"Second optimized solution: The missing number from the array is {result}.\n");


            return result;
        }

        public static int FindRoot3(int num)
        {
            bool isPerfectCube = false;
            int cubeRoot = 0;

            if (num < 0)
            {
                throw new Exception("The number must be a positive number.");
            }
            if (num == 0)
            {
                cubeRoot = 0;
                Console.WriteLine($"Cube root of {num} is {cubeRoot}.");
                isPerfectCube = true;
                return cubeRoot;
            }

            if (num == 1)
            {
                cubeRoot = 1;
                Console.WriteLine($"Cube root of {num} is {cubeRoot}.");
                isPerfectCube = true;
                return cubeRoot;
            }

            for (int i = 1; i * i * i <= num; i++)
            {
                int cube = i * i * i;
                if (cube == num)
                {
                    cubeRoot = i;
                    isPerfectCube = true;

                    break;
                }
                else if (cube > num)
                {
                    cubeRoot = i - 1;
                    isPerfectCube = true;

                    break;
                }
            }


            if (!isPerfectCube)
            {
                throw new Exception($"The imput number is not a perfect cube.");
            }

            Console.WriteLine($"Cube root of {num} is {cubeRoot}.");
            return cubeRoot;
        }


    }
}