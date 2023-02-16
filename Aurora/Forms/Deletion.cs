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
            if (!int.TryParse(textBoxID.Text, out _ID))
            {
                MessageBox.Show("Введены неверные данные!");
                return;
            }

            Hide();
            textBoxID.Clear();
        }

    }
}
