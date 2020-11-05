using CarDealer.Models;
using CarDealer.Models.CarModels;
using CarDealer.Models.SaleModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Data
{
    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext()
        {
        }

        public CarDealerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<EuroStandart> EuroStandarts { get; set; }

        public DbSet<Gearbox> Gearboxes { get; set; }

        public DbSet<CarSales> CarSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-C92LTDN\SQLEXPRESS;Database=CarDealer;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarSales>()
                .HasKey(x => new { x.CarId, x.SaleId });


            modelBuilder.Entity<CarSales>()
                .HasOne(cs => cs.Car)
                .WithMany(c => c.CarSales)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarSales>()
                .HasOne(cs => cs.Sale)
                .WithMany(s => s.CarSales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}