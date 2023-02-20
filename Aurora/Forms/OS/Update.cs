using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Aurora.Forms.OS
{
    public partial class Update : Form
    {
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
            int idDelete = _osId;

            SqlConnection sqlConnection = new SqlConnection(Config.Database.ConnectionString);
            SqlCommand command = new SqlCommand("UpdOS", sqlConnection);

            sqlConnection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", UpdateOsTextBox.Text));
            command.Parameters.Add(new SqlParameter("@idD", idDelete));
            command.ExecuteNonQuery();
            sqlConnection.Close();

            this.Close();

        }
    }
}
