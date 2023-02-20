using Aurora.Config;
using System;
using System.Windows.Forms;
using static Aurora.Config.Server;

namespace Aurora.Forms
{
    public partial class ServerSettings : Form
    {
        public ServerSettings()
        {
            InitializeComponent();
            GetParameters();
        }

        private void GetParameters()
        {
            if (RegistryConfig.IsRegistryPathExist)
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

            //if (!Config.Database.ConnectionExist)
            //{
            //    MessageBox.Show("Проверьте параметры конфигуратора!\nОтсутствует подключение к базе данных!");
            //    return;
            //}

            if (checkBoxCreateDataBase.Checked)
                Config.Database.Create();
            if (checkBoxCreateTable.Checked)
                Config.Database.TablesCreate();
            if (checkBoxCreateView.Checked)
                Config.Database.ViewsCreate();

            this.Hide();
        }
    }
}
