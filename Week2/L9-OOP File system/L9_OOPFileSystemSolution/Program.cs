using ImplementFIleSystem;

namespace ImplementFileSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var filesystem = new FileSystem();

            string input = Console.ReadLine();

            bool isInReadMode = true;

            while (isInReadMode)
            {
                string[] getCommand = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (getCommand[0])
                {

                    case "cd":
                        filesystem.Location(input);
                        break;

                    case "mkdir":
                        filesystem.NewFolder(input);
                        break;

                    case "create_file":
                        filesystem.CreateFile(input);
                        break;

                    case "ls":
                        filesystem.ListFiles(input);
                        break;

                    case "cat":
                        filesystem.DisplayFileContent(input);
                        break;

                    case "write":
                        filesystem.WriteInFile(input);
                        break;

                    case "tail":
                        filesystem.Tail(input);
                        break;

                    case "exit":
                        Console.WriteLine("Exited Command typing mode.");
                        isInReadMode = false;
                        break;

                    default:
                        Console.WriteLine("Unsupported command.");
                        break;

                }

                input = Console.ReadLine();

            }
        }


    }
}