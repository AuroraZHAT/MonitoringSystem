namespace Aurora
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class WorkingWithTheSelectedTable : Form
    {
        public WorkingWithTheSelectedTable()
        {
            InitializeComponent();
            LoadDataFromTable();
        }

        private void WorkingWithTheSelectedTable_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadDataFromTable()
        {
            labelName.Text = Class.TableName;

            Class.DataBaseConnection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM {labelName.Text}", Class.DataBaseConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            Class.DataBaseConnection.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddColumnInTable form = new AddColumnInTable();
            form.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeletingColumnInSelectedTable form = new DeletingColumnInSelectedTable();
            form.Show();
            this.Hide();
        }
    }
}
