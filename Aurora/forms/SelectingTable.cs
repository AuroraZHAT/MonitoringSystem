namespace Aurora
{
    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;

    public partial class SelectingTable : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);

        public SelectingTable()
        {
            InitializeComponent();
            ComboItem();
        }

        private void ComboItem()
        {
            DataBaseConnection.Open();

            SqlCommand command = new SqlCommand("SELECT name FROM sys.objects WHERE type in (N'U')", DataBaseConnection);

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
                Data.TableName = comboBoxTables.Text;

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
