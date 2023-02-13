using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms
{
    public partial class Deletion : Form
    {
        int iRecordsID = 0;
        bool flag = true;

        public Deletion()
        {
            InitializeComponent();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
                if (textBoxID.Text.Length > 0)
                {
                    try
                    {
                        iRecordsID = Convert.ToInt32(textBoxID.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введены неверные данные!");
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
    }
}
