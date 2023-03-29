using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private Point _click;
        private Point _middling = new Point(-30, -7);
        private Point _scrollPosition;
        private int _counter = 2;

        private void PanelMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _click = new Point(e.X, e.Y);
            }
        }

        private void ComputerToolStripMenuItemClick(object sender, EventArgs e)
        {
            Label nn = new Label();
            nn.Location = new Point(_click.X + _middling.X, _click.Y + _middling.Y);
            nn.AutoSize = true;
            nn.Name = "pictureBox" + _counter.ToString();
            nn.Text = "Компьютер";
            nn.TabIndex = _counter;
            nn.BackColor = Color.DarkOrange;
            nn.TabStop = false;
            Controls.Add(panel);
            panel.Controls.Add(nn);
            _counter++;
        }

        private void PanelMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _scrollPosition.X = _scrollPosition.X - e.X;
                _scrollPosition.Y = _scrollPosition.Y - e.Y;
                panel.AutoScrollPosition = _scrollPosition;
            }
        }
    }
}
