using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms
{
    public partial class Deletion : Form
    {
        SQL SQL = new SQL();
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
            SQL.ApplyConfig();
            if (SQL.ServerConnectionExist)
            {
                SqlConnection dataBaseConnection = new SqlConnection(SQL.DatabaseConnectionString);
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
