using System;
using System.Data;
using System.Windows.Forms;
using ServerSetUp;
using Microsoft.Data.SqlClient;

namespace Aurora
{
    public partial class Main : Form
    {
        string getDataFromDB;

        SQLConfig SQL = new SQLConfig();
        DataTable dataTable = new DataTable();
        SqlCommand sendCommandToSQL;
        SqlDataAdapter readDataBase;

        public Main()
        {
            InitializeComponent();
            LoadData();
        }
        
        private void LoadData()
        {
            SQL.ApplyConfig();
            if (SQL.ServerExistConnection)
            {
                dataTable.Clear();
                SqlConnection dataBaseConnection = new SqlConnection(SQL.DatabaseConnectionString);
                getDataFromDB = $"SELECT * FROM objectView";
                try
                {
                    dataBaseConnection.Open();
                }
                catch
                {
                    ServerSetUpConf formSetUp = new ServerSetUpConf();
                    formSetUp.ShowDialog();
                    Main formMain = new Main();
                    formMain.Show();
                    dataTable.Clear();
                    LoadData();
                }
                sendCommandToSQL = new SqlCommand("SELECT * FROM objectView", dataBaseConnection);
                readDataBase = new SqlDataAdapter(sendCommandToSQL);
                readDataBase.Fill(dataTable);
                dataBaseConnection.Close();

                dataGridView1.DataSource = dataTable;
            }
        }

        #region Кнопки
        private void m_buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void m_buttonNewWrite_Click(object sender, EventArgs e)
        {
            NewWrite form = new NewWrite();
            form.ShowDialog();
            LoadData();
        }

        private void m_buttonDelete_Click(object sender, EventArgs e)
        {
            Delete form = new Delete();
            form.Show();
            this.Hide();
            LoadData();
        }
        #endregion

        private void m_textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dataBaseConnection = new SqlConnection(SQL.DatabaseConnectionString);

            if (textBoxSearch.Text.Length == 0)
            {
                LoadData();
            }
            else
            {
                dataBaseConnection.Open();
                bool flag = false;

                string sSearch = textBoxSearch.Text;
                flag = false;

                if (!flag)
                {
                    getDataFromDB = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                                    $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                                    $"Responsible, Installed) like '%" + textBoxSearch.Text + "%'";

                    sendCommandToSQL = new SqlCommand(getDataFromDB, dataBaseConnection);
                    readDataBase = new SqlDataAdapter(sendCommandToSQL);

                    readDataBase.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    dataBaseConnection.Close();
                }
            }
            dataBaseConnection.Close();
        }

        private void конфигураторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerSetUpConf form = new ServerSetUpConf();
            form.ShowDialog();
            LoadData();
        }
    }
}
