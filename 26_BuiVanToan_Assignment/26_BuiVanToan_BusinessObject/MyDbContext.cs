using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace _26_BuiVanToan_BusinessObject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, CategoryName = "Electronics" },
              new Category { CategoryId = 2, CategoryName = "Clothing" }
 );
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);
            modelBuilder.Entity<Member>().HasData(
                 new Member { MemberId = 1, Email = "john@example.com", CompanyName = "ABC Corp", City = "New York", Country = "USA", Password = "john1" },
                 new Member { MemberId = 2, Email = "jane@example.com", CompanyName = "XYZ Ltd", City = "London", Country = "UK", Password = "jane1" }
             );
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);
            modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, CategoryId = 1, ProductName = "Smartphone", Weight = 2, UnitPrice = 499, UnitsInStock = 100 },
            new Product { ProductId = 2, CategoryId = 2, ProductName = "T-Shirt", Weight = 1, UnitPrice = 19, UnitsInStock = 200 }
   );
        }

    }
}
