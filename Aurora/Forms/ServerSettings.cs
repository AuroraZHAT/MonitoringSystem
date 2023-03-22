using Aurora.Config;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class ServerSettings : Form
    {
        public ServerSettings()
        {
            InitializeComponent();
        }

        private void OnServerSettingsLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsRegistryPathExist)
                RegistryConfig.CreateRegPath();

            textBoxServerName.Text = RegistryConfig.ServerName ?? "";
            textBoxDatabaseName.Text = RegistryConfig.DatabaseName ?? "";
            checkBoxIntegratedSecurity.Checked = RegistryConfig.IntegratedSecurity;
            checkBoxTrustServerCertificate.Checked = RegistryConfig.TrustServerCertificate;
        }

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            if (textBoxServerName.TextLength == 0 && textBoxDatabaseName.TextLength == 0)
                return;

            RegistryConfig.Load(textBoxServerName.Text, textBoxDatabaseName.Text, checkBoxIntegratedSecurity.Checked, checkBoxTrustServerCertificate.Checked);

            try
            {
                if (checkBoxCreateDataBase.Checked)
                    Config.Database.Create();

                if (checkBoxCreateTable.Checked)
                    Config.Database.CreateTables();

                Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }         
        }
    }
}
