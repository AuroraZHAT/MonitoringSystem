using Aurora;
using System;
using System.Windows.Forms;

namespace AuroraGit.ServerSetUp
{
    public partial class ServerSetUpConf : Form
    {
        SQLConfig SQL = new SQLConfig();

        public string serverName;
        public string databaseName;
        public bool integratedSecurity = true;
        public bool trustServerCertificate = true;
        public ServerSetUpConf()
        {
            InitializeComponent();
            CheckParameters();
        }

        private void CheckParameters()
        {
            if (SQL.Config.IsParametersExist)
            {
                SQL.Config.Unload(textBoxServername.Text, textBoxDBname.Text);
                textBoxServername.Text = SQL.Config.ServerName;
                textBoxDBname.Text = SQL.Config.DatabaseName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxServername.TextLength > 0 &&
                textBoxDBname.TextLength > 0)
            {
                serverName = textBoxServername.Text;
                databaseName = textBoxDBname.Text;

                SQL.Config.Load(serverName, databaseName);

                MessageBox.Show("Создание базы данных - " + SQL.CreateDataBase());
                MessageBox.Show("Строка подключения к базе данных - " + SQL.DatabaseConnectionString);

                CreateTableAndView();
                Main form = new Main();
                form.Show();
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
