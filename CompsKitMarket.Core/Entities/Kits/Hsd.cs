using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Hsd : Part
    {
        public HsdTypes Type { get; set; }
        public HsdConnections Connections { get; set; }
        public int Vol { get; set; }
        public HsdForms Form { get; set; }
    }
}
