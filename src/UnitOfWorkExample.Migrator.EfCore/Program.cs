using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UnitOfWorkExample.Migrator.EfCore
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            
            try
            {
                RunMigrator(args);
                return 0;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while applying migrations");
                return -1;
            }
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddLogging(builder => builder
                    .AddConsole()
                    .AddConfiguration(MigratorConfiguration.Instance))
                .BuildServiceProvider();
        }

        private static void RunMigrator(string[] args)
        {
            var contextFactory = new AppDbContextFactory();
            using var context = contextFactory.CreateDbContext(args);
            context.Database.Migrate();
        }
    }
}