using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UnitOfWorkExample.Infrastructure.EfCore;

namespace UnitOfWorkExample.Migrator.EfCore
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = MigratorConfiguration.Get();
            var connectionString = configuration == null ? "" : configuration["ConnectionStrings:MySql"];
            var serverVersion = new MySqlServerVersion(new Version(5, 7));

            var options = new DbContextOptionsBuilder()
                .UseMySql(connectionString, serverVersion)
                .Options;
            
            return new AppDbContext(options);
        }
    }
}