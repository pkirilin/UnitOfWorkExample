using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}