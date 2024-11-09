using Microsoft.EntityFrameworkCore;

namespace Assignment_DMAWS.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OrderTbl> Orders { get; set; }
    }
}
