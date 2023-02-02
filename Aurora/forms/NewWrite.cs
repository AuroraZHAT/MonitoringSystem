namespace Aurora
{
    using System;
    using Microsoft.Data.SqlClient;
    using System.Windows.Forms;

    public partial class NewWrite : Form
    {
        public NewWrite()
        {
            InitializeComponent();
            ComboBoxItem();
        }
        private void ComboBoxItem()
        {
            string getDataFromDB;
            SqlCommand sqlCommand;
            SqlDataReader readDataBase;

            Class.DataBaseConnection.Open();
            #region ObjectTypeComboBox
            getDataFromDB = "SELECT * FROM ObjectType";

            //Создание экземпляра для получение таблицы
            sqlCommand = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

            readDataBase = sqlCommand.ExecuteReader();

            comboBoxObjectType.Items.Add("Не выбрано");
            comboBoxObjectType.SelectedIndex= 0;

            //Читаем данные из всех столбцов
            while (readDataBase.Read())
            {
                comboBoxObjectType.Items.Add(readDataBase[1].ToString());
            }
            readDataBase.Close();
            #endregion

            #region osComboBox
            getDataFromDB = "SELECT * FROM OS";

            //Создание экземпляра для получение таблицы
            sqlCommand = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

            readDataBase = sqlCommand.ExecuteReader();

            comboBoxOS.Items.Add("Не выбрано");
            comboBoxOS.SelectedIndex = 0;

            //Читаем данные из всех столбцов
            while (readDataBase.Read())
            {
                comboBoxOS.Items.Add(readDataBase[1].ToString());
            }
            readDataBase.Close();
            #endregion

            #region InterfaceComboBox
            getDataFromDB = "SELECT * FROM Interfaces";

            //Создание экземпляра для получение таблицы
            sqlCommand = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

            readDataBase = sqlCommand.ExecuteReader();

            comboBoxInterface.Items.Add("Не выбрано");
            comboBoxInterface.SelectedIndex = 0;

            //Читаем данные из всех столбцов
            while (readDataBase.Read())
            {
                comboBoxInterface.Items.Add(readDataBase[1].ToString());
            }
            readDataBase.Close();
            #endregion

            #region LocationMap
            getDataFromDB = "SELECT * FROM LocationMap";

            //Создание экземпляра для получение таблицы
            sqlCommand = new SqlCommand(getDataFromDB, Class.DataBaseConnection);

            readDataBase = sqlCommand.ExecuteReader();

            comboBoxLocationMap.Items.Add("Не выбрано");
            comboBoxLocationMap.SelectedIndex = 0;

            //Читаем данные из всех столбцов
            while (readDataBase.Read())
            {
                comboBoxLocationMap.Items.Add(readDataBase[1].ToString());
            }
            readDataBase.Close();
            #endregion
            Class.DataBaseConnection.Close();
        }

        private bool IsEachFilled()
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

        private void InsertData(string objectName, string responsible, string installedBy,
                             int type, int OS, int connectionInterface, int location)
        {
            Class.DataBaseConnection.Open();
            string sendDataToDataBase =
            $"INSERT INTO [Object] ([ObjectName], [ObjectType_id], [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id], [Last_Date_ON], [Responsible], [Installed])" +
            $" VALUES ('{objectName}', {type}, {OS}, {location}, NULL, NULL, {connectionInterface}, NULL, '{responsible}', '{installedBy}')";

            SqlCommand sqlCommand = new SqlCommand(sendDataToDataBase, Class.DataBaseConnection);

            sqlCommand.Parameters.AddWithValue("ObjectName", objectName);
            sqlCommand.Parameters.AddWithValue("Responsible", responsible);
            sqlCommand.Parameters.AddWithValue("InstalledBy", installedBy);
            sqlCommand.Parameters.AddWithValue("ObjectType_id", type);
            sqlCommand.Parameters.AddWithValue("OS_id", OS);
            sqlCommand.Parameters.AddWithValue("Interfaces_id", connectionInterface);
            sqlCommand.Parameters.AddWithValue("LocationMap_id", location);

            sqlCommand.ExecuteNonQuery().ToString();

            MessageBox.Show("Добавлено!");
            Class.DataBaseConnection.Close();
        }

        private void Clear()
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
            if (IsEachFilled())
            {
                try
                {
                    InsertData(textBoxName.Text,
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
                Clear();
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
