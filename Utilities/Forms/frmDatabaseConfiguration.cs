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
                InitialCatalog = txtDatabase.Text.Trim(),
                UserID = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                TrustServerCertificate = true,
                Encrypt = false
            };

            return builder.ConnectionString;
        }
        private void ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text))
                Helper.ShowMessage("Please enter the SQL Server name.");

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
                Helper.ShowMessage("Please enter the database name.");

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                Helper.ShowMessage("Please enter the username.");

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                Helper.ShowMessage("Please enter the password.");
        }

        #endregion

        #region Events Handlers

        private async void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();

                string connectionString = BuildConnectionString();

                btnTest.Enabled = false;

                await using SqlConnection connection = new(connectionString);

                await connection.OpenAsync();

                Helper.ShowMessage("Database connection successful.");
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            finally
            {
                btnTest.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();

                string connectionString = BuildConnectionString();

                btnSave.Enabled = false;

                // Test before saving.
                using SqlConnection connection = new(connectionString);
                connection.Open();

                // Save encrypted connection string.
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
                btnSave.Enabled = true;
            }
        }

        #endregion

    }
}
