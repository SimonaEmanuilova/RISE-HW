using ImplementFIleSystem;

namespace L9_OOPFileSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCdLocation()
        {
            FileSystem filesystem = new FileSystem();
            string input = "cd";
            string expected = "home";
            string actual = filesystem.Location(input);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestCdLocationDoesNothing()
        {
            FileSystem filesystem = new FileSystem();
            string input = "cd .";
            string expected = "";
            string actual = filesystem.Location(input);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestCdLocationGoesIn()
        {
            FileSystem filesystem = new FileSystem();
            string input = "cd ..";
            string expected = "/";
            string actual = filesystem.Location(input);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestCdLocationWhenSystemCannotFindPath()
        {
            FileSystem filesystem = new FileSystem();
            string input = "cd test";
            string expected = "The system cannot find the path specified.";
            string actual = filesystem.Location(input);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestCdLocationWhenAlreadyOnThisPath()
        {
            FileSystem filesystem = new FileSystem();
            string input = "cd home";
            string expected = "You are already on this path.";
            string actual = filesystem.Location(input);

            Assert.AreEqual(actual, expected);

        }

        // NewFolder

        [TestMethod]
        public void TestWhenAddFolder()
        {
            FileSystem filesystem = new FileSystem();
            string input = "mkdir testFolder";
            string expected = "Added folder testFolder .";

            string actual = filesystem.NewFolder(input);
            string command = "cd testFolder";
            filesystem.Location(command);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestWhenAddFolderWithEmptyName()
        {
            FileSystem filesystem = new FileSystem();
            string input = "mkdir";
            string expected = "Folder name can not be empty";

            string actual = filesystem.NewFolder(input);
            string command = "cd testFolder";
            filesystem.Location(command);

            Assert.AreEqual(actual, expected);

        }

        // CreateFile

        [TestMethod]
        public void TestWhenAddFile()
        {
            FileSystem filesystem = new FileSystem();
            string input = "create_file testFile";
            string expected = $"Created file testFile .";

            string actual = filesystem.CreateFile(input);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestWhenAddFileWithEmptyName()
        {
            FileSystem filesystem = new FileSystem();
            string input = "create_file";
            string expected = "File name can not be empty";

            string actual = filesystem.CreateFile(input);

            Assert.AreEqual(actual, expected);

        }

    }
}