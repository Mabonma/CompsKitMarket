using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CompsKitMarket.Core.Entities;

namespace CompsKitMarket.Core
{
    public class MarketContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Hsd> Hsds { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<FormFactor> FormFactors { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<ProcSocket> ProcSockets { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<ProcModel> ProcModels { get; set; }
        public DbSet<TypeRam> TypeRams { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<GrafProc> GrafProcs { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<CoolerTypes> CoolerTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PartStore> PartStores { get; set; }

        public MarketContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Charge>().ToTable("Charge");
            modelBuilder.Entity<Cooler>().ToTable("Cooler");
            modelBuilder.Entity<Cpu>().ToTable("Cpu");
            modelBuilder.Entity<Frame>().ToTable("Frame");
            modelBuilder.Entity<Hsd>().ToTable("Hsd");
            modelBuilder.Entity<Motherboard>().ToTable("Motherboard");
            modelBuilder.Entity<Ram>().ToTable("Ram");
            modelBuilder.Entity<Video>().ToTable("Video");

            modelBuilder.Entity<Part>()
                .HasMany(c => c.Images)
                .WithOne(s => s.Part)
                .HasForeignKey(p => p.PartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Part>()
                .HasOne(c => c.Manufacturer)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.ManufacturerID);

            modelBuilder.Entity<PartStore>()
                .HasKey(u => new { u.PartId, u.StoreId });

            modelBuilder.Entity<Part>()
                .HasMany(c => c.PartStores)
                .WithOne(s => s.Part)
                .HasForeignKey(p => p.PartId);

            modelBuilder.Entity<Part>()
                .HasMany(c => c.Orders)
                .WithMany(s => s.Parts);

            modelBuilder.Entity<Order>()
                .HasMany(c => c.Stores)
                .WithMany(s => s.Orders);

            modelBuilder.Entity<Store>()
                .HasMany(c => c.PartStores)
                .WithOne(s => s.Store)
                .HasForeignKey(p => p.StoreId);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.User)
                .WithMany(s => s.Orders)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<FormFactor>()
                .HasMany(c => c.Frames)
                .WithOne(s => s.MotherForm)
                .HasForeignKey(p => p.MotherFormId);

            modelBuilder.Entity<FormFactor>()
                .HasMany(c => c.Motherboards)
                .WithOne(s => s.FormFactor)
                .HasForeignKey(p => p.FormFactorId);

            modelBuilder.Entity<ProcSocket>()
                .HasMany(c => c.Motherboards)
                .WithOne(s => s.ProcSocket)
                .HasForeignKey(p => p.ProcSocketId);

            modelBuilder.Entity<ProcSocket>()
                .HasMany(c => c.Cpus)
                .WithOne(s => s.ProcSocket)
                .HasForeignKey(p => p.ProcSocketId);

            modelBuilder.Entity<ProcSocket>()
                .HasMany(c => c.Coolers)
                .WithOne(s => s.Socket)
                .HasForeignKey(p => p.SocketId);

            modelBuilder.Entity<ProcModel>()
                .HasMany(c => c.Cpus)
                .WithOne(s => s.ProcModel)
                .HasForeignKey(p => p.ProcModelId);

            modelBuilder.Entity<TypeRam>()
                .HasMany(c => c.Motherboards)
                .WithOne(s => s.TypeRam)
                .HasForeignKey(p => p.TypeRamId);

            modelBuilder.Entity<TypeRam>()
                .HasMany(c => c.Cpus)
                .WithOne(s => s.TypeRam)
                .HasForeignKey(p => p.TypeRamId);

            modelBuilder.Entity<TypeRam>()
                .HasMany(c => c.Videos)
                .WithOne(s => s.VramType)
                .HasForeignKey(p => p.VramTypeId);

            modelBuilder.Entity<GrafProc>()
                .HasMany(c => c.Videos)
                .WithOne(s => s.GrafProc)
                .HasForeignKey(p => p.GrafProcId);

            modelBuilder.Entity<CoolerTypes>()
                .HasMany(c => c.Coolers)
                .WithOne(s => s.CoolerTypes)
                .HasForeignKey(p => p.CoolerTypeId);
        }
    }


}
