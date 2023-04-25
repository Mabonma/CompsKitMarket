using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Orders
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public DateTime DateTimeDelivery { get; set; }
        public string AddressDelivery { get; set; }
        public string Mobile { get; set; }
        public string Note { get; set; }
    }
}
