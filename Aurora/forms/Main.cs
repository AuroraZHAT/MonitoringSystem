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

        public Main()
        {
            InitializeComponent();
            LoadData();
        }
        
        private void LoadData()
        {
            Class.DataBaseConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM AvroraView", Class.DataBaseConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            Class.DataBaseConnection.Close();
            
        }

        #region Кнопки
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            LoadData();
        }

        private void buttonNewWrite_Click(object sender, EventArgs e)
        {
            NewWrite form = new NewWrite();
            form.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete form = new Delete();
            form.Show();
            this.Hide();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            SelectingTable form = new SelectingTable();
            form.Show();
            this.Hide();
        }
        #endregion

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
             //Здесь будем сохранять все данные в лист data и позже его выводить
             List<string[]> listDataFromTable = new List<string[]>();

             //Очищаем таблицу
             dataTable.Clear();

             if (textBoxSearch.Text.Length == 0)
             {
                 LoadData();
             }
             else
             {
                 Class.DataBaseConnection.Open();
                 bool flag = false;

                 string sSearch = textBoxSearch.Text;
                 flag = false;

                 if (!flag)
                 {
                    //Запрос на получение данных из базы данных
                    string getDataFromDB = $"select * from AvroraView where concat (id, ObjectName, ObjectType, OS_Name, Location_Map, Last_IP, HVID, Interface, MAC_Address, Responsible, Installed) like '%" + textBoxSearch.Text + "%'";

                    //Создание экземпляра для получение таблицы
                    SqlCommand sqlCommand = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

                    //Считываем таблицу
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    Class.DataBaseConnection.Close();
                }
             }
             foreach (string[] s in listDataFromTable)
             {
                 dataGridView1.Rows.Add(s);
             }
             Class.DataBaseConnection.Close();
        }
    }
}
