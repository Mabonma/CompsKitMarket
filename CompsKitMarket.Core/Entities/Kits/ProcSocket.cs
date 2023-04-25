using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class ProcSocket : NamedEntity
    {
        public List<Motherboard> Motherboards { get; set; }
        public List<Cpu> Cpus { get; set; }
    }
}
