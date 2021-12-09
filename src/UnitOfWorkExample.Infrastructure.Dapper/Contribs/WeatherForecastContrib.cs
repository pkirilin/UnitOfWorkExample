using System;

namespace UnitOfWorkExample.Infrastructure.Dapper.Contribs
{
    public class WeatherForecastContrib<TId> : ContribBase<TId>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}