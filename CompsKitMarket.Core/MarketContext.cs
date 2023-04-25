using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CompsKitMarket.Core
{
    public class MarketContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Store> Stores { get; set; }

        public MarketContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }


}
