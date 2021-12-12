using FluentNHibernate.Mapping;
using UnitOfWorkExample.Infrastructure.NHibernate.Entities;

namespace UnitOfWorkExample.Infrastructure.NHibernate.Mappings
{
    // ReSharper disable once UnusedType.Global
    internal class WeatherForecastMap : ClassMap<WeatherForecastPersistentEntity>
    {
        public WeatherForecastMap()
        {
            Table("WeatherForecasts");
            
            Id(x => x.Id);
            Map(x => x.Date);
            Map(x => x.TemperatureC);
            Map(x => x.Summary);
        }
    }
}