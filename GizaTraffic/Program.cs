using GizaTraffic.DBContext;
using GizaTraffic.Repositories;
using Microsoft.EntityFrameworkCore;
using Utilities;
using Utilities.Forms;

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
                AppSettingsService settings = new();

                // -------------------------------------------------
                // FIRST RUN / DATABASE NOT CONFIGURED
                // -------------------------------------------------

                if (!settings.IsDatabaseConfigured())
                {
                    using frmDatabaseConfiguration form = new();
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        Helper.ShowMessage("Database configuration is required.");
                        return;
                    }
                }
                // -------------------------------------------------
                // GET DECRYPTED CONNECTION STRING
                // -------------------------------------------------
                string? connectionString = settings.GetConnectionString();
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    Helper.ShowMessage("The database connection is not configured.");
                    return;
                }
                // -------------------------------------------------
                // CREATE DB CONTEXT
                // -------------------------------------------------
                GizaTrafficDBContext dbContext = new DataContextFactory().CreateDbContext([]);
                dbContext.Database.Migrate();
                UnitOfWork unitOfWork = new(dbContext);
                ////-------------------------------------------------
                /// START LOGIN FORM
                /// -------------------------------------------------
                //Application.Run(new frmLogin(unitOfWork));
                //if (UserLogin.LoggedUserID > 0)
                // -------------------------------------------------
                // START MAIN FORM
                // -------------------------------------------------
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