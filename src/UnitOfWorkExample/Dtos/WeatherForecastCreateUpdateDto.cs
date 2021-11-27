using System;
using System.Diagnostics.CodeAnalysis;

namespace UnitOfWorkExample.Dtos
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class WeatherForecastCreateUpdateDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}