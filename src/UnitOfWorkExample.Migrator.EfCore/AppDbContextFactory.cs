using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using UnitOfWorkExample.Infrastructure.EfCore;

namespace UnitOfWorkExample.Migrator.EfCore
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private static readonly ILoggerFactory CustomLoggerFactory = LoggerFactory
            .Create(builder => builder
                .AddConsole()
                .AddConfiguration(MigratorConfiguration.Instance));
        
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = MigratorConfiguration.Instance;
            var connectionString = configuration == null ? "" : configuration["ConnectionStrings:MySql"];
            var serverVersion = new MySqlServerVersion(new Version(5, 7));
            
            var options = new DbContextOptionsBuilder()
                .UseMySql(connectionString, serverVersion, builder =>
                {
                    builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                })
                .UseLoggerFactory(CustomLoggerFactory)
                .Options;
            
            return new AppDbContext(options);
        }
    }
}