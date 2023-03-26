using System;

namespace SmallTasks
{

    public class SmallTask2
    {
        
       

        public static int Main()
        { 
            
            Console.Write("Enter a number to check if the number is odd: ");
            string inputNumber = Console.ReadLine();
            bool isOdd=false;

            int num;
            if (int.TryParse(inputNumber, out num))
            {
                isOdd = IsOdd(num);
                Console.WriteLine($"{num} is odd: {isOdd}");
            }
            else
            {
                Console.WriteLine("The input you've written isn't an integer. Please input an int.");
            }

            return 0;
            
        } 
        
        public static bool IsOdd(int n)
            {
                return n % 2 == 1;
            }
    }

}