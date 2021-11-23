using System;
using System.Linq;

namespace UnitOfWorkExample.Domain.ValueObjects
{
    public class WeatherForecastSummary
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public string Text { get; }

        public WeatherForecastSummary(string text)
        {
            var trimmedText = text.Trim();

            if (!Summaries.Contains(trimmedText))
                throw new InvalidOperationException($"Wrong weather forecast summary text '{trimmedText}'");
            
            Text = trimmedText;
        }
    }
}