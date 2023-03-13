using System;
using System.Collections;
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
        private SqlDataAdapter _dataAdapter;
        private SqlConnection _dataBaseConnection;
        private SqlCommandBuilder _sqlCommandBuilder;

        private ServerSettings _serverSettings;

        private DataSet _dataSet;

        private int _rowIndex;

        public Main()
        {
            InitializeComponent();
            InitTabPages();
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsRegistryPathExist)
                RegistryConfig.CreateRegPath();

            _serverSettings = new ServerSettings();
            while (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                if (_serverSettings.ShowDialog() == DialogResult.Cancel)
                { 
                    Application.Exit();
                    return;
                }
            }

            _dataBaseConnection = new SqlConnection(Config.Database.ConnectionString);
            _dataBaseConnection.Open();

            _dataSet = new DataSet();

            UpdateDataGridView();
            UpdateComboBox();
        }

        private void InitTabPages()
        {
            _objectsTabPage.Name = Tables.OBJECTS_TABLE_NAME;
            _typesTabPage.Name = Tables.OBJECT_TYPES_TABLE_NAME;
            _interfacesTabPage.Name = Tables.INTERFACES_TABLE_NAME;
            _OSTabPage.Name = Tables.OS_TABLE_NAME;
            _locationTabPage.Name = Tables.LOCATIONS_TABLE_NAME;
        }

        private void OnButtonLoadClick(object sender, EventArgs e)
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            _dataAdapter.Update(_dataSet, _tabControl.SelectedTab.Name);

            UpdateDataGridView();

            MessageBox.Show("База данных обновлена.");
        }

        private void OnButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void OnButtonSearchClick(object sender, EventArgs e)
        {
            string columnName = Convert.ToString(_comboBox.SelectedItem);
            string searchValue = _textBoxSearch.Text;
                
            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[columnName].Value?.ToString().Contains(searchValue) == true)
                {
                    row.Selected = true;
                }
            }
        }

        private void OnButtonResetClick(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            UpdateDataGridView();
        }

        private void OnToolStripServerSettingsClick(object sender, EventArgs e)
        {
            _serverSettings.ShowDialog();
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e) 
        {
            if (IsComboBoxColumn(e.ColumnIndex))
                return;

            MessageBox.Show($"Введены неверные данные в строке: {e.RowIndex + 1}\nВ ячейке номер: {e.ColumnIndex + 1}");
        }

        private void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > _dataSet.Tables[_tabControl.SelectedTab.Name].Rows.Count - 1)
            {
                DataRow dataRow = _dataSet.Tables[_tabControl.SelectedTab.Name].NewRow();
                dataRow[e.ColumnIndex] = _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                _dataSet.Tables[_tabControl.SelectedTab.Name].Rows.Add(dataRow);
                _dataGridView.Rows.RemoveAt(e.RowIndex + 1);
                _dataGridView.Rows.RemoveAt(e.RowIndex + 1);
            }

            _dataSet.Tables[_tabControl.SelectedTab.Name].Rows[e.RowIndex][e.ColumnIndex] =
            _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void OnRowDeleting(object sender, DataGridViewRowCancelEventArgs e)
        {
            _rowIndex = e.Row.Index;
        }

        private void OnRowDeleted(object sender, DataGridViewRowEventArgs e)
        {
            _dataSet.Tables[_tabControl.SelectedTab.Name].Rows[_rowIndex].Delete();
        }

        private void OnTabPageSelected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Controls.Add(_dataGridView);
            UpdateDataGridView();
            UpdateComboBox();
        }

        private void UpdateDataGridView()
        {
            ArrayList empty = new ArrayList();
            _dataGridView.DataSource = empty;

            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            string query = "SELECT * FROM " + "[" + _tabControl.SelectedTab.Name + "]";

            _dataSet.Tables[_tabControl.SelectedTab.Name]?.Clear();

            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _dataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlCommandBuilder = new SqlCommandBuilder(_dataAdapter);

            _sqlCommandBuilder.GetInsertCommand();
            _sqlCommandBuilder.GetDeleteCommand();
            _sqlCommandBuilder.GetUpdateCommand();

            _dataAdapter.Fill(_dataSet, _tabControl.SelectedTab.Name);

            _dataGridView.DataSource = _dataSet.Tables[_tabControl.SelectedTab.Name];

            if (_tabControl.SelectedTab.Name == Tables.OBJECTS_TABLE_NAME)
            {
                ReplaceOnComboBoxes();
            }

            _dataGridView.Columns[Tables.ID].ReadOnly = true;
        }

        private void UpdateComboBox()
        {
            var list = new List<string>();
            foreach (DataColumn column in _dataSet.Tables[_tabControl.SelectedTab.Name].Columns)
            {
                list.Add(column.ColumnName);
            }
            _comboBox.DataSource = list;
        }

        private void ReplaceOnComboBoxes()
        {
            var types = ToComboBoxColumn(_dataGridView.Columns[(int)Tables.Columns.Type]);
            var operatingSystems = ToComboBoxColumn(_dataGridView.Columns[(int)Tables.Columns.OS]);
            var mapLocations = ToComboBoxColumn(_dataGridView.Columns[(int)Tables.Columns.Location]);
            var interfaces = ToComboBoxColumn(_dataGridView.Columns[(int)Tables.Columns.Interface]);

            types.DataSource = Read($"SELECT [{Tables.TYPE_NAME}] FROM [{Tables.OBJECT_TYPES_TABLE_NAME}]");
            operatingSystems.DataSource = Read($"SELECT [{Tables.OS_NAME}] FROM [{Tables.OS_TABLE_NAME}]");
            mapLocations.DataSource = Read($"SELECT [{Tables.LOCATION_NAME}] FROM [{Tables.LOCATIONS_TABLE_NAME}]");
            interfaces.DataSource = Read($"SELECT [{Tables.INTERFACE_NAME}] FROM [{Tables.INTERFACES_TABLE_NAME}]");

            _dataGridView.Columns.RemoveAt((int)Tables.Columns.Type);
            _dataGridView.Columns.Insert((int)Tables.Columns.Type, types);

            _dataGridView.Columns.RemoveAt((int)Tables.Columns.OS);
            _dataGridView.Columns.Insert((int)Tables.Columns.OS, operatingSystems);

            _dataGridView.Columns.RemoveAt((int)Tables.Columns.Location);
            _dataGridView.Columns.Insert((int)Tables.Columns.Location, mapLocations);

            _dataGridView.Columns.RemoveAt((int)Tables.Columns.Interface);
            _dataGridView.Columns.Insert((int)Tables.Columns.Interface, interfaces);
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

        private bool IsComboBoxColumn(int columnIndex)
        {
            return columnIndex == (int)Tables.Columns.Type ||
                   columnIndex == (int)Tables.Columns.OS ||
                   columnIndex == (int)Tables.Columns.Location ||
                   columnIndex == (int)Tables.Columns.Interface;
        }

        private List<string> Read(string query)
        {
            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _SqlDataReader = _sqlCommand.ExecuteReader();
            var list = new List<string>();

            while (_SqlDataReader.Read())
            {
                list.Add(_SqlDataReader[0].ToString());
            }
            _SqlDataReader.Close();

            return list;
        }
    }
}