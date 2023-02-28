
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Data
{

    public class MyDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-FF1278R;Database=MvcDemo;Trusted_Connection=True;MultipleActiveResultSets=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //data seeding
            modelBuilder.Entity<Clothes>().HasData(
                new { Id = 1, Name = "Váy công sở Zara", Description = "Màu trắng", Size = Size.Large, Price = 89.99m, RentalTime = 0, RentalPrice = 200000, TypeClothesId = 1, Status = Status.Available },
                new { Id = 2, Name = "Áo công sở Uniqlo", Description = "Màu đen", Size = Size.Medium, Price = 58.99m, RentalTime = 0, RentalPrice = 100000, TypeClothesId = 2, Status = Status.Available }
                );
            modelBuilder.Entity<TypeClothes>().HasData(
                new { Id = 1, Name = "Váy", Limit = 15 },
                new { Id = 2, Name = "Áo", Limit = 20 }
                );
        }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<TypeClothes> TypeClothes { get; set; }
    }
}
