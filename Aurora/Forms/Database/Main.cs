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
        private SqlDataAdapter _dataAdapter;
        private SqlConnection _dataBaseConnection;

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
            _objectsTabPage.Name = Tables.Objects.Name;
            _typesTabPage.Name = Tables.Types.Name;
            _interfacesTabPage.Name = Tables.Interfaces.Name;
            _OSTabPage.Name = Tables.OperatingSystems.Name;
            _locationTabPage.Name = Tables.Locations.Name;
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
            _dataGridView.Focus();
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
            if (Tables.Objects.Columns[e.ColumnIndex].IsComboBox)
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
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            _dataGridView.DataSource = null;

            string query = "SELECT * FROM " + "[" + _tabControl.SelectedTab.Name + "]";

            _dataSet.Tables[_tabControl.SelectedTab.Name]?.Clear();

            _sqlCommand = new SqlCommand(query, _dataBaseConnection);
            _dataAdapter = new SqlDataAdapter(_sqlCommand);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_dataAdapter);

            sqlCommandBuilder.GetInsertCommand();
            sqlCommandBuilder.GetDeleteCommand();
            sqlCommandBuilder.GetUpdateCommand();

            _dataAdapter.Fill(_dataSet, _tabControl.SelectedTab.Name);

            _dataGridView.DataSource = _dataSet.Tables[_tabControl.SelectedTab.Name];

            if (_tabControl.SelectedTab.Name == Tables.Objects.Name)
            {
                ReplaceOnComboBoxes(_dataGridView.Columns);
            }

            _dataGridView.Columns["ID"].ReadOnly = true;
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

        private void ReplaceOnComboBoxes(DataGridViewColumnCollection columnCollection)
        {
            var columnNames = new List<string>();
            foreach (DataGridViewColumn column in columnCollection)
            {
                columnNames.Add(column.Name);
            }

            Reader reader = new Reader(_dataBaseConnection);
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (Tables.Objects.Columns[columnNames[i]].IsComboBox)
                {
                    var comboBoxColumn = BoxConverter.ToComboBoxColumn(_dataGridView.Columns[columnNames[i]]);
                    comboBoxColumn.DataSource = reader.ToListByQuery($"SELECT [{columnNames[i]}] FROM [{columnNames[i]}s]");

                    _dataGridView.Columns.RemoveAt(i);
                    _dataGridView.Columns.Insert(i, comboBoxColumn);
                }
            }
        }
    }
}