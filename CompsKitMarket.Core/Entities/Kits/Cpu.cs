using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Cpu : Part
    {
        public int SocketId { get; set; }
        public ProcSocket ProcSocket { get; set; }
        public int ModelId { get; set; }
        public ProcModel ProcModel { get; set; }
        public byte Cores { get; set; }
        public bool Graf { get; set; }
        public string Crystal { get; set; }
        public double BaseFreq { get; set; }
        public double MaxFreq { get; set; }
        public double MultiThread { get; set; }
        public int Tdp { get; set; }
        public BoxesType BoxType { get; set; }
        public int Tehprocess { get; set; }
        public int TypeRamId { get; set; }
        public TypeRam TypeRam { get; set; }
    }
}
