using System;
using Dapper.Contrib.Extensions;

namespace UnitOfWorkExample.Infrastructure.Dapper.Contribs
{
    [Table("WeatherForecasts")]
    public class WeatherForecastContrib
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}