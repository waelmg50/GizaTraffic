using GizaTraffic.DBContext;
using GizaTraffic.Repositories;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace GizaTraffic
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                GizaTrafficDBContext dbContext = new DataContextFactory().CreateDbContext(Array.Empty<string>());
                dbContext.Database.Migrate();
                UnitOfWork unitOfWork = new(dbContext);
                //Application.Run(new frmLogin(unitOfWork));
                //if (UserLogin.LoggedUserID > 0)
                Application.Run(new frmMain(unitOfWork));
                unitOfWork.Dispose();
            }
            catch(Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }
    }
}