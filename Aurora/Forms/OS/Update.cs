using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.OS
{
    public partial class Update : Form
    {
        private SQLConfig _SQLConfig = new SQLConfig();
        private string _osName;
        private int _osId;
        public Update(string osName, int osId)
        {
            InitializeComponent();
            _osName = osName;
            _osId = osId;
            UpdateOsTextBox.Text = _osName.Replace(" ", "");
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;
            int idDelete = _osId;


            SqlConnection connection = new SqlConnection(sqlConnection);
            SqlCommand command = new SqlCommand("UpdOS", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", UpdateOsTextBox.Text));
            command.Parameters.Add(new SqlParameter("@idD", idDelete));
            command.ExecuteNonQuery();
            connection.Close();

            this.Close();

        }
    }
}
