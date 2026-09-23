using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Utilities;

namespace GizaTraffic.DBContext
{
    public class DataContextFactory : IDesignTimeDbContextFactory<GizaTrafficDBContext>
    {
        public GizaTrafficDBContext CreateDbContext(string[] args)
        {
            AppSettingsService settings = new();
            string? connectionString = settings.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Database connection string is not configured.");
            }
            var optionsBuilder = new DbContextOptionsBuilder<GizaTrafficDBContext>();
            optionsBuilder.UseSqlServer(connectionString).EnableSensitiveDataLogging(false).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            return new GizaTrafficDBContext(optionsBuilder.Options);
        }
    }
}
