using MonitoringSystem.Config;
using Microsoft.Data.SqlClient;

namespace MonitoringSystem.Forms
{
    public partial class ServerSettings : Form
    {
        public ServerSettings()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsRegistryPathExist)
                RegistryConfig.CreateRegPath();

            LoadSettings();
        }

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServerName.Text) || 
                string.IsNullOrEmpty(textBoxDatabaseName.Text))
                return;

            RegistryConfig.Load(textBoxServerName.Text, textBoxDatabaseName.Text, checkBoxIntegratedSecurity.Checked, checkBoxTrustServerCertificate.Checked);

            try
            {
                ApplySettings();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}\nКод ошибки: {ex.Errors}", "Не удалось применить изменения");
            }         
        }

        private void LoadSettings()
        {
            textBoxServerName.Text = RegistryConfig.ServerName ?? "";
            textBoxDatabaseName.Text = RegistryConfig.DatabaseName ?? "";
            checkBoxIntegratedSecurity.Checked = RegistryConfig.IntegratedSecurity;
            checkBoxTrustServerCertificate.Checked = RegistryConfig.TrustServerCertificate;
        }

        private void ApplySettings()
        {
            if (checkBoxCreateDataBase.Checked)
                Config.Database.Create();

            if (checkBoxCreateTable.Checked)
                Config.Database.CreateTables();

            Hide();
        }
    }
}
