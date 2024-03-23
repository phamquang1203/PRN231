using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_Slot12_Demo10.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    

    }
}
