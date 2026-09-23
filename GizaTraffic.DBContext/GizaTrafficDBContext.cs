//using GizaTraffic.DBContext.Migrations;
using GizaTraffic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GizaTraffic.DBContext
{
    public class GizaTrafficDBContext : DbContext
    {

        #region Members

        //private readonly IConfiguration _config;

        #endregion

        #region Constructor

        public GizaTrafficDBContext(DbContextOptions<GizaTrafficDBContext> options) : base(options)
        {
            //_config = config;
        }

        #endregion

        #region Models

        #region Basic Data

        public DbSet<ProgramSetting> ProgramSettings { get; set; }
        
        #endregion

        #region Operations

        public DbSet<VehicleImpound> VehiclesImpounds { get; set; }
        
        #endregion

        #endregion

        #region Overrided Methods

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DBConnection"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("Arabic_CI_AS");
        }

        #endregion

    }
}