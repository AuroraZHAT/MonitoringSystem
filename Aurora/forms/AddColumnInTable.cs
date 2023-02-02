namespace Aurora
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class AddColumnInTable : Form
    {
        string sColumnName;

        public AddColumnInTable()
        {
            InitializeComponent();
            labelTableName.Text = Class.TableName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameColumn.Text.Length > 0)
            {
                sColumnName = textBoxNameColumn.Text;

                Class.DataBaseConnection.Open();

                SqlCommand comandAdding = new SqlCommand($"ALTER TABLE {Class.TableName} ADD {sColumnName} NVARCHAR(50) NULL", Class.DataBaseConnection);

                SqlDataReader sqlDataReader = comandAdding.ExecuteReader();

                Main form = new Main();
                form.Show();
                this.Hide();

                Class.DataBaseConnection.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            WorkingWithTheSelectedTable form = new WorkingWithTheSelectedTable();
            form.Show();
            this.Hide();
        }
    }
}
