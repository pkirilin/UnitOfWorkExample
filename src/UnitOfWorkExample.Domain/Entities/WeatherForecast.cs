using System;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.ValueObjects;

namespace UnitOfWorkExample.Domain.Entities
{
    public class WeatherForecast : EntityBase<int>
    {
        public DateTime Date { get; }

        public int TemperatureC { get; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public WeatherForecastSummary Summary { get; }

        // ReSharper disable once UnusedMember.Local
        private WeatherForecast() : base(default)
        {
        }

        // ReSharper disable once UnusedMember.Local
        private WeatherForecast(int id) : base(id)
        {
        }

        public WeatherForecast(DateTime date, int temperatureC, string summaryText) : this(default)
        {
            Date = date;
            TemperatureC = temperatureC;
            Summary = new WeatherForecastSummary(summaryText);
        }
    }
}
