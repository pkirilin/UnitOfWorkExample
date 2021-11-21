using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitOfWorkExample.Infrastructure.EfCore.Extensions
{
    public static class InfrastructureEfCoreExtensions
    {
        public static void AddInfrastructureEfCore(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, builder) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration["ConnectionStrings:MySql"];
                var serverVersion = new MySqlServerVersion(new Version(5, 7));
                
                builder.UseMySql(connectionString, serverVersion);
            });
        }
    }
}