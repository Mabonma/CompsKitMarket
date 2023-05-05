using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Ram : Part
    {
        public int TypeId { get; set; }
        public TypeRam Type { get; set; }
        public double Vol { get; set; }
        public byte Count{ get; set; }
        public int Freq { get; set; }
        public string Timings { get; set; }
    }
}
