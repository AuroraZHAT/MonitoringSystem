namespace Aurora
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class Delete : Form
    {
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
                    Class.DataBaseConnection.Open();

                    getDataFromTable = new SqlCommand($"DELETE FROM Object WHERE ID = {iRecordsID}", Class.DataBaseConnection);

                    sqlDataReader = getDataFromTable.ExecuteReader();

                    Class.DataBaseConnection.Close();

                    Main form = new Main();
                    form.Show();
                    this.Hide();   
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
