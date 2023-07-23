using System.Data;
using MonitoringSystem.Config;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace MonitoringSystem.Forms.Database
{
    public partial class Main : Form
    {
        private SqlCommand? _sqlCommand;
        private SqlDataAdapter? _dataAdapter;
        private SqlConnection? _dataBaseConnection;

        private ServerSettings? _serverSettings;

        private DataSet? _dataSet;
        private List<TabPage>? _tabPages;

        public Main()
        {
            InitializeComponent();
        }

        private void InitTabPages()
        {
            _tabPages = new List<TabPage>();

            for (int i = 0; i < Tables.Items.Count; i++)
            {
                _tabPages.Add(new TabPage());
                _tabPages[i].SuspendLayout();

                _tabControl.Controls.Add(_tabPages[i]);

                _tabPages[i].Controls.Add(_dataGridView);

                _tabPages[i].Location = new System.Drawing.Point(4, 22);
                _tabPages[i].Name = Tables.Items[i].Name;
                _tabPages[i].Padding = new Padding(3);
                _tabPages[i].Size = new System.Drawing.Size(813, 439);
                _tabPages[i].TabIndex = i;
                _tabPages[i].Text = Tables.Items[i].Header;
                _tabPages[i].UseVisualStyleBackColor = true;
                _tabPages[i].ResumeLayout(false);
            }
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

            InitTabPages();
            _tabPages?[0].Controls.Add(_dataGridView);

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

            _dataAdapter?.Update(_dataSet, _tabControl.SelectedTab.Name);

            UpdateDataGridViewAsync();

            MessageBox.Show("База данных обновлена.");
        }

        private void OnButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateDataGridViewAsync();
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

        private void OnButtonResetClick(object sender, EventArgs e)
        {
            _textBoxSearch.Clear();
            UpdateDataGridViewAsync();
        }

        private void OnToolStripServerSettingsClick(object sender, EventArgs e)
        {
            _serverSettings?.Show();
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e) 
        {
            if (Tables.Items[_tabControl.SelectedIndex].Columns[e.ColumnIndex].IsComboBox)
                return;

            MessageBox.Show($"Введены неверные данные в строке: {e.RowIndex + 1}\nВ ячейке номер: {e.ColumnIndex + 1}");
        }

        private void OnTabPageSelected(object sender, TabControlEventArgs e)
        {
            e.TabPage?.Controls.Add(_dataGridView);
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

            string? query = "SELECT * FROM " + "[" + _tabControl.SelectedTab.Name + "]";

            using SqlConnection connection = new(Config.Database.ConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(query, connection);
            using SqlDataAdapter adapter = new(command);
            using SqlCommandBuilder sqlCommandBuilder = new(adapter);

            sqlCommandBuilder.GetInsertCommand();
            sqlCommandBuilder.GetDeleteCommand();
            sqlCommandBuilder.GetUpdateCommand();

            _dataSet?.Tables[_tabControl.SelectedTab.Name]?.Clear();

            await adapter.FillAsync(_dataSet, _tabControl.SelectedTab.Name);

            _dataGridView.DataSource = _dataSet.Tables[_tabControl.SelectedTab.Name];

            ReplaceOnComboBoxes(_tabControl.SelectedIndex);

            foreach (DataGridViewColumn column in _dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            _dataGridView.Columns["ID"].ReadOnly = true;
        }

        private void UpdateComboBox()
        {
            var columns = new List<string>();
            foreach (DataColumn column in _dataSet.Tables[_tabControl.SelectedTab.Name].Columns)
            {
                columns.Add(column.ColumnName);
            }
            _comboBox.DataSource = columns;
        }

        private void ReplaceOnComboBoxes(int TableIndex)
        {
            Reader? reader = new Reader(_dataBaseConnection);

            for (int j = 0; j < Tables.Items[TableIndex].Columns.Count; j++)
            {
                if (Tables.Items[TableIndex].Columns[j].IsComboBox)
                {
                    var comboBoxColumn = BoxConverter.ToComboBoxColumn(_dataGridView.Columns[j]);
                    var comboBoxData = new List<string> {"Не указано"};
                    comboBoxData.AddRange(reader.ToListByQuery($"SELECT [{Tables.Items[TableIndex].Columns[j].Name}] " +
                                                               $"FROM [{Tables.Items[TableIndex].Columns[j].Name}s]"));

                    comboBoxColumn.DataSource = comboBoxData;
                    _dataGridView.Columns.RemoveAt(j);
                    _dataGridView.Columns.Insert(j, comboBoxColumn);
                }
            }
        }
    }
}
