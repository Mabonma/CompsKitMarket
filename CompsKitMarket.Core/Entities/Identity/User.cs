using CompsKitMarket.Core.Entities.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public bool Deleted { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
    }
}
