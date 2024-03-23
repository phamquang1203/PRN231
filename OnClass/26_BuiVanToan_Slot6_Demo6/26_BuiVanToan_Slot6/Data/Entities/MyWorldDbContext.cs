using Microsoft.EntityFrameworkCore;


namespace _26_BuiVanToan_Slot6.Data.Entities
{

    public class MyWorldDbContext : DbContext
    {


        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {
        }

        public DbSet<Gadgets> Gadgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // below line to watch the ef core sql quiries generation
            // not at all recomonded for the production code
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding data for Gadgets

            var gadgets = new List<Gadgets>()
            {
                new Gadgets()
                {
                    Id = 1,
                    ProductName = "Samsung Galaxy",
                    Brand = "Samsung",
                    Cost = 12000,
                    Type =  "Mobile"
                },
                new Gadgets()
                {
                    Id = 2,
                    ProductName = "Iphone",
                    Brand = "Apple",
                    Cost = 13000,
                    Type =  "Mobile"
                },
                new Gadgets()
                {
                    Id = 3,
                    ProductName = "IBM Thinkpad",
                    Brand = "IBM",
                    Cost = 34999,
                    Type =  "Laptop"
                },
                new Gadgets()
                {
                    Id = 4,
                    ProductName = "HP ProBook",
                    Brand = "HP",
                    Cost = 21000,
                    Type =  "Laptop"
                },
                new Gadgets()
                {
                    Id = 5,
                    ProductName = "Nokia 9222",
                    Brand = "Nokia",
                    Cost = 11000,
                    Type =  "Mobile"
                }
            };

            //seed gadgets to the db
            modelBuilder.Entity<Gadgets>().HasData(gadgets);
        }
        }
}
