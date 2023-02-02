namespace Aurora
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class SelectingTable : Form
    {
        public SelectingTable()
        {
            InitializeComponent();
            ComboItem();
        }

        private void ComboItem()
        {
            Class.DataBaseConnection.Open();

            SqlCommand command = new SqlCommand("SELECT name FROM sys.objects WHERE type in (N'U')", Class.DataBaseConnection);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                comboBoxTables.Items.Add(sqlDataReader[0].ToString());
            }
        }

        private void buttonChoising_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.Text.Length > 0)
            {
                Class.TableName = comboBoxTables.Text;

                WorkingWithTheSelectedTable form = new WorkingWithTheSelectedTable();
                form.Show();
                this.Hide();
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
