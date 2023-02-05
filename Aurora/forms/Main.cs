namespace Aurora
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using AuroraGit.ServerSetUp;
    using Microsoft.Data.SqlClient;

    public partial class Main : Form
    {
        SQLConfig sql = new SQLConfig();
        DataTable dataTable = new DataTable();
        string getDataFromDB;
        SqlCommand sendCommandToSQL;
        SqlDataAdapter readDataBase;

        public Main()
        {
            InitializeComponent();
            m_LoadData();
        }
        
        private void m_LoadData()
        {
            SqlConnection dataBaseConnection = new SqlConnection(sql.DatabaseConnectionString);
            getDataFromDB = $"SELECT * FROM objectView";

            dataBaseConnection.Open();
            sendCommandToSQL = new SqlCommand("SELECT * FROM objectView", dataBaseConnection);
            while (true)
            {
                readDataBase = new SqlDataAdapter(sendCommandToSQL);
                try
                {
                    readDataBase.Fill(dataTable);
                    break;
                }
                catch
                {
                    CreateTableAndView();
                }
            }
            dataBaseConnection.Close();
            
            dataGridView1.DataSource = dataTable;
        }

        #region Кнопки
        private void m_buttonRefresh_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            m_LoadData();
        }

        private void m_buttonNewWrite_Click(object sender, EventArgs e)
        {
            NewWrite form = new NewWrite();
            form.ShowDialog();
        }

        private void m_buttonDelete_Click(object sender, EventArgs e)
        {
            Delete form = new Delete();
            form.Show();
            this.Hide();
        }
        #endregion

        private void m_textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dataBaseConnection = new SqlConnection(sql.DatabaseConnectionString);
            dataTable.Clear();

             if (textBoxSearch.Text.Length == 0)
             {
                 m_LoadData();
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

                    //Считываем таблицу
                    readDataBase = new SqlDataAdapter(sendCommandToSQL);

                    readDataBase.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    dataBaseConnection.Close();
                }
             }
             dataBaseConnection.Close();
        }

        private void CreateTableAndView()
        {
            sql.CreateTableInaterfaces();
            sql.CreateTableLocationMap();
            sql.CreateTableObject();
            sql.CreateTableObjectType();
            sql.CreateTableOS();
            sql.CreateObjectView();
        }

        private void конфигураторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerSetUpConf form = new ServerSetUpConf();
            form.Show();
            this.Close();
        }
    }
}
