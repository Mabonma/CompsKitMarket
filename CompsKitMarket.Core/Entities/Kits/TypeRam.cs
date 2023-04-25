using System.Collections.Generic;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class TypeRam : NamedEntity
    {
        public List<Cpu> Cpus { get; set; }
        public List<Motherboard> Motherboards { get; set; }
    }
}
