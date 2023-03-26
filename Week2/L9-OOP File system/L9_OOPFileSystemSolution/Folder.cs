using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementFIleSystem
{
    public class Folder
    {
        public Folder(Folder parent, string name, HashSet<Folder> children, HashSet<File> files, int size)
        {
            this.parent = parent;
            this.name = name;
            this.children = children;
            this.files = files;
            this.size = size;
        }

        public Folder(string name)
        {
            this.name = name;
            children = new HashSet<Folder>();
            parent = new Folder();
        }

        public Folder()
        {

        }

        public Folder parent { get; set; }

        public string name { get; set; }

        public HashSet<Folder> children { get; set; }

        public HashSet<File> files { get; set; } = new HashSet<File>();

        public int size { get; set; }
    }
}
