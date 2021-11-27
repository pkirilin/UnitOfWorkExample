using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Entities;

[assembly:InternalsVisibleTo("UnitOfWorkExample.Migrator.EfCore")]

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    internal class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;

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