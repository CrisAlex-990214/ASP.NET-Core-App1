using ASPNetCoreApp1.Core;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreApp1.Data
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options)
            : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
