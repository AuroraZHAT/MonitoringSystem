using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora
{
    public partial class Main : Form
    {
        private SQL _SQL = new SQL();

        private DataTable _dataTable = new DataTable();
        private ServerSetUp _serverSetUp = new ServerSetUp();
        NewWrite _newWrite = new NewWrite();
        Delete _delete = new Delete();

        private readonly string _query = "SELECT * FROM objectView";



        public Main()
        {
            InitializeComponent();
            LoadData();
        }
        
        private void LoadData()
        {
            _SQL.ApplyConfig();
            if (!_SQL.Config.IsParametersExist || !_SQL.DatabaseConnectionExist)
            {
                _SQL.Config.CreateRegPath();
                _serverSetUp.ShowDialog();
            }

            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, dataGridView);
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, dataGridView);
        }

        private void ButtonNewWriteClick(object sender, EventArgs e)
        {
            _newWrite.ShowDialog();
            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, dataGridView);
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _delete.Show();
            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, dataGridView);
        }

        private void TextBoxSearchTextChanged(object sender, EventArgs e)
        {

            string query = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                            $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                            $"Responsible, Installed) like '%" + textBoxSearch.Text + "%'";

            InjectQuery(_SQL.DatabaseConnectionString, query, _dataTable, dataGridView);

        }

        private void ToolStripMenuItemClick(object sender, EventArgs e)
        {
            _serverSetUp.ShowDialog();
        }

        private void InjectQuery(string databaseConnectionString, string query, DataTable dataTable, DataGridView dataGridView)
        {
            if(!_SQL.DatabaseConnectionExist)
            {
                MessageBox.Show("Нет подключения!");
                return;
            }

            dataTable.Clear();

            SqlConnection dataBaseConnection = new SqlConnection(databaseConnectionString);

            dataBaseConnection.Open();

            SqlCommand SQLCommand = new SqlCommand(query, dataBaseConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLCommand);
            sqlDataAdapter.Fill(dataTable);

            dataBaseConnection.Close();

            dataGridView.DataSource = dataTable;
        }
    }
}
