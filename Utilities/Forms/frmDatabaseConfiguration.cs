using Microsoft.Data.SqlClient;

namespace Utilities.Forms
{
    public partial class frmDatabaseConfiguration : Form
    {

        #region Constructor

        public frmDatabaseConfiguration()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private string BuildConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = txtServer.Text.Trim(),
                InitialCatalog = txtDatabase.Text.Trim() == string.Empty ? "master" : txtDatabase.Text.Trim(),
                TrustServerCertificate = true,
                Encrypt = false
            };
            if (rbWindowsAuthentication.Checked)
            {
                // Windows Authentication
                builder.IntegratedSecurity = true;
            }
            else
            {
                // SQL Server Authentication
                builder.UserID = txtUsername.Text.Trim();
                builder.Password = txtPassword.Text;
            }
            return builder.ConnectionString;
        }
        
        // ==========================================================
        // BUILD SERVER-ONLY CONNECTION STRING
        // ==========================================================

        private string BuildServerConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = txtServer.Text.Trim(),

                // Connect to master instead of the
                // database that may not exist yet.
                InitialCatalog = "master",

                TrustServerCertificate = true,

                Encrypt = false
            };

            if (rbWindowsAuthentication.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID =
                    txtUsername.Text.Trim();

                builder.Password =
                    txtPassword.Text;
            }

            return builder.ConnectionString;
        }
        private void ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text))
                Helper.ShowMessage("Please enter the SQL Server name.");

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
                Helper.ShowMessage("Please enter the database name.");

            if (rbSqlAuthentication.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    Helper.ShowMessage("Please enter the username.");

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    Helper.ShowMessage("Please enter the password.");
            }
        }

        #endregion

        #region Events Handlers

        private async void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();

                string connectionString = BuildServerConnectionString();

                btnTest.Enabled = false;
                btnSave.Enabled = false;

                await using SqlConnection connection = new(connectionString);

                await connection.OpenAsync();

                Helper.ShowMessage("Sql Server connection successful.");
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            finally
            {
                btnTest.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();

                // IMPORTANT:
                // Test against master, not the GizaTraffic database.
                string serverConnectionString = BuildServerConnectionString();

                btnTest.Enabled = false;
                btnSave.Enabled = false;

                await using (SqlConnection connection = new(serverConnectionString))
                {
                    await connection.OpenAsync();
                }

                // Build the REAL connection string.
                // This one contains Database from the text box.
                string connectionString = BuildConnectionString();

                // Encrypt and save it.
                AppSettingsService settings = new();
                settings.SaveConnectionString(connectionString);

                Helper.ShowMessage("Database configuration saved successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            finally
            {
                btnTest.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void Authentication_CheckedChanged(object sender, EventArgs e)
        {
            bool sqlAuthentication = rbSqlAuthentication.Checked;
            txtUsername.Enabled = sqlAuthentication;
            txtPassword.Enabled = sqlAuthentication;
            if (!sqlAuthentication)
            {
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        #endregion

        
    }
}
