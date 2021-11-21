using Microsoft.Extensions.Configuration;

namespace UnitOfWorkExample.Migrator.EfCore
{
    public static class MigratorConfiguration
    {
        public static IConfiguration Get()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}