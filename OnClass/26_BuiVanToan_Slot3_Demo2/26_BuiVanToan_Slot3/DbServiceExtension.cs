using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_Slot3
{


    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
=> services.AddDbContext<CodeFirstDemoContext>(options => options.UseSqlServer(connectionString));
    }

}
