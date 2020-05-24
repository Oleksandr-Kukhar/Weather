using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Weather.Persistence.Infrastructure
{
    public class SensorsDataBaseContextFactory : IDesignTimeDbContextFactory<SensorsDataBaseContext>
    {
        public SensorsDataBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SensorsDataBaseContext>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SensorsDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(Assembly.GetAssembly(typeof(SensorsDataBaseContext)).GetName().Name));
            return new SensorsDataBaseContext(optionsBuilder.Options);
        }
    }
}
