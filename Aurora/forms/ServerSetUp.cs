using System;
using System.Windows.Forms;

namespace Aurora
{
    public partial class ServerSetUpForm : Form
    {
        SQL SQL = new SQL();

        private string _serverName;
        private string _databaseName;
        private bool _integratedSecurity;
        private bool _trustServerCertificate;
        public ServerSetUpForm()
        {
            InitializeComponent();
            GetParameters();
        }

        private void GetParameters()
        {
            SQL.Config.Unload(out _serverName, out _databaseName, ref _integratedSecurity, ref _trustServerCertificate);
            textBoxServerName.Text = _serverName;
            textBoxDatabaseName.Text = _databaseName;
            checkBoxIntegratedSecurity.Checked = _integratedSecurity;
            checkBoxTrustServerCertificate.Checked = _trustServerCertificate;
        }

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            if (textBoxServerName.TextLength > 0 && textBoxDatabaseName.TextLength > 0)
                return;

            _serverName = textBoxServerName.Text;
            _databaseName = textBoxDatabaseName.Text;
            _integratedSecurity = checkBoxIntegratedSecurity.Checked;
            _trustServerCertificate = checkBoxTrustServerCertificate.Checked;

            SQL.Config.Load(_serverName, _databaseName, _integratedSecurity, _trustServerCertificate);
            SQL.ApplyConfig();

            CreateTables();
            CreateViews();

            this.Hide();
        }

        private void CreateTables()
        {
            SQL.CreateTableInaterfaces();
            SQL.CreateTableLocationMap();
            SQL.CreateTableObject();
            SQL.CreateTableObjectType();
            SQL.CreateTableOS();

        }

        private void CreateViews()
        {
            SQL.CreateObjectView();
        }
    }
}
