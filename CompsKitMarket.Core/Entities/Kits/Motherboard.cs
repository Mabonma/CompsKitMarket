using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Motherboard : Part
    {
        public int MotherFormId { get; set; }
        public FormFactor FormFactor { get; set; }
        public int TypeRamId { get; set; }
        public TypeRam TypeRam { get; set; }
        public int CountRam { get; set; }
        public int RamFreq { get; set; }
        public byte M2 { get; set; }
        public int Sata3 { get; set; }
        public byte Pci16 { get; set; }
        public byte Pci8 { get; set; }
        public byte Pci4 { get; set; }
        public byte Pci1 { get; set; }
        public int SocketId { get; set; }
        public ProcSocket ProcSocket { get; set; }
    }
}
