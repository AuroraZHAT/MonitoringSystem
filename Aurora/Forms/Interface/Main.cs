using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace Aurora.Forms.Interface
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
            string sqlCommand = "SELECT * FROM [ProjectAurora].[dbo].[InterfaceView]";

            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);

            sqlConnection.Open();
            SqlDataAdapter dataAdapterLoad = new SqlDataAdapter(sqlCommand, sqlConnection);
            DataTable dataTableLoad = new DataTable();

            dataAdapterLoad.Fill(dataTableLoad);

            dataGridViewInterface.DataSource = dataTableLoad;
            dataGridViewInterface.Columns[0].Visible = false;
            dataGridViewInterface.Columns[1].Visible = false;
            sqlConnection.Close();
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            Add interfaceAddWindow = new Add();

            interfaceAddWindow.TopMost = true;
            interfaceAddWindow.ShowDialog();
            LoadData();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            int rows = dataGridViewInterface.CurrentRow.Index;
            int valueRows = Convert.ToInt32(dataGridViewInterface[0, rows].Value);

            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
            SqlCommand command = new SqlCommand("DellInterface", sqlConnection);

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

        private void ButtonChangeClick(object sender, EventArgs e)
        {
            int rows = dataGridViewInterface.CurrentRow.Index;

            Update interfaceUpdateWindow = new Update(dataGridViewInterface[2, rows].Value.ToString(),
                                                                      Convert.ToInt32(dataGridViewInterface[0, rows].Value));

            interfaceUpdateWindow.TopMost = true;
            interfaceUpdateWindow.ShowDialog();
            LoadData();
        }
    }
}
