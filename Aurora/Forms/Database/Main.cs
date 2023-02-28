using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Aurora.Config;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.Database
{
    public partial class Main : Form
    {
        private SqlCommand _sqlCommand;
        private SqlDataReader _SqlDataReader;
        SqlConnection _dataBaseConnection;

        private ServerSettings _serverSettings = new ServerSettings();
        private Addition _addition = new Addition();
        private Deletion _deletion = new Deletion();

        private DataSet _dataSet = new DataSet();

        public Main()
        {
            InitializeComponent();
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsParametersExist)
                RegistryConfig.CreateRegPath();

            _dataBaseConnection = new SqlConnection(Config.Database.ConnectionString);
            while (true)
            {
                _dataBaseConnection.Open();

                if(_dataBaseConnection.State == ConnectionState.Open)
                    break;

                MessageBox.Show("Нет подключения к базе данных", "Ошибка");
                _serverSettings.ShowDialog();
            }

            UpdateDataGridView();
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateDataGridView();
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
            UpdateDataGridView();
        }

        private void ToolStripServerSetupClick(object sender, EventArgs e)
        {
            _serverSettings.ShowDialog();
        }

        private void ButtonNewWriteClick(object sender, EventArgs e)
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!");
                return;
            }



            List<string> objectTypes = new List<string>();
            List<string> operatingSystems = new List<string>();
            List<string> interfaces = new List<string>();
            List<string> mapLocations = new List<string>();

            GetComboBoxData(objectTypes, operatingSystems, interfaces, mapLocations);
            _addition.SetComboBoxData(objectTypes, operatingSystems, interfaces, mapLocations);
            _addition.ShowDialog();

            if (_addition.IsEachFilled())
            {
                InsertNewWrite(_addition.GetInput());

                UpdateDataGridView();
            }
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _deletion.ShowDialog();

            DeleteRow(_deletion.ID);
            UpdateDataGridView();
        }

        private void InsertNewWrite(in SQLObject sqlObject)
        {
            string query =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id]," +
            $" [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id]," +
            $" [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{sqlObject.Name}', {sqlObject.Type}, {sqlObject.OS}," +
            $" {sqlObject.Location}, NULL, NULL, {sqlObject.ConnectionInterface}," +
            $" NULL, '{sqlObject.Responsible}', '{sqlObject.Responsible}')";

            SqlCommand sqlCommand = new SqlCommand(query, _dataBaseConnection);
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
            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _SqlDataReader = _sqlCommand.ExecuteReader();

            while (_SqlDataReader.Read())
            {
                comboBox.Add(_SqlDataReader[1].ToString());
            }
            _SqlDataReader.Close();
        }

        private void UpdateDataGridView(string query = "SELECT * FROM objectView")
        {
            if (_dataSet.Tables["Objects"] != null)
                _dataSet.Tables["Objects"].Clear();

            SqlCommand SQLCommand = new SqlCommand(query, _dataBaseConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLCommand);
            sqlDataAdapter.Fill(_dataSet, "Objects");

            _dataGridView.DataSource = _dataSet.Tables["Objects"];
        }

        private void DeleteRow(int ID)
        {
            _sqlCommand = new SqlCommand($"DELETE FROM Object WHERE ID = {ID}", _dataBaseConnection);
            _SqlDataReader = _sqlCommand.ExecuteReader();
            _SqlDataReader.Close();
        }
    }
}
