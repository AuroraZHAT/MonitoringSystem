using System.Data;
using MonitoringSystem.Config;
using Microsoft.Data.SqlClient;

namespace MonitoringSystem.Forms.Database
{
    public partial class Main : Form
    {
        private readonly ServerSettings _serverSettings;

        private readonly DataSet _dataSet;
        private readonly List<TabPage> _tabPages;

        public Main()
        {
            InitializeComponent();

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

        private async void OnLoad(object sender, EventArgs e)
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
            
            _tabPages[0].Controls.Add(_dataGridView);

            await UpdateAsync();
        }

        private async void OnButtonLoadClickAsync(object sender, EventArgs e)
        {
            if (!Config.Database.ConnectionExist)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка");
                return;
            }

            string query = "SELECT * FROM " + "[" + _tabControl.SelectedTab.Name + "]";

            using SqlConnection connection = new(Config.Database.ConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(query, connection);
            using SqlDataAdapter adapter = new(command);
            using SqlCommandBuilder sqlCommandBuilder = new(adapter);

            sqlCommandBuilder.GetInsertCommand();
            sqlCommandBuilder.GetDeleteCommand();
            sqlCommandBuilder.GetUpdateCommand();

            adapter.Update(_dataSet, _tabControl.SelectedTab.Name);
            await connection.CloseAsync();

            await UpdateAsync();

            MessageBox.Show("База данных обновлена.");
        }

        private async void OnButtonRefreshClickAsync(object sender, EventArgs e)
        {
            await UpdateAsync();
        }

        private void OnButtonSearchClick(object sender, EventArgs e)
        {
            string? columnName = Convert.ToString(_comboBox.SelectedItem);
            string searchValue = _textBoxSearch.Text;

            foreach (DataGridViewRow row in _dataGridView.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.Index != _dataGridView.NewRowIndex))
            {
                row.Selected = row.Cells[columnName].Value.ToString().Contains(searchValue);
            }

            _dataGridView.Focus();
        }

        private async void OnButtonResetClickAsync(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            await UpdateAsync();
        }

        private void OnToolStripServerSettingsClick(object sender, EventArgs e)
        {
            _serverSettings.Show();
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e) 
        {
            var grid = sender as DataGridView;
            if (grid?.ColumnCount != Tables.Items[_tabControl.SelectedIndex].Columns.Count)
                return;

            if (Tables.Items[_tabControl.SelectedIndex].Columns[e.ColumnIndex].IsComboBox)
                return;

            MessageBox.Show($"Введены неверные данные в строке: {e.RowIndex + 1}\nВ ячейке номер: {e.ColumnIndex + 1}");
        }

        private void OnTabPageSelected(object sender, TabControlEventArgs e)
        {
            e.TabPage?.Controls.Add(_dataGridView);
        }

        private async void OnTabControlSelectedIndexChangedAsync(object sender, EventArgs e)
        {
            await UpdateAsync();
        }

        private async Task UpdateAsync()
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

            _dataSet.Tables[_tabControl.SelectedTab.Name]?.Clear();

            await adapter.FillAsync(_dataSet, _tabControl.SelectedTab.Name);
            await connection.CloseAsync();

            _dataGridView.DataSource = _dataSet.Tables[_tabControl.SelectedTab.Name];


            await ReplaceOnComboBoxesAsync(_tabControl.SelectedIndex);
            UpdateSearchComboBox();

            foreach (DataGridViewColumn column in _dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            _dataGridView.Columns["ID"].ReadOnly = true;
        }

        private void UpdateSearchComboBox()
        {
            var columns = _dataSet.Tables[_tabControl.SelectedTab.Name]?.Columns.Cast<DataColumn>()
                            .Select(column => column.ColumnName)
                            .ToList();

            _comboBox.DataSource = columns;
        }

        private async Task ReplaceOnComboBoxesAsync(int tableIndex)
        {
            string defaultComboBoxValue = "Не указано";

            using SqlConnection connection = new(Config.Database.ConnectionString);
            await connection.OpenAsync();

            Reader reader = new(connection);

            for (int i = 0; i < Tables.Items[tableIndex].Columns.Count; i++)
            {
                var column = Tables.Items[tableIndex].Columns[i];
                if (column.IsComboBox)
                {
                    var comboBoxColumn = BoxConverter.ToComboBoxColumn(_dataGridView.Columns[i]);
                    var comboBoxData = new List<string> { defaultComboBoxValue };
                    comboBoxData.AddRange(reader.ToListByQuery($"SELECT [{column.Name}] FROM [{column.Name}s]"));

                    comboBoxColumn.DataSource = comboBoxData;
                    _dataGridView.Columns.RemoveAt(i);
                    _dataGridView.Columns.Insert(i, comboBoxColumn);
                }
            }

            await connection.CloseAsync();
        }
    }
}
