using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora
{
    public partial class Main : Form
    {
        private SQL _SQL = new SQL();
        
        private SqlCommand sqlCommand;
        private SqlDataReader _SqlDataReader;
        SqlConnection _dataBaseConnection;

        private ServerSetUpForm _serverSetUpForm = new ServerSetUpForm();
        private NewWriteForm _newWriteForm = new NewWriteForm();
        private DeleteForm _deleteForm = new DeleteForm();

        private DataTable _dataTable = new DataTable();

        public Main()
        {
            InitializeComponent();
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            _SQL.ApplyConfig();
            if (!_SQL.Config.IsParametersExist || !_SQL.DatabaseConnectionExist)
            {
                _SQL.Config.CreateRegPath();
                _serverSetUpForm.ShowDialog();
            }

            _dataBaseConnection = new SqlConnection(_SQL.DatabaseConnectionString);
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
            _serverSetUpForm.ShowDialog();
        }

        private void ButtonNewWriteClick(object sender, EventArgs e)
        {
            if (!_SQL.DatabaseConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!");
                return;
            }

            List<string> ObjectTypes = new List<string>();
            List<string> OperatingSystems = new List<string>();
            List<string> Interfaces = new List<string>();
            List<string> LocationMaps = new List<string>();

            _dataBaseConnection.Open();

            GetComboBoxData(ObjectTypes, OperatingSystems, Interfaces, LocationMaps);
            _newWriteForm.SetComboBoxData(ObjectTypes, OperatingSystems, Interfaces, LocationMaps);
            _newWriteForm.ShowDialog();

            if (_newWriteForm.IsEachFilled())
            {
                _newWriteForm.GetInput(out string objectName, out string responsible, out string installedBy,
                                       out int type, out int OS, out int connectionInterface, out int location);
                InsertNewWrite(objectName, responsible, installedBy, type, OS, connectionInterface, location);

                UpdateDataGridView("SELECT * FROM objectView");
            }

            _dataBaseConnection.Close();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _deleteForm.ShowDialog();
        }

        private void InsertNewWrite(string objectName, string responsible, string installedBy,
                                int type, int OS, int connectionInterface, int location)
        {
            string query =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id], [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id], [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{objectName}', {type}, {OS}, {location}, NULL, NULL, {connectionInterface}, NULL, '{responsible}', '{installedBy}')";

            SqlCommand sqlCommand = new SqlCommand(query, _dataBaseConnection);

            sqlCommand.Parameters.AddWithValue("ObjectName", objectName);
            sqlCommand.Parameters.AddWithValue("Responsible", responsible);
            sqlCommand.Parameters.AddWithValue("InstalledBy", installedBy);
            sqlCommand.Parameters.AddWithValue("ObjectType_id", type);
            sqlCommand.Parameters.AddWithValue("OS_id", OS);
            sqlCommand.Parameters.AddWithValue("Interfaces_id", connectionInterface);
            sqlCommand.Parameters.AddWithValue("LocationMap_id", location);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Добавлено!");
        }

        private void GetComboBoxData(List<string> ObjectTypes, List<string> OperatingSystems, 
                                     List<string> Interfaces, List<string> LocationMaps)
        {
            ReadDataBase("SELECT * FROM ObjectsType", ObjectTypes);

            ReadDataBase("SELECT * FROM OS", OperatingSystems);
            
            ReadDataBase("SELECT * FROM Interfaces", Interfaces);

            ReadDataBase("SELECT * FROM LocationMap", LocationMaps);
        }

        private void ReadDataBase(string query, List<string> comboBox)
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
