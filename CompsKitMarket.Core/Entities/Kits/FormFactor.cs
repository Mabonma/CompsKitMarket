using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class FormFactor : NamedEntity
    {
        public List<Frame> Frames { get; set; }
        public List<Motherboard> Motherboards { get; set; }
    }
}
