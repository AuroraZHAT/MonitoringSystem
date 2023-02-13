using System;
using System.Data;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class Deletion : Form
    {
        public Deletion()
        {
            InitializeComponent();
        }

        private int _ID;

        public int ID => _ID;

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (textBoxID.Text.Length > 0)
            {
                try
                {
                    _ID = Convert.ToInt32(textBoxID.Text);
                    Hide();
                    textBoxID.Clear();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введены неверные данные!");
                }
            }
        }

    }
}
