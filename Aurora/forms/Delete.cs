using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ServerSetUp;

namespace Aurora
{

    public partial class Delete : Form
    {
        SQLConfig SQL = new SQLConfig();
        SqlDataReader sqlDataReader;
        SqlCommand getDataFromTable;

        int iRecordsID = 0;
        bool flag = true;

        public Delete()
        {
            InitializeComponent();
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            SQL.ApplyConfig();
            if (SQL.ServerExistConnection)
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

                        Main form = new Main();
                        form.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }
    }
}
