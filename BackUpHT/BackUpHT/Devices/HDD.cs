using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpHT.Devices
{
    public class HDD : Storage
    {
        public double Speed { get; }
        public int CountSections { get; set; }

        public HDD(string name, string model, double speed, double memory, int countSections, double usedMemory = 0) : base(name, model, memory, usedMemory)
        {
            Speed = speed;
            CountSections = countSections;
        }

        public override string GetDeviceiceInfo()
        {
            return base.GetDeviceiceInfo() + "\nSpeed: " + Speed + "\nCount sections: " + CountSections;
        }
    }
}
