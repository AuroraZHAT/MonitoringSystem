using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.Interface
{
    public partial class Update : Form
    {
        private string _interfaceName;
        private int _interfaceId;
        public Update(string interfaceName, int interfaceId)
        {
            InitializeComponent();
            _interfaceName = interfaceName;
            _interfaceId = interfaceId;
            interfaceNameTextBox.Text = _interfaceName.Replace(" ", "");
        }


        private void UpdateButtonClick(object sender, EventArgs e)
        {
            int idDelete = _interfaceId;


            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
            SqlCommand command = new SqlCommand("UpdInterface", sqlConnection);

            sqlConnection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", interfaceNameTextBox.Text));
            command.Parameters.Add(new SqlParameter("@idD", idDelete));
            command.ExecuteNonQuery();
            sqlConnection.Close();

            this.Close();

        }

        private void interfaceNameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateButton.PerformClick();
            }
        
        }
    }
}
