using System;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.ValueObjects;

namespace UnitOfWorkExample.Domain.Entities
{
    public class WeatherForecast : EntityBase<int>
    {
        public DateTime Date { get; private set; }

        public int TemperatureC { get; private set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public WeatherForecastSummary Summary { get; private set; }
        
        public WeatherForecast()
        {
        }

        // ReSharper disable once UnusedMember.Local
        private WeatherForecast(int id) : base(id)
        {
        }

        public WeatherForecast SetDate(DateTime date)
        {
            Date = date;
            return this;
        }
        
        public WeatherForecast SetCelciusTemperature(int temperatureC)
        {
            TemperatureC = temperatureC;
            return this;
        }
        
        public WeatherForecast SetSummary(string summaryText)
        {
            Summary = new WeatherForecastSummary(summaryText);
            return this;
        }
    }
}
