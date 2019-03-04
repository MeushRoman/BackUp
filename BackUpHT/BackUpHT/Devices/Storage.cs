using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpHT.Devices
{
    public abstract class Storage
    {
        public string Name { get; }
        public string Model { get; }
        public double Memory { get; }
        private double UsedMemory { get; set; }

        public List<File> files = new List<File>();

        public Storage() : this("", "") { }
        public Storage(string name) : this(name, "") { }
        public Storage(string name, string model) : this(name, model, 0,0) { }
        public Storage(string name, string model, double memory, double usedMemory)
        {
            Name = name;
            Model = model;
            Memory = memory;
            UsedMemory = usedMemory;
        }

        public bool CopyData(File f)
        {
            if (f.FileSize < (Memory - UsedMemory))
            {
                files.Add(f);
                UsedMemory += f.FileSize;
                return true;
            }
            return false;
        }
        
        public void FileList()
        {
            foreach (File item in files)
            {
                Console.WriteLine(item.FileName);
            }
        }

        public  double FreeMemory()
        {            
            return (Memory - UsedMemory);          
        }

        public virtual string GetDeviceiceInfo()
        {
            return string.Format("Name: {0}\nModel: {1}\nMemory: {2}\nFree memory: {3}", Name, Model, Memory, FreeMemory());
        }
    }
}
