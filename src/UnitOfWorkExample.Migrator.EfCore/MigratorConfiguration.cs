using Microsoft.Extensions.Configuration;

namespace UnitOfWorkExample.Migrator.EfCore
{
    public static class MigratorConfiguration
    {
        public static IConfiguration Instance { get; }
        
        static MigratorConfiguration()
        {
            Instance = InitConfiguration();
        }
        
        private static IConfiguration InitConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}