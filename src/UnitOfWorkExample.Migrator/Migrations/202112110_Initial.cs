using FluentMigrator;

namespace UnitOfWorkExample.Migrator.Migrations
{
    [Migration(202112110)]
    public class Initial : Migration
    {
        public override void Up()
        {
            Create.Table("WeatherForecasts")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("TemperatureC").AsInt32().NotNullable()
                .WithColumn("Summary").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Table("WeatherForecasts");
        }
    }
}