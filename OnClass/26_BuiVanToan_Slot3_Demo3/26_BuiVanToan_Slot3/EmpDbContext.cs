using _26_BuiVanToan_Slot3.Models;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_Slot3
{
  public class EmpDbContext:DbContext{ 
	public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        DbSet<Employees> Employees { get; set; } = null!;
} 
}
