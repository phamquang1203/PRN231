using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_BusinessObject
{
    public class eStoreContext : DbContext
    {

        public eStoreContext() { }
        public eStoreContext(DbContextOptions options): base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =(local); database = TestDb3;uid=sa;pwd=123456;TrustServerCertificate=True;Trusted_Connection=True;");

            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(eBookStoreLibrary.eBookStoreApiConfiguration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.ToTable("BookAuthor");
                entity.HasKey("AuthorId", "BookId");
            });
            modelBuilder.Entity<Author>().ToTable("Author");
        }

    }
}
