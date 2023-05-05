using CompsKitMarket.Core.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Part : NamedEntity
    {
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public List<Image> Images { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<PartStore> PartStores { get; set; }
        public List<Order> Orders { get; set; }
    }
}
