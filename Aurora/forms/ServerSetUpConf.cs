using Aurora;
using ServerSetUp;
using System;
using System.Windows.Forms;

namespace ServerSetUp
{
    public partial class ServerSetUpConf : Form
    {
        SQLConfig SQL = new SQLConfig();

        public string serverName;
        public string databaseName;
        public bool integratedSecurity;
        public bool trustServerCertificate;
        public ServerSetUpConf()
        {
            InitializeComponent();
            CheckParameters();
        }

        private void CheckParameters()
        {
            if (SQL.Config.IsParametersExist)
            {
                SQL.Config.Unload(out serverName, out databaseName, ref integratedSecurity, ref trustServerCertificate);
                textBoxServername.Text = serverName;
                textBoxDBname.Text = databaseName;
                checkBoxIntegratedSecurity.Checked = integratedSecurity;
                checkBoxTrustServerCertificate.Checked = trustServerCertificate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxServername.TextLength > 0 &&
                textBoxDBname.TextLength > 0)
            {
                serverName = textBoxServername.Text;
                databaseName = textBoxDBname.Text;
                integratedSecurity = checkBoxIntegratedSecurity.Checked;
                trustServerCertificate = checkBoxTrustServerCertificate.Checked;

                SQL.Config.Load(serverName, databaseName, integratedSecurity, trustServerCertificate);
                SQL.ApplyConfig();
                MessageBox.Show("Создание базы данных - " + SQL.CreateDataBase());
                MessageBox.Show("Строка подключения к базе данных - " + SQL.DatabaseConnectionString);

                CreateTableAndView();
                this.Close();
            }
        }

        private void CreateTableAndView()
        {
            SQL.CreateTableInaterfaces();
            SQL.CreateTableLocationMap();
            SQL.CreateTableObject();
            SQL.CreateTableObjectType();
            SQL.CreateTableOS();
            SQL.CreateObjectView();
        }
    }
}
