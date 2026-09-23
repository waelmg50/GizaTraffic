using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GizaTraffic.DBContext
{
    public class DataContextFactory : IDesignTimeDbContextFactory<GizaTrafficDBContext>
    {
        public GizaTrafficDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<GizaTrafficDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection")).EnableSensitiveDataLogging(true).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            return new GizaTrafficDBContext(optionsBuilder.Options, configuration);
        }
    }
}
