using Aurora.Config;
using System;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class ServerSettings : Form
    {
        private Server _server = new Server();

        public ServerSettings()
        {
            InitializeComponent();
            GetParameters();
        }

        private void GetParameters()
        {
            
            textBoxServerName.Text = _server.Config.ServerName;
            textBoxDatabaseName.Text = _server.Config.DatabaseName;
            checkBoxIntegratedSecurity.Checked = _server.Config.IntegratedSecurity;
            checkBoxTrustServerCertificate.Checked = _server.Config.TrustServerCertificate;
        }

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            if (textBoxServerName.TextLength == 0 && textBoxDatabaseName.TextLength == 0)
                return;

            _server.Config.Load(textBoxServerName.Text, textBoxDatabaseName.Text, checkBoxIntegratedSecurity.Checked, checkBoxTrustServerCertificate.Checked);

            bool f = _server.ConnectionExist;

            _server._Database.Create();
            _server._Database.TablesCreate();
            _server._Database.ViewsCreate();
   
            this.Hide();
        }
    }
}
