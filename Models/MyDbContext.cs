using Microsoft.EntityFrameworkCore;

namespace MyNamespace.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyModel> Araclar { get; set; }
    }
}
