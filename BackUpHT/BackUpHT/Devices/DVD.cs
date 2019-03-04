using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpHT.Devices
{
    public class DVD : Storage
    {
        public double Speed { get; }
        public string Type { get; }

        public DVD(string name, string model, double speed, string type, double memory, double usedMemory = 0) : base(name, model, memory, usedMemory)
        {
            Speed = speed;
            Type = type;
        }

        public override string GetDeviceiceInfo()
        {
            return base.GetDeviceiceInfo() + "\nSpeed: " + Speed + "\nType: " + Type;
        }
    }
}
