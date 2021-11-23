using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var weatherForecast = modelBuilder.Entity<WeatherForecast>();

            weatherForecast.HasKey(wf => wf.Id);
            weatherForecast.Ignore(wf => wf.TemperatureF);
            weatherForecast.Property(wf => wf.Id);
            weatherForecast.Property(wf => wf.Date).IsRequired();
            weatherForecast.Property(wf => wf.TemperatureC).IsRequired();
            
            weatherForecast.OwnsOne(wf => wf.Summary, builder =>
            {
                builder.Property(s => s.Text)
                    .IsRequired()
                    .HasColumnName("Summary");
            });
        }
    }
}