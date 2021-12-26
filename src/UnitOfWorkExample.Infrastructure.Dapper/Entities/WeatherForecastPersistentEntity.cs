using System;
using Dapper.Contrib.Extensions;

namespace UnitOfWorkExample.Infrastructure.Dapper.Entities
{
    [Table("WeatherForecasts")]
    public class WeatherForecastPersistentEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}