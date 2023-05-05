using CompsKitMarket.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Cooler : Part
    {
        public int CoolerTypeId { get; set; }
        public CoolerTypes CoolerTypes { get; set; }
        public int? SocketId { get; set; }
        public ProcSocket Socket { get; set; }
        public TypeCooling TypeCooling { get; set; }
        public int Diam { get; set; }
        public int Tdp { get; set; }
        public byte CountFan { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int Rpm { get; set; }

    }
}
