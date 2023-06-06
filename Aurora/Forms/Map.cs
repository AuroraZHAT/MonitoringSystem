using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class Map : Form
    {
        private enum Zoom
        {
            Normal = 1,
            Zoomed
        }

        private Zoom _zoomRatio = Zoom.Normal;

        private PointF _mousePressedLeftLocation;
        private Point _mousePressedRightLocation;
        private Size _pictureSize;

        private bool _isDragging = false;

        public Map()
        {
            InitializeComponent();

            _pictureBox.MouseWheel += OnPictureBoxMouseWheel;

            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Image = Properties.Resources._buildingPlan;  
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && _zoomRatio != Zoom.Zoomed)
            {
                _zoomRatio = Zoom.Zoomed;
                _pictureBox.Top = (int)(e.Y - (int)_zoomRatio * (e.Y - _pictureBox.Top));
                _pictureBox.Left = (int)(e.X - (int)_zoomRatio * (e.X - _pictureBox.Left));
            }
            else if (e.Delta < 0)
            {
                _zoomRatio = Zoom.Normal;
                _pictureBox.Location = new Point(0, 0);
            }

            _pictureBox.Height = _pictureSize.Height * (int)_zoomRatio;
            _pictureBox.Width = _pictureSize.Width * (int)_zoomRatio;
        }

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _isDragging = true;
                    _mousePressedLeftLocation = e.Location;
                    break;

                case MouseButtons.Right:
                    _mousePressedRightLocation = e.Location;
                    break;
            }
        }

        private void OnPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                _isDragging = false;
            }  
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || _zoomRatio == Zoom.Normal) return;

            PointF mouseDelta = new PointF
            {
                X = e.X - _mousePressedLeftLocation.X,
                Y = e.Y - _mousePressedLeftLocation.Y
            };

            PointF mouseRatio = GetMouseRatio(mouseDelta);

            _pictureBox.Left += (int)(mouseDelta.X * mouseRatio.X);
            _pictureBox.Top += (int)(mouseDelta.Y * mouseRatio.Y);
        }

        /// <summary>
        /// Высчитывает коэффициент замедления движения после достижения установленных границ
        /// </summary>
        /// <param name="mouseDelta"></param>
        /// <returns></returns>
        private PointF GetMouseRatio(PointF mouseDelta)
        {
            Border border = new Border
            {
                Left = _pictureBoxPanel.Left - _pictureBox.Width / 2,
                Right = _pictureBoxPanel.Width + _pictureBox.Width / 2,
                Top = _pictureBoxPanel.Top - _pictureBox.Height / 2,
                Bottom = _pictureBoxPanel.Height - _buttonPanel.Height + _pictureBox.Height / 2
            };

            PointF mouseRatio = new PointF(1.0f, 1.0f);

            if (_pictureBox.Left < border.Left && mouseDelta.X < 0)
                mouseRatio.X = border.Left / (_pictureBox.Left * 100);
            else if (_pictureBox.Right > border.Right && mouseDelta.X > 0)
                mouseRatio.X = border.Right / (_pictureBox.Right * 100);

            if (_pictureBox.Top < border.Top && mouseDelta.Y < 0)
                mouseRatio.Y = border.Top / (_pictureBox.Top * 100);
            else if (_pictureBox.Bottom > border.Bottom && mouseDelta.Y > 0)
                mouseRatio.Y = border.Bottom / (_pictureBox.Bottom * 100);

            return mouseRatio;
        }

        private void ComputerToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Button button = new Button();
            button.AutoSize = true;
            button.Name = "Comp";
            button.TabIndex = 10;
            button.Text = "Test";
            button.Location = new Point(_mousePressedRightLocation.X, _mousePressedRightLocation.Y);
            _pictureBox.Controls.Add(button);
        }

        private void _pictureBoxPanel_Resize(object sender, EventArgs e)
        {
            _pictureBox.Location = new Point(0, 0);
            _pictureBox.Size = _pictureBoxPanel.Size;
            _pictureSize = _pictureBox.Size;
        }
    }
}
