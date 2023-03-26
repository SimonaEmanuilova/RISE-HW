using System;

namespace SmallTasks
{

    public class SmallTask1
    {

        public static int Main()
        {
            int maxNumber = int.MaxValue;
            Console.WriteLine($"The maximum number the integer can hold is {maxNumber}.");

            int overload = maxNumber + 1;
            Console.WriteLine($"When we add 1 to the max int number {maxNumber} we get {overload}.");

            return maxNumber;
           
        }
    }

}