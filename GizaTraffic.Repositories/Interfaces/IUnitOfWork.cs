using GizaTraffic.DBContext;
using GizaTraffic.Models;
using GizaTraffic.Services.Interfaces;

namespace GizaTraffic.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        #region Database Context

        public GizaTrafficDBContext DBContext { get; }

        #endregion

        #region Repositories

        IRepository<VehicleImpound> repVehiclesImpounds { get; }
        IRepository<ProgramSetting> repProgramSettings { get; }
        

        #endregion

        #region Methods

        Task Complete();
        new void Dispose();

        #endregion

    }
}
