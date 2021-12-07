using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.Dapper.Extensions
{
    public static class InfrastructureDapperExtensions
    {
        public static void AddInfrastructureDapper(this IServiceCollection services)
        {
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
        }
    }
}