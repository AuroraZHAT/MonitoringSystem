using System.Data;
using MonitoringSystem.Config;
using Microsoft.Data.SqlClient;

namespace MonitoringSystem.Forms.Database
{
    public partial class Main : Form
    {
        private readonly SqlDataAdapter _dataAdapter;
        private readonly SqlConnection _dataBaseConnection;
        private readonly ServerSettings _serverSettings;

        private readonly DataSet _dataSet;
        private readonly List<TabPage> _tabPages;

        public Main()
        {
            InitializeComponent();

            _dataAdapter = new();
            _dataBaseConnection = new();
            _serverSettings = new();
            _dataSet = new();
            _tabPages = new();
            InitTabPages();
        }

        private void InitTabPages()
        {
            for (int i = 0; i < Tables.Items.Count; i++)
            {
                TabPage tabPage = new()
                {
                    Location = new(4, 22),
                    Name = Tables.Items[i].Name,
                    Padding = new(3),
                    Size = new(813, 439),
                    TabIndex = i,
                    Text = Tables.Items[i].Header,
                    UseVisualStyleBackColor = true
                };

                tabPage.Controls.Add(_dataGridView);
                _tabPages.Add(tabPage);
                _tabControl.Controls.Add(tabPage);
            }
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            if (!RegistryConfig.IsRegistryPathExist)
                RegistryConfig.CreateRegPath();

            while (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                if (_serverSettings.ShowDialog() == DialogResult.Cancel)
                { 
                    Application.Exit();
                    return;
                }
            }

            _dataBaseConnection.ConnectionString = Config.Database.ConnectionString;
            _dataBaseConnection.Open();
            
            _tabPages[0].Controls.Add(_dataGridView);

            UpdateDataGridViewAsync();
            UpdateComboBox();
        }



        private void OnButtonLoadClick(object sender, EventArgs e)
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            _dataAdapter.Update(_dataSet, _tabControl.SelectedTab.Name);

            UpdateDataGridViewAsync();

            MessageBox.Show("База данных обновлена.");
        }

        private void OnButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateDataGridViewAsync();
        }

        private void OnButtonSearchClick(object sender, EventArgs e)
        {
            string columnName = Convert.ToString(_comboBox.SelectedItem);
            string searchValue = _textBoxSearch.Text;

            foreach (DataGridViewRow row in _dataGridView.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.Index != _dataGridView.NewRowIndex))
            {
                row.Selected = row.Cells[columnName].Value.ToString().Contains(searchValue);
            }

            _dataGridView.Focus();
        }

        private void OnButtonResetClick(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            UpdateDataGridViewAsync();
        }

        private void OnToolStripServerSettingsClick(object sender, EventArgs e)
        {
            _serverSettings.Show();
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e) 
        {
            if (Tables.Items[_tabControl.SelectedIndex].Columns[e.ColumnIndex].IsComboBox)
                return;

            MessageBox.Show($"Введены неверные данные в строке: {e.RowIndex + 1}\nВ ячейке номер: {e.ColumnIndex + 1}");
        }

        private void OnTabPageSelected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Controls.Add(_dataGridView);
        }

        private void OnTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewAsync();
            UpdateComboBox();
        }


        private async Task UpdateDataGridViewAsync()
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            _dataGridView.DataSource = null;

            string query = "SELECT * FROM " + "[" + _tabControl.SelectedTab.Name + "]";

            using SqlConnection connection = new(Config.Database.ConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(query, connection);
            using SqlDataAdapter adapter = new(command);
            using SqlCommandBuilder sqlCommandBuilder = new(adapter);

            sqlCommandBuilder.GetInsertCommand();
            sqlCommandBuilder.GetDeleteCommand();
            sqlCommandBuilder.GetUpdateCommand();

            _dataSet.Tables[_tabControl.SelectedTab.Name]?.Clear();

            await adapter.FillAsync(_dataSet, _tabControl.SelectedTab.Name);

            _dataGridView.DataSource = _dataSet.Tables[_tabControl.SelectedTab.Name];

            ReplaceOnComboBoxes(_tabControl.SelectedIndex);

            foreach (DataGridViewColumn column in _dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            _dataGridView.Columns["ID"].ReadOnly = true;
        }

        private void UpdateComboBox()
        {
            var columns = _dataSet.Tables[_tabControl.SelectedTab.Name].Columns.Cast<DataColumn>()
                            .Select(column => column.ColumnName)
                            .ToList();

            _comboBox.DataSource = columns;
        }

        private void ReplaceOnComboBoxes(int tableIndex)
        {
            string defaultComboBoxValue = "Не указано";

            Reader reader = new(_dataBaseConnection);

            for (int j = 0; j < Tables.Items[tableIndex].Columns.Count; j++)
            {
                var column = Tables.Items[tableIndex].Columns[j];
                if (column.IsComboBox)
                {
                    var comboBoxColumn = BoxConverter.ToComboBoxColumn(_dataGridView.Columns[j]);
                    var comboBoxData = new List<string> { defaultComboBoxValue };
                    comboBoxData.AddRange(reader.ToListByQuery($"SELECT [{column.Name}] FROM [{column.Name}s]"));

                    comboBoxColumn.DataSource = comboBoxData;
                    _dataGridView.Columns.RemoveAt(j);
                    _dataGridView.Columns.Insert(j, comboBoxColumn);
                }
            }
        }
    }
}
