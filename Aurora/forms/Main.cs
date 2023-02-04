namespace Aurora
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using Microsoft.Data.SqlClient;

    public partial class Main : Form
    {
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
            getDataFromDB = $"select * from AvroraView where concat (id, ObjectName, ObjectType, OS_Name, " +
                                   $"Location_Map, Last_IP, HVID, Interface, MAC_Address, Responsible, Installed) " +
                                   $"like '%" + textBoxSearch.Text + "%'";

            Class.DataBaseConnection.Open();

            sendCommandToSQL = new SqlCommand("SELECT * FROM objectView", Class.DataBaseConnection);

            readDataBase = new SqlDataAdapter(sendCommandToSQL);

            readDataBase.Fill(dataTable);
            
            Class.DataBaseConnection.Close();
            
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
             dataTable.Clear();

             if (textBoxSearch.Text.Length == 0)
             {
                 m_LoadData();
             }
             else
             {
                 Class.DataBaseConnection.Open();
                 bool flag = false;

                 string sSearch = textBoxSearch.Text;
                 flag = false;

                 if (!flag)
                 {
                    getDataFromDB = $"select * from ObjectView where concat (id, ObjectName, TypeName, " +
                                           $"OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, " +
                                           $"Responsible, Installed) like '%" + textBoxSearch.Text + "%'";

                    sendCommandToSQL = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

                    //Считываем таблицу
                    readDataBase = new SqlDataAdapter(sendCommandToSQL);

                    readDataBase.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    Class.DataBaseConnection.Close();
                }
             }
             Class.DataBaseConnection.Close();
        }
    }
}
