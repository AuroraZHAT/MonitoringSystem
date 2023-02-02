namespace Aurora
{
    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;

    public partial class AddColumnInTable : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);
        string sColumnName;

        public AddColumnInTable()
        {
            InitializeComponent();
            labelTableName.Text = Data.TableName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNameColumn.Text.Length > 0)
            {
                sColumnName = textBoxNameColumn.Text;

                DataBaseConnection.Open();

                SqlCommand comandAdding = new SqlCommand($"ALTER TABLE {Data.TableName} ADD {sColumnName} NVARCHAR(50) NULL", DataBaseConnection);

                SqlDataReader sqlDataReader = comandAdding.ExecuteReader();

                Main form = new Main();
                form.Show();
                this.Hide();

                DataBaseConnection.Close();
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
