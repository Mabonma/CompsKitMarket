using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class CoolerTypes : NamedEntity
    {
        public string Descrtiption { get; set; }
        public List<Cooler> Coolers { get; set; }
    }
}
