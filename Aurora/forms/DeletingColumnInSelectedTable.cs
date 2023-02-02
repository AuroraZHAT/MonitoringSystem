namespace Aurora
{
    using System.Data.SqlClient;
    using System;
    using System.Windows.Forms;

    public partial class DeletingColumnInSelectedTable : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);
        string sColumnName;

        public DeletingColumnInSelectedTable()
        {
            InitializeComponent();
            label1.Text = Data.TableName;
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
                DataBaseConnection.Open();
                SqlCommand deletingComand = new SqlCommand($"ALTER TABLE {Data.TableName} DROP COLUMN {sColumnName};", DataBaseConnection);

                SqlDataReader sqlReader = deletingComand.ExecuteReader();

                Main form = new Main();
                form.Show();
                this.Hide();

                DataBaseConnection.Close();
            }
        }
    }
}
