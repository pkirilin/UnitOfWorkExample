using System.Threading;
using System.Threading.Tasks;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.EfCore.Repositories;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _context;

        public AppUnitOfWork(AppDbContext context)
        {
            _context = context;
            WeatherForecasts = new WeatherForecastsRepository(_context.WeatherForecasts);
        }
        
        public IWeatherForecastsRepository WeatherForecasts { get; }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}