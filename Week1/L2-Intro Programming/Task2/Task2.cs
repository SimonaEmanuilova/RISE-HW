namespace Tasks
{
    public class Task2
    { 
        public static string ReverseEveryWord(string arg)
        {
            string[] singleWords = arg.Split(' ');

            for (int i = 0; i < singleWords.Length; i++)
            {
                singleWords[i] = Reverse(singleWords[i]);
            }
            return string.Join(" ", singleWords);
        }

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