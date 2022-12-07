using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1
{
    public class Folder
    {
       public string Path { get; set; }
       public List<File> Files { get; set; } = new List<File>();
    }

    public class File
    {
        public string Name { get; set; }
        public long Size { get; set; }
    }
}
