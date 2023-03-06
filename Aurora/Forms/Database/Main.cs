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

        private bool _isDelete = false;
        private int _selectedRowsAmount;

        private SqlCommand _sqlCommand;
        private SqlDataReader _SqlDataReader;
        private SqlDataAdapter _dataAdapter;
        private SqlConnection _dataBaseConnection;

        private ServerSettings _serverSettings;

        private DataSet _dataSet;

        

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsParametersExist)
                RegistryConfig.CreateRegPath();

            while (!Server.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных", "Ошибка");
                _serverSettings.ShowDialog();
            }

            _dataBaseConnection = new SqlConnection(Config.Database.ConnectionString);
            _dataBaseConnection.Open();

            _serverSettings = new ServerSettings();

            _dataSet = new DataSet();

            UpdateDataGridView();
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

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
                _isDelete = 
                e.KeyCode == Keys.Delete && (_dataGridView.SelectedRows.Count > 0) && 
                MessageBox.Show("Вы точно хотите удалить выбранные строки?", "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK;

                _selectedRowsAmount = _dataGridView.SelectedRows.Count;
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

        private void ToolStripServerSettingsClick(object sender, EventArgs e)
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

            InsertNewWrite();

            UpdateDataGridView();
        }

        private void InsertNewWrite()
        {
            var rowIndex = _dataGridView.NewRowIndex - 1;

            var ID = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.ID];
            var objectName = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.ObjectName];
            var type = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.Type] as DataGridViewComboBoxCell;
            var OS = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.OS] as DataGridViewComboBoxCell;
            var mapLocation = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.MapLocation] as DataGridViewComboBoxCell;
            var IP = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.IP];
            var hvid = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.HVID];
            var connectionInterface = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.Interface] as DataGridViewComboBoxCell;
            var lastDate = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.LastDate];
            var responsible = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.Responsible];
            var installedBy = _dataGridView.Rows[rowIndex].Cells[(int)Views.Columns.InstalledBy];

            if (
                objectName.Value.ToString() == "" || 
                responsible.Value.ToString() == "" || 
                installedBy.Value.ToString() == "" || 
                ID.Value.ToString() != ""
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
            $"'{objectName.Value}', " +
            $"{type.Items.IndexOf(type.Value) + 1}, " +
            $"{OS.Items.IndexOf(OS.Value) + 1}," +
            $"{mapLocation.Items.IndexOf(mapLocation.Value) + 1}, " +
            $"'{IP.Value}', " +
            $"'{hvid.Value}', " +
            $"{connectionInterface.Items.IndexOf(connectionInterface.Value) + 1}," +
            $"'{lastDate.Value}'," +
            $"'{responsible.Value}'," +
            $"'{installedBy.Value}')";

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
            var types = ToComboBoxColumn(_dataGridView.Columns[2]);
            var operatingSystems = ToComboBoxColumn(_dataGridView.Columns[3]);
            var locationMaps = ToComboBoxColumn(_dataGridView.Columns[4]);
            var interfaces = ToComboBoxColumn(_dataGridView.Columns[7]);

            types.DataSource = ReadDatabase("SELECT * FROM ObjectsType");
            operatingSystems.DataSource = ReadDatabase("SELECT * FROM OS");
            locationMaps.DataSource = ReadDatabase("SELECT * FROM LocationMap");
            interfaces.DataSource = ReadDatabase("SELECT * FROM Interfaces");

            _dataGridView.Columns.RemoveAt(2);
            _dataGridView.Columns.Insert(2, types);

            _dataGridView.Columns.RemoveAt(3);
            _dataGridView.Columns.Insert(3, operatingSystems);

            _dataGridView.Columns.RemoveAt(4);
            _dataGridView.Columns.Insert(4, locationMaps);

            _dataGridView.Columns.RemoveAt(7);
            _dataGridView.Columns.Insert(7, interfaces);
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

        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            _dataGridView.Focus();
            SendKeys.Send("{DELETE}");
        }
    }
}
