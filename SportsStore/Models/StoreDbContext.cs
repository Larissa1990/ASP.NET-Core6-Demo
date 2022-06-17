using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;

namespace SportsStore.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public static readonly LoggerFactory factory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLoggerFactory(factory);
        }
    }
}
