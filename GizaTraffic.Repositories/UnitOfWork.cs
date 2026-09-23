using GizaTraffic.DBContext;
using GizaTraffic.Models;
using GizaTraffic.Repositories.Interfaces;
using GizaTraffic.Services.Interfaces;

namespace GizaTraffic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Members

        public readonly GizaTrafficDBContext _dataContext;
        public GizaTrafficDBContext DBContext { get { return _dataContext; } }

        IRepository<VehicleImpound>? _repVehiclesImpounds;
        IRepository<ProgramSetting>? _repProgramSettings;
        
        #endregion

        #region Constructor

        public UnitOfWork(GizaTrafficDBContext dataContext) => _dataContext = dataContext;

        #endregion

        #region Repositories
                
        public IRepository<VehicleImpound> repVehiclesImpounds { get => _repVehiclesImpounds ??= new Repository<VehicleImpound>(_dataContext); }
        public IRepository<ProgramSetting> repProgramSettings { get => _repProgramSettings ??= new Repository<ProgramSetting>(_dataContext); }
        
        #endregion

        #region Methods

        public async Task Complete()
        {
            await _dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
