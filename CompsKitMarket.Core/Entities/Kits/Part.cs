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
    }
}
