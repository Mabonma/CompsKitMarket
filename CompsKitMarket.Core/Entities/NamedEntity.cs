using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities
{
    public abstract class NamedEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
