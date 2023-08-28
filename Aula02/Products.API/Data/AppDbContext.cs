using Products.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductModel>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");
    }
}