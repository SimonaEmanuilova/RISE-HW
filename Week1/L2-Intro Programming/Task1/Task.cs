namespace Tasks
{
    public class Task
    {

        public static string Reverse(string inputString)
        {
            string resultString = "";

            for (int i = inputString.Length - 1; i >= 0; i--)
            {

                resultString += inputString[i];
            }

            return resultString;
        }


        public static void Main()
        {


        }

    }






}