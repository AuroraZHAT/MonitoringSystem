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
        public Main()
        {
            InitializeComponent();
        }

        private SqlCommand _sqlCommand;
        private SqlDataReader _SqlDataReader;
        private SqlDataAdapter _dataAdapter;
        private SqlConnection _dataBaseConnection;

        private ServerSettings _serverSettings;

        private DataSet _dataSet;

        private bool _isDelete = false;
        private int _selectedRowsAmount;

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsRegistryPathExist)
                RegistryConfig.CreateRegPath();

            _serverSettings = new ServerSettings();
            while (!Server.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                if (_serverSettings.ShowDialog() == DialogResult.Cancel)
                { 
                    Close();
                    return;
                }
            }

            _dataBaseConnection = new SqlConnection(Config.Database.ConnectionString);
            _dataBaseConnection.Open();

            _dataSet = new DataSet();

            UpdateDataGridView();

            _dataGridView.Columns[(int)Views.Columns.ID].ReadOnly = true;
        }

        private void OnButtonNewWriteClick(object sender, EventArgs e)
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            InsertNewWrite(_dataGridView.Rows[_dataGridView.RowCount - 2]);
            UpdateDataGridView();
        }

        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            _dataGridView.Focus();
            SendKeys.Send("{DELETE}");
        }

        private void OnButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void OnSearchButtonClick(object sender, EventArgs e)
        {
            string query = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                            $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                            $"Responsible, Installed) like '%" + _textBoxSearch.Text + "%'";

            UpdateDataGridView(query);
        }

        private void OnResetButtonClick(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            UpdateDataGridView();
        }

        private void OnToolStripServerSettingsClick(object sender, EventArgs e)
        {
            _serverSettings.ShowDialog();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            _isDelete =
            e.KeyCode == Keys.Delete && (_dataGridView.SelectedRows.Count > 0) &&
            MessageBox.Show("Вы точно хотите удалить выбранные строки?", "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK;

            _selectedRowsAmount = _dataGridView.SelectedRows.Count;
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e) 
        {
            MessageBox.Show($"Введены неверные данные в строке: {e.RowIndex + 1}\nВ ячейке номер: {e.ColumnIndex + 1}");
        }

        private void OnRowDeleting(object sender, DataGridViewRowCancelEventArgs e)
        {
            var id = e.Row.Cells["id"].Value;

            if (!_isDelete) return;
            else if (id.ToString() == "") return;

            string query = $"DELETE FROM Object WHERE id = {id}";

            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _sqlCommand.ExecuteNonQuery();
        }

        private void OnRowDeleted(object sender, DataGridViewRowEventArgs e)
        {
            --_selectedRowsAmount;
            if (_selectedRowsAmount > 0) return;

            UpdateDataGridView();
        }

        private void InsertNewWrite(DataGridViewRow row)
        {
            var type = row.Cells[(int)Views.Columns.Type] as DataGridViewComboBoxCell;
            var OS = row.Cells[(int)Views.Columns.OS] as DataGridViewComboBoxCell;
            var mapLocation = row.Cells[(int)Views.Columns.MapLocation] as DataGridViewComboBoxCell;
            var connectionInterface = row.Cells[(int)Views.Columns.Interface] as DataGridViewComboBoxCell;

            if (
                row.Cells[(int)Views.Columns.ObjectName].Value.ToString() == "" ||
                row.Cells[(int)Views.Columns.Responsible].Value.ToString() == "" ||
                row.Cells[(int)Views.Columns.InstalledBy].Value.ToString() == "" ||
                row.Cells[(int)Views.Columns.ID].Value.ToString() != ""
               )
            {
                MessageBox.Show("Введены не все данные!");
                return;
            }

            string query =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id]," +
            $" [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id]," +
            $" [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES (" +
            $"'{row.Cells[(int)Views.Columns.ObjectName].Value}', " +
            $"{type.Items.IndexOf(type.Value) + 1}, " +
            $"{OS.Items.IndexOf(OS.Value) + 1}," +
            $"{mapLocation.Items.IndexOf(mapLocation.Value) + 1}, " +
            $"'{row.Cells[(int)Views.Columns.IP].Value}', " +
            $"'{row.Cells[(int)Views.Columns.HVID].Value}', " +
            $"{connectionInterface.Items.IndexOf(connectionInterface.Value) + 1}," +
            $"'{row.Cells[(int)Views.Columns.LastDate].Value}'," +
            $"'{row.Cells[(int)Views.Columns.Responsible].Value}'," +
            $"'{row.Cells[(int)Views.Columns.InstalledBy].Value}')";

            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Добавлено!");
        }

        private List<string> ReadDatabase(string query)
        {
            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _SqlDataReader = _sqlCommand.ExecuteReader();
            var list = new List<string>(); 

            while (_SqlDataReader.Read())
            {
                list.Add(_SqlDataReader[1].ToString());
            }
            _SqlDataReader.Close();

            return list;
        }

        private void UpdateDataGridView(string query = "SELECT * FROM objectView")
        {
            _dataSet.Tables["Objects"]?.Clear();

            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _dataAdapter = new SqlDataAdapter(_sqlCommand);
            _dataAdapter.Fill(_dataSet, "Objects");

            _dataGridView.DataSource = _dataSet.Tables["Objects"];

            ReplaceOnComboBoxes();
        }

        private void ReplaceOnComboBoxes()
        {
            var types = ToComboBoxColumn(_dataGridView.Columns[(int)Views.Columns.Type]);
            var operatingSystems = ToComboBoxColumn(_dataGridView.Columns[(int)Views.Columns.OS]);
            var mapLocations = ToComboBoxColumn(_dataGridView.Columns[(int)Views.Columns.MapLocation]);
            var interfaces = ToComboBoxColumn(_dataGridView.Columns[(int)Views.Columns.Interface]);

            types.DataSource = ReadDatabase("SELECT * FROM ObjectsType");
            operatingSystems.DataSource = ReadDatabase("SELECT * FROM OS");
            mapLocations.DataSource = ReadDatabase("SELECT * FROM LocationMap");
            interfaces.DataSource = ReadDatabase("SELECT * FROM Interfaces");

            _dataGridView.Columns.RemoveAt((int)Views.Columns.Type);
            _dataGridView.Columns.Insert((int)Views.Columns.Type, types);

            _dataGridView.Columns.RemoveAt((int)Views.Columns.OS);
            _dataGridView.Columns.Insert((int)Views.Columns.OS, operatingSystems);

            _dataGridView.Columns.RemoveAt((int)Views.Columns.MapLocation);
            _dataGridView.Columns.Insert((int)Views.Columns.MapLocation, mapLocations);

            _dataGridView.Columns.RemoveAt((int)Views.Columns.Interface);
            _dataGridView.Columns.Insert((int)Views.Columns.Interface, interfaces);
        }

        private DataGridViewComboBoxColumn ToComboBoxColumn(DataGridViewColumn dataGridViewColumn)
        {
            var dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = dataGridViewColumn.HeaderText,
                Name = dataGridViewColumn.Name,
                DataPropertyName = dataGridViewColumn.DataPropertyName
            };

            return dataGridViewComboBoxColumn;
        }
    }
}
