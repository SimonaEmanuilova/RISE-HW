using System;

namespace SmallTasks
{

    public class SmallTask3
    {
        public static bool IsNumberPrime(int n)
            {

                {
                    //for the check is used a primality test simple method from https://en.wikipedia.org/wiki/Primality_test 

                    if (n == 2 || n == 3)
                        return true;

                    if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                        return false;

                    for (int i = 5; i * i <= n; i += 6)
                    {
                        if (n % i == 0 || n % (i + 2) == 0)
                            return false;
                    }

                    return true;
                }
            }
        public static void Main()
        {
          

            Console.Write("Enter a number to check if it's prime: ");
            string input = Console.ReadLine();
            int num;

            if (int.TryParse(input, out num))
            {
                bool isPrime = IsNumberPrime(num);
                Console.WriteLine($"{num} is prime: {isPrime}");
            }
            else
            {
                Console.WriteLine($"Invalid input: '{input}' is not a valid integer.");
            }
        }
    }

}