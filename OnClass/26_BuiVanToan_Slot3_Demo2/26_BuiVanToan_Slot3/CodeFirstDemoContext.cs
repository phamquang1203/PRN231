using _26_BuiVanToan_Slot3.Models;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_Slot3
{


    public class CodeFirstDemoContext : DbContext
    {

        public CodeFirstDemoContext(DbContextOptions<CodeFirstDemoContext> options)
        : base(options) { }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }

        public DbSet<InstrumentType> InstrumentTypes { get; set; }
    }
}
