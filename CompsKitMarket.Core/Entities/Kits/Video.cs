using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Video : Part
    {
        public int GrafProcId { get; set; }
        public GrafProc GrafProc { get; set; }
        public int VramVol { get; set; }
        public int VramTypeId { get; set; }
        public TypeRam VramType { get; set; }
        public BusType BusInter { get; set; }
        public TypeCooling Cooling { get; set; }
        public bool Rtx { get; set; }

    }
}
