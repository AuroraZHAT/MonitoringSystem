using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Aurora.Config;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms
{
    public partial class Database : Form
    {
        private Server _server = new Server();
        private SQLObject _sqlObject;
        
        private SqlCommand sqlCommand;
        private SqlDataReader _SqlDataReader;
        SqlConnection _dataBaseConnection;

        private ServerSettings _serverSettings = new ServerSettings();
        private Addition _addition = new Addition();
        private Deletion _deletion = new Deletion();

        private DataTable _dataTable = new DataTable();

        public Database()
        {
            InitializeComponent();
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!_server.Config.IsParametersExist || !_server._Database.ConnectionExist)
            {
                _server.Config.CreateRegPath();
                _serverSettings.ShowDialog();
            }

            _dataBaseConnection = new SqlConnection(_server._Database.ConnectionString);
            _dataBaseConnection.Open();
            UpdateDataGridView("SELECT * FROM objectView");
            _dataBaseConnection.Close();
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            _dataBaseConnection.Open();
            UpdateDataGridView("SELECT * FROM objectView");
            _dataBaseConnection.Close();
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            string query = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                            $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                            $"Responsible, Installed) like '%" + _textBoxSearch.Text + "%'";

            UpdateDataGridView(query);
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            UpdateDataGridView("SELECT * FROM objectView");
        }

        private void ToolStripServerSetupClick(object sender, EventArgs e)
        {
            _serverSettings.ShowDialog();
        }

        private void ButtonNewWriteClick(object sender, EventArgs e)
        {
            if (!_server._Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!");
                return;
            }

            List<string> objectTypes = new List<string>();
            List<string> operatingSystems = new List<string>();
            List<string> interfaces = new List<string>();
            List<string> mapLocations = new List<string>();

            _dataBaseConnection.Open();

            GetComboBoxData(objectTypes, operatingSystems, interfaces, mapLocations);
            _addition.SetComboBoxData(objectTypes, operatingSystems, interfaces, mapLocations);
            _addition.ShowDialog();

            if (_addition.IsEachFilled())
            {
                _sqlObject = _addition.GetInput();
                InsertNewWrite(in _sqlObject);

                UpdateDataGridView("SELECT * FROM objectView");
            }

            _dataBaseConnection.Close();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _deletion.ShowDialog();
        }

        private void InsertNewWrite(in SQLObject sqlObject)
        {
            string query =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id]," +
            $" [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id]," +
            $" [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{sqlObject.Name}', {sqlObject.Type}, {sqlObject.OS}," +
            $" {sqlObject.Location}, NULL, NULL, {sqlObject.ConnectionInterface}," +
            $" NULL, '{_sqlObject.Responsible}', '{sqlObject.Responsible}')";

            SqlCommand sqlCommand = new SqlCommand(query, _dataBaseConnection);

            sqlCommand.Parameters.AddWithValue("ObjectName", sqlObject.Name);
            sqlCommand.Parameters.AddWithValue("Responsible", _sqlObject.Responsible);
            sqlCommand.Parameters.AddWithValue("InstalledBy", sqlObject.Responsible);
            sqlCommand.Parameters.AddWithValue("ObjectType_id", sqlObject.Type);
            sqlCommand.Parameters.AddWithValue("OS_id", sqlObject.OS);
            sqlCommand.Parameters.AddWithValue("Interfaces_id", sqlObject.ConnectionInterface);
            sqlCommand.Parameters.AddWithValue("LocationMap_id", sqlObject.Location);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Добавлено!");
        }

        private void GetComboBoxData(List<string> objectTypes, List<string> operatingSystems, 
                                     List<string> interfaces, List<string> mapLocations)
        {
            ReadDatabase("SELECT * FROM ObjectsType", objectTypes);

            ReadDatabase("SELECT * FROM OS", operatingSystems);
            
            ReadDatabase("SELECT * FROM Interfaces", interfaces);

            ReadDatabase("SELECT * FROM LocationMap", mapLocations);
        }

        private void ReadDatabase(string query, List<string> comboBox)
        {
            sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _SqlDataReader = sqlCommand.ExecuteReader();

            while (_SqlDataReader.Read())
            {
                comboBox.Add(_SqlDataReader[1].ToString());
            }
            _SqlDataReader.Close();
        }

        private void UpdateDataGridView(string query)
        {
            _dataTable.Clear();

            SqlCommand SQLCommand = new SqlCommand(query, _dataBaseConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLCommand);
            sqlDataAdapter.Fill(_dataTable);

            _dataGridView.DataSource = _dataTable;
        }

    }
}
