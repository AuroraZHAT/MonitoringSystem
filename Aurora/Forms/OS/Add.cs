using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ServerSetUp;

namespace Aurora.Forms.OS
{
    public partial class OsAdd : Form
    {
        private SQLConfig _SQLConfig = new SQLConfig();
        public OsAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;

            int textboxTextLenght = UpdateNameTextBox.Text.Length;
            if (textboxTextLenght > 0)
            {
                SqlConnection connection = new SqlConnection(sqlConnection);
                SqlCommand command = new SqlCommand("AddOS", connection);

                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@os", UpdateNameTextBox.Text);

                SqlDataReader exsistElement = command.ExecuteReader();
                if (!exsistElement.Read())
                {
                    connection.Close();
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
