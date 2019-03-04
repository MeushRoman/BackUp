using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpHT
{
    public class File
    { 
        public string Type { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string Info { get; set; }

        public File() : this("Folder", "New folder", 0) { }
       
        public File(string type, string fileName, double fileSize) 
        {
            Type = type;
            FileName = fileName;
            FileSize = fileSize;
            Info = string.Format("File name: {0}\nSize: {1} Mb\nType: {2}\nCreate date: {3}\n", FileName, FileSize, Type, DateTime.Now);
        }
    }
}
