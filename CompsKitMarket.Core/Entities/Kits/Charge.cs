using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Charge : Part
    {
        public byte Cpu4 { get; set; }
        public byte Cpu8 { get; set; }
        public byte Sata { get; set; }
        public byte Pcle6 { get; set; }
        public byte Pcle8 { get; set; }
        public byte Pcle16 { get; set; }
        public byte Fdd { get; set; }
        public byte Ide { get; set; }
        public byte Usb { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Deep { get; set; }
    }
}
