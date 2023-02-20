using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Aurora.Forms
{
    public partial class Addition : Form
    {
        private string _objectName;
        private string _responsible;
        private string _installedBy;
        private int _type;
        private int _OS;
        private int _connectionInterface;
        private int _location;

        public Addition()
        {
            InitializeComponent();
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

                Hide();
            }
            else
            {
                MessageBox.Show("Введите все данные!");
            }

        }

        public bool IsEachFilled()
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

            _objectName = null;
            _responsible = null;
            _installedBy = null;
            _type = 0;
            _OS = 0;
            _connectionInterface = 0;
            _location = 0;
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

        public void SetComboBoxData(List<string> ObjectTypes, List<string> OperatingSystems,
                            List<string> Interfaces, List<string> LocationMaps)
        {
            Clear();
            SetDefualtItemComboBox();

            ObjectTypes.ForEach(obj => { comboBoxObjectType.Items.Add(obj); });
            OperatingSystems.ForEach(obj => { comboBoxOS.Items.Add(obj); });
            Interfaces.ForEach(obj => { comboBoxInterface.Items.Add(obj); });
            LocationMaps.ForEach(obj => { comboBoxLocationMap.Items.Add(obj); });
        }

        public SQLObject GetInput()
        {
            SQLObject sqlObject;

            sqlObject.Name = _objectName;
            sqlObject.Responsible = _responsible;
            sqlObject.InstalledBy = _installedBy;
            sqlObject.Type = _type;
            sqlObject.OS = _OS;
            sqlObject.ConnectionInterface = _connectionInterface;
            sqlObject.Location = _location;

            return sqlObject;
        }
    }
}
