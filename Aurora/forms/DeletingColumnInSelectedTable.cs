namespace Aurora
{ 
    using System;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class DeletingColumnInSelectedTable : Form
    {
        string sColumnName;

        public DeletingColumnInSelectedTable()
        {
            InitializeComponent();
            label1.Text = Class.TableName;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            WorkingWithTheSelectedTable form = new WorkingWithTheSelectedTable();
            form.Show();
            this.Hide();
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                sColumnName = textBox.Text;
                Class.DataBaseConnection.Open();
                SqlCommand deletingComand = new SqlCommand($"ALTER TABLE {Class.TableName} DROP COLUMN {sColumnName};", Class.DataBaseConnection);

                SqlDataReader sqlReader = deletingComand.ExecuteReader();

                Main form = new Main();
                form.Show();
                this.Hide();

                Class.DataBaseConnection.Close();
            }
        }
    }
}
