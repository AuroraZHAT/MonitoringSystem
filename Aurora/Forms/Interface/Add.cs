using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ServerSetUp;

namespace Aurora.Forms.Interface
{
    public partial class InterfaceAdd : Form
    {
        private SQLConfig _SQLConfig = new SQLConfig();

        public InterfaceAdd()
        {
            InitializeComponent();
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;

            int textboxTextLenght = NewNameTextbox.Text.Length;
            if (textboxTextLenght != 0)
            {
                SqlConnection connection = new SqlConnection(sqlConnection);
                SqlCommand command = new SqlCommand("AddInterface", connection);

                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Интерфейс", NewNameTextbox.Text);

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


        private void NewNameTextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd.PerformClick();
            }
        }
    }
}
