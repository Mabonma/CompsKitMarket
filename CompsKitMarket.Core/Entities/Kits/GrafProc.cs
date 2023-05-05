using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class GrafProc : NamedEntity
    {
        public double Freq { get; set; }
        public GProcs GProcs { get; set; }
        public List<Video> Videos { get; set; }
    }
}
