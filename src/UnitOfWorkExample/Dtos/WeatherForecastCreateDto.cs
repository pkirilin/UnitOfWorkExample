using System;

namespace UnitOfWorkExample.Dtos
{
    public class WeatherForecastCreateDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}