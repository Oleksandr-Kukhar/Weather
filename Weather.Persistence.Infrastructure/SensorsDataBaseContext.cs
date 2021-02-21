using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure
{
    public partial class SensorsDataBaseContext : DbContext
    {
        public SensorsDataBaseContext()
        {
        }

        public SensorsDataBaseContext(DbContextOptions<SensorsDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humidity> Humidity { get; set; }
        public virtual DbSet<Pressure> Pressure { get; set; }
        public virtual DbSet<Temperature> Temperature { get; set; }
        public virtual DbSet<Model.Wind> Wind { get; set; }
        public virtual DbSet<CriticalValues> CriticalValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CriticalValues minTemp = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 278,
                ValueName = "MinimalTemperature"
            };
            CriticalValues maxTemp = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 288,
                ValueName = "MaximalTemperature"
            };
            CriticalValues minHum = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 30,
                ValueName = "MinimalHumidity"
            };
            CriticalValues maxHum = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 100,
                ValueName = "MaximalHumidity"
            };
            CriticalValues minPress = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 1000,
                ValueName = "MinimalPressure"
            };
            CriticalValues maxPress = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 1100,
                ValueName = "MaximalPressure"
            };
            CriticalValues minSpd = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 0,
                ValueName = "MinimalWindSpeed"
            };
            CriticalValues maxSpd = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 10,
                ValueName = "MaximalWindSpeed"
            };


            CriticalValues minRealTemp = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 278,
                ValueName = "MinimalRealTemperature"
            };
            CriticalValues maxRealTemp = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 288,
                ValueName = "MaximalRealTemperature"
            };
            CriticalValues minRealHum = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 30,
                ValueName = "MinimalRealHumidity"
            };
            CriticalValues maxRealHum = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 100,
                ValueName = "MaximalRealHumidity"
            };
            CriticalValues minRealPress = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 1000,
                ValueName = "MinimalRealPressure"
            };
            CriticalValues maxRealPress = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 1100,
                ValueName = "MaximalRealPressure"
            };
            CriticalValues minRealSpd = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 0,
                ValueName = "MinimalRealWindSpeed"
            };
            CriticalValues maxRealSpd = new CriticalValues()
            {
                Id = Guid.NewGuid(),
                Value = 10,
                ValueName = "MaximalRealWindSpeed"
            };
            modelBuilder.Entity<CriticalValues>().HasData(new CriticalValues[] { 
                minSpd, maxSpd, minPress, maxPress, minHum, maxHum, minTemp, maxTemp,
                minRealSpd, maxRealSpd, minRealPress, maxRealPress, minRealHum, maxRealHum, minRealTemp, maxRealTemp,
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
