using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avrora
{
    public partial class NewWrite : Form
    {
        const string DataBasePath = "Data Source=DESKTOP-VMLJJ4E\\SQLEXPRESS;Initial Catalog=avrora;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);

        public NewWrite()
        {
            InitializeComponent();
            ComboBoxItem();
        }

        #region ComboBoxObjectTypeItem
        private void ComboBoxItem()
        {
            string getDataFromDB;
            SqlCommand sqlCommand;
            SqlDataReader readDataBase;

            DataBaseConnection.Open();

            #region ObjectTypeComboBox
            getDataFromDB = "SELECT * FROM ObjectType";

            //Создание экземпляра для получение таблицы
            sqlCommand = new SqlCommand(getDataFromDB, DataBaseConnection);

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
            sqlCommand = new SqlCommand(getDataFromDB, DataBaseConnection);

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
            sqlCommand = new SqlCommand(getDataFromDB, DataBaseConnection);

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
            sqlCommand = new SqlCommand(getDataFromDB, DataBaseConnection);

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
            DataBaseConnection.Close();
        }
        #endregion

        #region Button
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxObjectType.SelectedIndex != 0 &&
                comboBoxOS.SelectedIndex != 0 &&
                comboBoxLocationMap.SelectedIndex != 0 &&
                comboBoxInterface.SelectedIndex != 0)
            {
                string sObjectName = "", sResponsible = "", sInstalled = "";
                int sComboType = 0, sComboOS = 0, sComboInterface = 0, sComboLocation = 0;
                if ((textBoxName.Text.Length > 0) &&
                   (textBoxResponsible.Text.Length > 0) &&
                   (textBoxInstalled.Text.Length > 0) &&
                   (comboBoxObjectType.Text.Length > 0) &&
                   (comboBoxOS.Text.Length > 0) &&
                   (comboBoxInterface.Text.Length > 0) &&
                   (comboBoxLocationMap.Text.Length > 0))
                {

                    bool fExamination = false;
                    try
                    {
                        //Присваеваем все данные по переменным для удобства их использования
                        sObjectName = textBoxName.Text;
                        sComboType = Convert.ToInt32(comboBoxObjectType.SelectedIndex);
                        sComboOS = Convert.ToInt32(comboBoxOS.SelectedIndex);
                        sComboInterface = Convert.ToInt32(comboBoxInterface.SelectedIndex);
                        sResponsible = textBoxResponsible.Text;
                        sInstalled = textBoxInstalled.Text;
                        sComboLocation = Convert.ToInt32(comboBoxLocationMap.SelectedIndex);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Введите корректные данные!");
                        fExamination = true;
                    }

                    if (!fExamination)
                    {
                        DataBaseConnection.Open();

                        //Запрос на ввод данных в базу данных
                        string sendDataToDataBase = $"INSERT INTO [Object] ([ObjectName], [ObjectType_id], [OS_id], [LocationMap_id], [Last_ip], [HVID], [Interfaces_id], [Last_Date_ON], [Responsible], [Installed]) VALUES ('{sObjectName}', {sComboType}, {sComboOS}, {sComboLocation}, NULL, NULL, {sComboInterface}, NULL, '{sResponsible}', '{sInstalled}')";
                        //Создание экземпляра для получение таблицы
                        SqlCommand sqlCommand = new SqlCommand(sendDataToDataBase, DataBaseConnection);

                        //Добавляем в каждую ячейку данные
                        sqlCommand.Parameters.AddWithValue("ObjectName", sObjectName);
                        sqlCommand.Parameters.AddWithValue("ObjectType_id", sComboType);
                        sqlCommand.Parameters.AddWithValue("OS_id", sComboOS);
                        sqlCommand.Parameters.AddWithValue("LocationMap_id", sComboLocation);
                        sqlCommand.Parameters.AddWithValue("Interfaces_id", sComboInterface);
                        sqlCommand.Parameters.AddWithValue("Responsible", sResponsible);
                        sqlCommand.Parameters.AddWithValue("Installed", sInstalled);

                        sqlCommand.ExecuteNonQuery().ToString();

                        MessageBox.Show("Добавлено!");

                        textBoxName.Clear();
                        comboBoxObjectType.Items.Clear();
                        comboBoxOS.Items.Clear();
                        comboBoxLocationMap.Items.Clear();
                        comboBoxInterface.Items.Clear();
                        textBoxResponsible.Clear();
                        textBoxInstalled.Clear();

                        DataBaseConnection.Close();

                        Main form = new Main();
                        form.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Введите все данные!");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }
        #endregion
    }
}
