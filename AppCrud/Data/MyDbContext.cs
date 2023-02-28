
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

        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<TypeClothes> TypeClothes { get; set; }
    }
}
