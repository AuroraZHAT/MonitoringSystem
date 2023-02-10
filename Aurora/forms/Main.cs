using System;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aurora
{
    public partial class Main : Form
    {
        private SQL _SQL = new SQL();

        private DataTable _dataTable = new DataTable();

        private ServerSetUpForm _serverSetUp = new ServerSetUpForm();
        private NewWriteForm _newWrite = new NewWriteForm();
        private DeleteForm _delete = new DeleteForm();

        private string _query;

        private SqlCommand sqlCommand;
        private SqlDataReader _SqlDataReader;



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

            _query = "SELECT * FROM objectView";
            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, _dataGridView);
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            _query = "SELECT * FROM objectView";
            InjectQuery(_SQL.DatabaseConnectionString, _query, _dataTable, _dataGridView);
        }

        private void ButtonNewWriteClick(object sender, EventArgs e)
        {
            if(!_SQL.DatabaseConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!");
                return;
            }

            string objectName;
            string responsible;
            string installedBy;
            int type;
            int OS;
            int connectionInterface;
            int location;

            List<string> ObjectTypes = new List<string>();
            List<string> OperatingSystems = new List<string>();
            List<string> Interfaces = new List<string>();
            List<string> LocationMaps = new List<string>();

            SqlConnection dataBaseConnection = new SqlConnection(_SQL.DatabaseConnectionString);
            dataBaseConnection.Open();

            GetComboBoxData(dataBaseConnection, ObjectTypes, OperatingSystems, Interfaces, LocationMaps);

            _newWrite.GetData(ObjectTypes, OperatingSystems, Interfaces, LocationMaps);
            _newWrite.ShowDialog();
            _newWrite.SetData(out objectName, out responsible, out installedBy,
                             out type, out OS, out connectionInterface, out location);

            InsertData(objectName, responsible, installedBy, type, OS, connectionInterface, location);


            dataBaseConnection.Close();
        }

        private void InsertData(string objectName, string responsible, string installedBy,
                                int type, int OS, int connectionInterface, int location)
        {
            SqlConnection dataBaseConnection = new SqlConnection(_SQL.DatabaseConnectionString);

            dataBaseConnection.Open();
            string query =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id], [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id], [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{objectName}', {type}, {OS}, {location}, NULL, NULL, {connectionInterface}, NULL, '{responsible}', '{installedBy}')";

            SqlCommand sqlCommand = new SqlCommand(query, dataBaseConnection);

            sqlCommand.Parameters.AddWithValue("ObjectName", objectName);
            sqlCommand.Parameters.AddWithValue("Responsible", responsible);
            sqlCommand.Parameters.AddWithValue("InstalledBy", installedBy);
            sqlCommand.Parameters.AddWithValue("ObjectType_id", type);
            sqlCommand.Parameters.AddWithValue("OS_id", OS);
            sqlCommand.Parameters.AddWithValue("Interfaces_id", connectionInterface);
            sqlCommand.Parameters.AddWithValue("LocationMap_id", location);
            sqlCommand.ExecuteNonQuery();

            dataBaseConnection.Close();

            MessageBox.Show("Добавлено!");
        }

        private void GetComboBoxData(SqlConnection dataBaseConnection, List<string> ObjectTypes, List<string> OperatingSystems, 
                                     List<string> Interfaces, List<string> LocationMaps)
        {
            _query = "SELECT * FROM ObjectsType";
            ReadDataBase(_query, dataBaseConnection, ObjectTypes);

            _query = "SELECT * FROM OS";
            ReadDataBase(_query, dataBaseConnection, OperatingSystems);
            
            _query = "SELECT * FROM Interfaces";
            ReadDataBase(_query, dataBaseConnection, Interfaces);

            _query = "SELECT * FROM LocationMap";
            ReadDataBase(_query, dataBaseConnection, LocationMaps);
        }

        private void ReadDataBase(string query, SqlConnection dataBaseConnection, List<string> comboBox)
        {
            sqlCommand = new SqlCommand(query, dataBaseConnection);
            _SqlDataReader = sqlCommand.ExecuteReader();

            while (_SqlDataReader.Read())
            {
                comboBox.Add(_SqlDataReader[1].ToString());
            }
            _SqlDataReader.Close();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _delete.ShowDialog();
        }

        private void TextBoxSearchTextChanged(object sender, EventArgs e)
        {

            string query = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                            $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                            $"Responsible, Installed) like '%" + _textBoxSearch.Text + "%'";

            InjectQuery(_SQL.DatabaseConnectionString, query, _dataTable, _dataGridView);
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
