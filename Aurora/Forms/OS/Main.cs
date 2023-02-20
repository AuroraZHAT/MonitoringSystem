using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.OS
{
    public partial class OsMain : Form
    {
        private SQLConfig _SQLConfig = new SQLConfig();

        public OsMain()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;
            string sqlCommand = "SELECT * FROM [ProjectAurora].[dbo].[OsView]";

            SqlConnection connection = new SqlConnection(sqlConnection);

            connection.Open();
            SqlDataAdapter dataAdapterLoad = new SqlDataAdapter(sqlCommand, sqlConnection);
            DataTable dataTableLoad = new DataTable();

            dataAdapterLoad.Fill(dataTableLoad);

            dataGridViewOs.DataSource = dataTableLoad;
            dataGridViewOs.Columns[0].Visible = false;
            dataGridViewOs.Columns[1].Visible = false;
            connection.Close();
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            OsAdd osAddWindow = new OsAdd();

            osAddWindow.TopMost = true;
            osAddWindow.ShowDialog();
            LoadData();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;

            int rows = dataGridViewOs.CurrentRow.Index;
            int valueRows = Convert.ToInt32(dataGridViewOs[0, rows].Value);

            SqlConnection connection = new SqlConnection(sqlConnection);
            SqlCommand command = new SqlCommand("DellOS", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", valueRows));
            int returnValue = command.ExecuteNonQuery();
            if (returnValue != 2)
            {
                MessageBox.Show("Данный элемент используется, удаление запрещенно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();

            LoadData();
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            int rows = dataGridViewOs.CurrentRow.Index;
            OsUpdate osUpdateWindow = new OsUpdate(dataGridViewOs[2, rows].Value.ToString(),
                                                        Convert.ToInt32(dataGridViewOs[0, rows].Value));
            osUpdateWindow.TopMost = true;
            osUpdateWindow.ShowDialog();
            LoadData();
        }
    }
}
