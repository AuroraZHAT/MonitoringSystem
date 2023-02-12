using System;
using System.Windows.Forms;
using Aurora.Config;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms
{
    public partial class Deletion : Form
    {
        Server _server = new Server();
        SqlDataReader sqlDataReader;
        SqlCommand getDataFromTable;

        int iRecordsID = 0;
        bool flag = true;

        public Deletion()
        {
            InitializeComponent();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            
            if (_server.ConnectionExist)
            {
                SqlConnection dataBaseConnection = new SqlConnection(_server._Database.ConnectionString);
                if (textBoxID.Text.Length > 0)
                {
                    try
                    {
                        iRecordsID = Convert.ToInt32(textBoxID.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите ID записи которую вы хотите удалить!");
                        flag = false;
                    }

                    if (flag)
                    {
                        dataBaseConnection.Open();

                        getDataFromTable = new SqlCommand($"DELETE FROM Object WHERE ID = {iRecordsID}", dataBaseConnection);

                        sqlDataReader = getDataFromTable.ExecuteReader();

                        dataBaseConnection.Close();

                        Database form = new Database();
                        form.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            Database form = new Database();
            form.Show();
            this.Hide();
        }
    }
}
