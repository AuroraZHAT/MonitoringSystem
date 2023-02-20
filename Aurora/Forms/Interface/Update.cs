using System;
using System.Data;
using System.Windows.Forms;

namespace Aurora.Forms.Interface
{
    public partial class Update : Form
    {
        private SQLConfig _SQLConfig = new SQLConfig();
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
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;
            int idDelete = _interfaceId;
            

            SqlConnection connection = new SqlConnection(sqlConnection);
            SqlCommand command = new SqlCommand("UpdInterface", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", interfaceNameTextBox.Text));
            command.Parameters.Add(new SqlParameter("@idD", idDelete));
            command.ExecuteNonQuery();
            connection.Close();

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
