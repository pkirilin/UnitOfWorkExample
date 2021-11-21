using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}