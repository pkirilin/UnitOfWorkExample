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
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = MigratorConfiguration.Get();
            var connectionString = configuration == null ? "" : configuration["ConnectionStrings:MySql"];
            var serverVersion = new MySqlServerVersion(new Version(5, 7));

            var options = new DbContextOptionsBuilder()
                .UseMySql(connectionString, serverVersion, builder =>
                {
                    builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                })
                // TODO: how to use ILogger here?
                .LogTo(Console.WriteLine, LogLevel.Information)
                .Options;
            
            return new AppDbContext(options);
        }
    }
}