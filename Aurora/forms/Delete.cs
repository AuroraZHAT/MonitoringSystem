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

namespace Avrora
{
    public partial class Delete : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);

        public Delete()
        {
            InitializeComponent();
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            int iRecordsID = 0;
            bool flag = true;
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
                    DataBaseConnection.Open();

                    SqlCommand getDataFromTable = new SqlCommand($"DELETE FROM Object WHERE ID = {iRecordsID}", DataBaseConnection);

                    SqlDataReader sqlDataReader = getDataFromTable.ExecuteReader();

                    DataBaseConnection.Close();

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
