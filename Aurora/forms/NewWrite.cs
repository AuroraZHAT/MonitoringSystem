using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Aurora
{
    public partial class NewWriteForm : Form
    {
        private string _objectName;
        private string _responsible;
        private string _installedBy;
        private int _type;
        private int _OS;
        private int _connectionInterface;
        private int _location;

        public NewWriteForm()
        {
            InitializeComponent();
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

        private void SetDefualtItemComboBox()
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

        private void OnButtonAddClick(object sender, EventArgs e)
        {
            if (IsEachFilled())
            {
                _objectName = textBoxName.Text;
                _responsible = textBoxResponsible.Text;
                _installedBy = textBoxInstalled.Text;
                _type = comboBoxObjectType.SelectedIndex;
                _OS = comboBoxOS.SelectedIndex;
                _connectionInterface = comboBoxInterface.SelectedIndex;
                _location = comboBoxLocationMap.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }
            Clear();
            Hide();
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            Clear();
            Hide();
        }
        
        public void GetData(List<string> ObjectTypes, List<string> OperatingSystems,
                            List<string> Interfaces, List<string> LocationMaps)
        {
            Clear();
            SetDefualtItemComboBox();

            ObjectTypes.ForEach(obj => { comboBoxObjectType.Items.Add(obj); });
            OperatingSystems.ForEach(obj => { comboBoxOS.Items.Add(obj); });
            Interfaces.ForEach(obj => { comboBoxInterface.Items.Add(obj); });
            LocationMaps.ForEach(obj => { comboBoxLocationMap.Items.Add(obj); });
        }

        public void SetData(out string objectName, out string responsible, out string installedBy,
                             out int type, out int OS, out int connectionInterface, out int location)
        {
            objectName = _objectName;
            responsible = _responsible;
            installedBy = _installedBy;
            type = _type;
            OS = _OS;
            connectionInterface = _connectionInterface;
            location = _location;
        }
    }
}
