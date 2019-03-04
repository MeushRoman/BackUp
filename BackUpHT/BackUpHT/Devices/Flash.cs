using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpHT.Devices
{
    public class Flash : Storage
    {
        public double Speed { get; }        

        public Flash(string name, string model, double speed, double memory, double usedMemory = 0):base(name, model, memory, usedMemory)
        {
            Speed = speed;   
        }

        public override string GetDeviceiceInfo()
        {
            return base.GetDeviceiceInfo() + "\nSpeed: " + Speed;
        }
    }
}
