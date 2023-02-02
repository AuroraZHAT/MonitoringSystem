using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Avrora.forms;

namespace Avrora
{
    public partial class WorkingWithTheSelectedTable : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);

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
            labelName.Text = Data.TableName;

            DataBaseConnection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM {labelName.Text}", DataBaseConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            DataBaseConnection.Close();
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
