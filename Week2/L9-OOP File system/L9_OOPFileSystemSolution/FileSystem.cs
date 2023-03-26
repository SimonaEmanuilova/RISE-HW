using System.Linq;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace ImplementFIleSystem
{
    public class FileSystem
    {
        public FileSystem(Folder currentFolder, Stack<Folder> folders)
        {
            this.currentFolder = currentFolder;
            this.folders = folders;
        }

        public FileSystem()
        {
            this.Initialise();
        }

        public Folder currentFolder { get; set; }

        public Stack<Folder> folders = new Stack<Folder>();

        private void Initialise()
        {
            Folder rootFolder = new Folder("/");
            Folder homeFolder = new Folder("home");
            homeFolder.parent.name = "/";
            rootFolder.children.Add(homeFolder);

            folders.Push(rootFolder);
            folders.Push(homeFolder);

            currentFolder = homeFolder;
        }

        public string Location(string input)
        {
            string output = "";
            bool isFirstTime = false;

            switch (input)
            {

                case "cd":
                    isFirstTime = true;
                    Console.WriteLine(folders.Peek().name);
                    break;

                case "cd ..":
                    folders.Pop();
                    currentFolder = folders.Peek();
                    Console.WriteLine(folders.Peek().name);
                    break;

                case "cd .":
                    Console.WriteLine();
                    break;

                default:
                    {
                        string[] splitInput = input.Split(' ');

                        bool isChild = false;

                        foreach (var current in currentFolder.children)
                        {

                            if (current.name == splitInput[1])
                            {

                                isChild = true;
                                folders.Push(current);

                            }
                        }

                        if (splitInput[1] == currentFolder.name)
                        {
                            isChild = true;
                            output = "You are already on this path.";
                            Console.WriteLine("You are already on this path.");
                        }

                        if (!isChild && !isFirstTime)
                        {
                            output = "The system cannot find the path specified.";
                            Console.WriteLine("The system cannot find the path specified.");
                        }

                        currentFolder = folders.Peek();

                        output = folders.Peek().name;
                        Console.WriteLine(folders.Peek().name);
                        break;
                    }
            }
            return output;
        }

        public string NewFolder(string input)
        {
            string output = "";
            string[] splitInput = input.Split(' ');

            string newFolderName = splitInput[1];
            Folder newFolder = new Folder(newFolderName);
            newFolder.parent = currentFolder;
            currentFolder.children.Add(newFolder);

            Console.WriteLine($"Added folder {newFolder.name} .");
            output = $"Added folder {newFolder.name} .";

            return output;
        }

        public string CreateFile(string input)
        {
            string output = "";

            string[] splitInput = input.Split(' ');
            string fileName = splitInput[1];

            File newFile = new File(fileName);
            newFile.folder = currentFolder;
            currentFolder.files.Add(newFile);
            newFile.size = 0;

            Console.WriteLine($"Created file {newFile.name} .");
            output = $"Created file {newFile.name} .";

            return output;
        }

        public static int CalculateFileSize(File file)
        {
            int numberOfLines = file.content.Any() ? file.content.Keys.Last() : 0; //if it has any content then the number of lines is the last key of the sorted dict
            int numberOfChars = FindNumberOfChars(file.content);
            file.size = numberOfLines + numberOfChars;

            return file.size;
        }

        public static int CalculateFolderSize(Folder folder)
        {
            int childFoldersSize = 0;
            int filesSize = 0;

            if (folder.children.Any())
            {

                foreach (Folder childFolder in folder.children)
                {
                    childFoldersSize += childFolder.size;
                }
            }

            if (folder.files.Any())
            {

                foreach (File file in folder.files)
                {
                    filesSize += file.size;
                }
            }
            folder.size = childFoldersSize + filesSize;

            return folder.size;
        }

        private static int FindNumberOfChars(SortedDictionary<int, string> fileContent)
        {
            int numberOfChars = 0;
            foreach (var line in fileContent.Values)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        numberOfChars++;
                    }
                }
            }
            return numberOfChars;
        }

        public void ListFiles(string input)
        {
            if (input == "ls")
            {
                foreach (var file in currentFolder.files)
                {
                    Console.WriteLine(file.name);
                }
                foreach (var childFolder in currentFolder.children)
                {
                    Console.WriteLine(childFolder.name);
                }
            }
            else if (input == "ls --sorted desc")
            {
                SortedDictionary<int, string> filesInFolderSizes = new SortedDictionary<int, string>();
                foreach (var file in currentFolder.files)
                {
                    filesInFolderSizes.Add(file.size, file.name);
                }

                foreach (var item in filesInFolderSizes)
                {
                    Console.Write(item.Value + " ");
                    Console.WriteLine(item.Key);
                }

                SortedDictionary<int, string> childFoldersSizes = new SortedDictionary<int, string>();
                foreach (var childFolder in currentFolder.children)
                {
                    childFoldersSizes.Add(childFolder.size, childFolder.name);
                }

                foreach (var item in childFoldersSizes)
                {
                    Console.Write(item.Value + " ");
                    Console.WriteLine(item.Key);
                }

            }
        }
        public SortedDictionary<int, string> DisplayFileContent(string input)
        {
            var output = new SortedDictionary<int, string>();
            string[] splitInput = input.Split(' ');

            foreach (var file in currentFolder.files)
            {
                if (file.name == splitInput[1])
                {
                    if (file.content.Count == 0)
                    {
                        Console.WriteLine("File is empty.");
                    }

                    foreach (var line in file.content)
                    {
                        Console.Write(line.Value + " ");
                        Console.WriteLine(line.Key);
                    }

                    output = file.content;
                }
            }

            return output;
        }

        public string Tail(string input)
        {

            string output = "";
            string[] splitInput = input.Split(' ');

            foreach (var file in currentFolder.files)
            {
                if (file.name != splitInput[1])
                {
                    output = "There is no such file name.";
                    Console.WriteLine("There is no such file name.");
                    continue;
                }

                else if (file.content.Count == 0)
                {
                    output = "File is empty.";
                    Console.WriteLine("File is empty.");
                }

                else TailLogic(splitInput, file);

            }
            return output;
        }

        private static void TailLogic(string[] splitInput, File file)
        {
            if (splitInput.Contains("-l"))
            {
                TailByLine(splitInput, file);
            }

            else if (file.content.Count <= 10)
            {
                for (int i = 1; i <= file.content.Count; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(file.content[i]);
                }
            }

            else
            {
                for (int i = file.content.Count - 9; i <= file.content.Count; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(file.content[i]);
                }
            }
        }

        private static void TailByLine(string[] splitInput, File file)
        {
            if (file.content.Count <= int.Parse(splitInput[3]))
            {
                for (int i = 1; i <= file.content.Count; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(file.content[i]);
                }
            }

            else
            {
                for (int i = file.content.Count - int.Parse(splitInput[3]) + 1; i <= file.content.Count; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(file.content[i]);
                }
            }
        }

        public string WriteInFile(string input)
        {
            string output = "";

            string[] splitInput = input.Split(' ');

            string fileName = splitInput[1];
            int lineKey = Int32.Parse(splitInput[2]);

            string text = String.Join(" ", splitInput[3..]);
            text = text.Replace("-overwrite", "");  //if the input is a whole sentence with intervals it will remove the word -overwrite from the sentence.

            bool foundFile = false;

            foreach (var file in currentFolder.files)
            {
                if (file.name == fileName)
                {
                    foundFile = true;
                    if (file.content.ContainsKey(lineKey))
                    {   output+= " " + text;
                        file.content[lineKey] += " " + text;

                        if (splitInput.Contains("-overwrite"))
                        {
                            output = text;
                            file.content[lineKey] = text;
                        }
                    }
                    else
                    {
                        output=text;
                        file.content.Add(lineKey, text);
                    }

                    file.size = CalculateFileSize(file);
                    currentFolder.size = CalculateFolderSize(currentFolder);

                    AddUpperEmptyLines(file, lineKey);
                }
            }
            if (!foundFile)
            {
                Console.WriteLine("There is no file with such name in this folder.");
            }

            return output;
        }
        public static void AddUpperEmptyLines(File file, int lineKey)
        {
            for (int i = 1; i < lineKey; i++)
            {
                if (!file.content.ContainsKey(i))
                {
                    file.content.Add(i, "");
                }
            }
        }

    }
}