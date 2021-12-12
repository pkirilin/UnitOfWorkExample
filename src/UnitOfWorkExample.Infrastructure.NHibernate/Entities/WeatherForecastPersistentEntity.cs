using System;

namespace UnitOfWorkExample.Infrastructure.NHibernate.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    internal class WeatherForecastPersistentEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int TemperatureC { get; set; }

        public virtual string? Summary { get; set; }
    }
}