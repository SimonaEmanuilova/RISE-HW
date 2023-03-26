using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementFIleSystem
{
    public class File
    {
        public File(string name, SortedDictionary<int, string> content, Folder folder, int size)
        {
            this.name = name;
            this.content = content;
            this.folder = folder;
            this.size = size;
        }

        public File(string name)
        {
            this.name = name;
            content= new SortedDictionary<int, string>();
            folder = new Folder();

        }

        public string name { get; set; }

        public SortedDictionary<int, string> content { get; set; }

        public Folder folder  { get; set; }

        public int size { get; set; }   

    }
}
