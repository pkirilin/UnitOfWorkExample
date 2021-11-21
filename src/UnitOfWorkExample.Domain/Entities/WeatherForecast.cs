using System;

namespace UnitOfWorkExample.Domain.Entities
{
    public class WeatherForecast
    {
        // ReSharper disable once UnusedMember.Local
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        
        // ReSharper disable once EmptyConstructor
        public WeatherForecast()
        {
        }
    }
}
