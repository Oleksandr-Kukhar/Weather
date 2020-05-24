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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SensorsDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var seedTemperature = new Temperature()
            {
                Id = Guid.NewGuid(),
                Value = 14,
                RegisterTime = DateTime.Now,
                MeasurementUnits = "Kelvin"
            };

            var seedPressure = new Pressure()
            { 
                Id = Guid.NewGuid(),
                Value = 1010,
                RegisterTime = DateTime.Now,
                MeasurementUnits = "hPa"
            };

            var seedHumidity = new Humidity()
            {
                Id = Guid.NewGuid(),
                Value = 50,
                RegisterTime = DateTime.Now,
                MeasurementUnits = "%"
            };

            var seedWind = new Wind()
            {
                Id = Guid.NewGuid(),
                Speed = 5,
                Direction = 0,
                RegisterTime = DateTime.Now,
                MeasurementUnits = "m/s"
            };

            //Dlya togo shob buli yakis dani
            modelBuilder.Entity<Temperature>().HasData(seedTemperature);
            modelBuilder.Entity<Pressure>().HasData(seedPressure);
            modelBuilder.Entity<Humidity>().HasData(seedHumidity);
            modelBuilder.Entity<Wind>().HasData(seedWind);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
