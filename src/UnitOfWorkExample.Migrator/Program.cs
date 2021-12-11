using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitOfWorkExample.Migrator
{
    internal static class Program
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ENVIRONMENT");
        
        private static int Main()
        {
            try
            {
                var configuration = CreateConfiguration();
                var serviceProvider = CreateServiceProvider(configuration);
                UpdateDatabase(serviceProvider);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        private static IServiceProvider CreateServiceProvider(IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:MySql"];

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(builder => builder.AddMySql5()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(builder => builder.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static IConfiguration CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            if (Env == "Development")
                builder.AddJsonFile("appsettings.Development.json", optional: true);

            return builder.Build();
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
