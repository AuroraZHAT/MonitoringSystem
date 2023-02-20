using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.OS
{
    public partial class OsAdd : Form
    {
        public OsAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int textboxTextLenght = UpdateNameTextBox.Text.Length;
            if (textboxTextLenght > 0)
            {
                SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
                SqlCommand command = new SqlCommand("AddOS", sqlConnection);

                sqlConnection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@os", UpdateNameTextBox.Text);

                SqlDataReader exsistElement = command.ExecuteReader();
                if (!exsistElement.Read())
                {
                    sqlConnection.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой элемент уже существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
