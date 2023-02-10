using System;
using System.Windows.Forms;

namespace Aurora
{
    public partial class ServerSetUp : Form
    {
        SQL SQL = new SQL();

        private string _serverName;
        private string _databaseName;
        private bool _integratedSecurity;
        private bool _trustServerCertificate;
        public ServerSetUp()
        {
            InitializeComponent();
            CheckParameters();
        }

        private void CheckParameters()
        {
            if (SQL.Config.IsParametersExist)
            {
                SQL.Config.Unload(out _serverName, out _databaseName, ref _integratedSecurity, ref _trustServerCertificate);
                textBoxServerName.Text = _serverName;
                textBoxDatabaseName.Text = _databaseName;
                checkBoxIntegratedSecurity.Checked = _integratedSecurity;
                checkBoxTrustServerCertificate.Checked = _trustServerCertificate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxServerName.TextLength > 0 && textBoxDatabaseName.TextLength > 0)
            {
                _serverName = textBoxServerName.Text;
                _databaseName = textBoxDatabaseName.Text;
                _integratedSecurity = checkBoxIntegratedSecurity.Checked;
                _trustServerCertificate = checkBoxTrustServerCertificate.Checked;

                SQL.Config.Load(_serverName, _databaseName, _integratedSecurity, _trustServerCertificate);
                SQL.ApplyConfig();
                MessageBox.Show("Создание базы данных - " + SQL.CreateDataBase());
                MessageBox.Show("Строка подключения к базе данных - " + SQL.DatabaseConnectionString);

                CreateTables();
                CreateViews();

                this.Close();
            }
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
