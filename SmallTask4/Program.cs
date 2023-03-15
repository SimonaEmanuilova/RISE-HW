using System;

namespace SmallTasks
{

    public class SmallTask4
    {
        public static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static void Main()
        {
            int[] arr = { 6, 25, 18, 1, 93 };
            int min = Min(arr);
            string allArrayNumbers = string.Join(",", arr);
            Console.WriteLine($"The min element in the array [{allArrayNumbers}] is: {min}");
        }
    }

}