using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Driver.MySqlConnector;

namespace UnitOfWorkExample.Infrastructure.NHibernate.Extensions
{
    public static class InfrastructureNHibernateExtensions
    {
        public static void AddInfrastructureNHibernate(this IServiceCollection services)
        {
            services.AddSessionFactory();
        }

        private static void AddSessionFactory(this IServiceCollection services)
        {
            services.AddSingleton<ISessionFactory>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration["ConnectionStrings:MySql"];
                
                return Fluently.Configure()
                    .Database(MySQLConfiguration.Standard
                        .ConnectionString(connectionString)
                        .Driver<MySqlConnectorDriver>())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
            });
        }
    }
}