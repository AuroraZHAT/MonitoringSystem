using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.OS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
            string sqlCommand = "SELECT * FROM [ProjectAurora].[dbo].[OsView]";

            sqlConnection.Open();
            SqlDataAdapter dataAdapterLoad = new SqlDataAdapter(sqlCommand, sqlConnection);
            DataTable dataTableLoad = new DataTable();

            dataAdapterLoad.Fill(dataTableLoad);

            dataGridViewOs.DataSource = dataTableLoad;
            dataGridViewOs.Columns[0].Visible = false;
            dataGridViewOs.Columns[1].Visible = false;
            sqlConnection.Close();
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
            int rows = dataGridViewOs.CurrentRow.Index;
            int valueRows = Convert.ToInt32(dataGridViewOs[0, rows].Value);

            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
            SqlCommand command = new SqlCommand("DellOS", sqlConnection);

            sqlConnection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", valueRows));
            int returnValue = command.ExecuteNonQuery();
            if (returnValue != 2)
            {
                MessageBox.Show("Данный элемент используется, удаление запрещенно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            sqlConnection.Close();

            LoadData();
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            int rows = dataGridViewOs.CurrentRow.Index;
            Update osUpdateWindow = new Update(dataGridViewOs[2, rows].Value.ToString(),
                                                        Convert.ToInt32(dataGridViewOs[0, rows].Value));
            osUpdateWindow.TopMost = true;
            osUpdateWindow.ShowDialog();
            LoadData();
        }
    }
}
