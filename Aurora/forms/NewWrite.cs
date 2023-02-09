namespace Aurora
{
    using System;
    using Microsoft.Data.SqlClient;
    using System.Windows.Forms;
    using AuroraGit.ServerSetUp;
    using ServerSetUp;

    public partial class NewWrite : Form
    {
        SQLConfig SQL = new SQLConfig();
        string getDataFromDB;
        SqlCommand sqlCommand;
        SqlDataReader readDataBase;

        public NewWrite()
        {
            InitializeComponent();
            m_ComboBoxItem();
        }
        private void m_ComboBoxItem()
        {
            SQL.ApplyConfig();
            if (SQL.ServerExistConnection)
            {
                SqlConnection dataBaseConnection = new SqlConnection(SQL.DatabaseConnectionString);
                dataBaseConnection.Open();
                m_SetDefualtItemComboBox();
                getDataFromDB = "SELECT * FROM ObjectsType";

                m_ReadDataBase(getDataFromDB, dataBaseConnection);
                while (readDataBase.Read())
                {
                    comboBoxObjectType.Items.Add(readDataBase[1].ToString());
                }
                readDataBase.Close();

                getDataFromDB = "SELECT * FROM OS";

                m_ReadDataBase(getDataFromDB, dataBaseConnection);
                while (readDataBase.Read())
                {
                    comboBoxOS.Items.Add(readDataBase[1].ToString());
                }
                readDataBase.Close();

                getDataFromDB = "SELECT * FROM Interfaces";

                m_ReadDataBase(getDataFromDB, dataBaseConnection);
                while (readDataBase.Read())
                {
                    comboBoxInterface.Items.Add(readDataBase[1].ToString());
                }
                readDataBase.Close();

                getDataFromDB = "SELECT * FROM LocationMap";

                m_ReadDataBase(getDataFromDB, dataBaseConnection);
                while (readDataBase.Read())
                {
                    comboBoxLocationMap.Items.Add(readDataBase[1].ToString());
                }
                readDataBase.Close();
                dataBaseConnection.Close();
            }
        }

        private bool m_IsEachFilled()
        {
            return textBoxName.TextLength > 0 &&
                   textBoxResponsible.TextLength > 0 &&
                   textBoxInstalled.TextLength > 0 &&
                   comboBoxObjectType.Text.Length > 0 &&
                   comboBoxOS.Text.Length > 0 &&
                   comboBoxInterface.Text.Length > 0 &&
                   comboBoxLocationMap.Text.Length > 0 &&
                   comboBoxObjectType.SelectedIndex != 0 &&
                   comboBoxOS.SelectedIndex != 0 &&
                   comboBoxLocationMap.SelectedIndex != 0 &&
                   comboBoxInterface.SelectedIndex != 0;
        }

        private void m_InsertData(string objectName, string responsible, string installedBy,
                             int type, int OS, int connectionInterface, int location)
        {
            SqlConnection dataBaseConnection = new SqlConnection(SQL.DatabaseConnectionString);
            dataBaseConnection.Open();
            string sendDataToDataBase =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id], [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id], [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{objectName}', {type}, {OS}, {location}, NULL, NULL, {connectionInterface}, NULL, '{responsible}', '{installedBy}')";

            SqlCommand sqlCommand = new SqlCommand(sendDataToDataBase, dataBaseConnection);

            sqlCommand.Parameters.AddWithValue("ObjectName", objectName);
            sqlCommand.Parameters.AddWithValue("Responsible", responsible);
            sqlCommand.Parameters.AddWithValue("InstalledBy", installedBy);
            sqlCommand.Parameters.AddWithValue("ObjectType_id", type);
            sqlCommand.Parameters.AddWithValue("OS_id", OS);
            sqlCommand.Parameters.AddWithValue("Interfaces_id", connectionInterface);
            sqlCommand.Parameters.AddWithValue("LocationMap_id", location);

            sqlCommand.ExecuteNonQuery().ToString();

            MessageBox.Show("Добавлено!");
            dataBaseConnection.Close();
        }

        private void m_Clear()
        {
            textBoxName.Clear();
            comboBoxObjectType.Items.Clear();
            comboBoxOS.Items.Clear();
            comboBoxLocationMap.Items.Clear();
            comboBoxInterface.Items.Clear();
            textBoxResponsible.Clear();
            textBoxInstalled.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (m_IsEachFilled())
            {
                try
                {
                    m_InsertData(textBoxName.Text,
                               textBoxResponsible.Text,
                               textBoxInstalled.Text,
                               comboBoxObjectType.SelectedIndex,
                               comboBoxOS.SelectedIndex,
                               comboBoxInterface.SelectedIndex,
                               comboBoxLocationMap.SelectedIndex);
                }
                catch
                {
                    MessageBox.Show("Ошибка! Введите корректные данные!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            m_Clear();
            this.Hide();
        }

        private void m_ReadDataBase(string getDataFromDB, SqlConnection dataBaseConnection)
        {
            sqlCommand = new SqlCommand(getDataFromDB, dataBaseConnection);
            readDataBase = sqlCommand.ExecuteReader();
        }

        private void m_SetDefualtItemComboBox()
        {
            comboBoxObjectType.Items.Add("Не выбрано");
            comboBoxObjectType.SelectedIndex = 0;
            comboBoxOS.Items.Add("Не выбрано");
            comboBoxOS.SelectedIndex = 0;
            comboBoxInterface.Items.Add("Не выбрано");
            comboBoxInterface.SelectedIndex = 0;
            comboBoxLocationMap.Items.Add("Не выбрано");
            comboBoxLocationMap.SelectedIndex = 0;
        }
    }
}
