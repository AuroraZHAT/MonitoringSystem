﻿using System.Drawing;
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

        private PointF _mousePressedLocation;
        private Size _pictureSize;

        private bool _isDragging = false;

        public Map()
        {
            InitializeComponent();

            _pictureBox.MouseWheel += OnPictureBoxMouseWheel;

            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Image = Properties.Resources._buildingPlan;

            _pictureSize = _pictureBox.Size;
        }


        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 )
                _zoomRatio = Zoom.Zoomed;
            else if (e.Delta < 0)
                _zoomRatio = Zoom.Normal;

            _pictureBox.Height = _pictureSize.Height * (int)_zoomRatio;
            _pictureBox.Width = _pictureSize.Width * (int)_zoomRatio;

            if (_zoomRatio == Zoom.Zoomed)
                return;

            _pictureBox.Top = (int)(e.Y - (int)_zoomRatio * (e.Y - _pictureBox.Top));
            _pictureBox.Left = (int)(e.X - (int)_zoomRatio * (e.X - _pictureBox.Left));
        }

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _mousePressedLocation = e.Location;
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
            if (!_isDragging) return;

            PointF mouseDelta = new PointF
            {
                X = e.X - _mousePressedLocation.X,
                Y = e.Y - _mousePressedLocation.Y
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
                Left = -_pictureBoxPanel.Width / 2,
                Right = _pictureBoxPanel.Width * 1.5f,
                Top = -_pictureBoxPanel.Height / 2,
                Bottom = _pictureBoxPanel.Height// * 1.5f
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
    }
}
