using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.Interface
{
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {

            int textboxTextLenght = NewNameTextbox.Text.Length;
            if (textboxTextLenght != 0)
            {
                SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
                SqlCommand command = new SqlCommand("AddInterface", sqlConnection);

                sqlConnection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Интерфейс", NewNameTextbox.Text);

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


        private void NewNameTextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd.PerformClick();
            }
        }
    }
}
