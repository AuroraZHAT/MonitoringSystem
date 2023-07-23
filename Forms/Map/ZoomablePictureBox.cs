using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonitoringSystem.Forms
{
    public class ZoomablePictureBox : PictureBox
    {
        private Image OriginalImage { get; set; }
        private bool IsZoomed { get; set; }
        private bool IsDragging { get; set; }
        private Point StartDragPoint { get; set; }

        private readonly int ZoomFactor = 2;

        public ZoomablePictureBox(Control parent)
        {
            Parent = parent;

            MouseWheel += OnMouseWheel;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            Parent.Resize += OnParentResize;
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (OriginalImage == null) return;

            ZoomImage(e);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            IsDragging = true;
            StartDragPoint = new Point(e.X, e.Y);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            IsDragging = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging && IsZoomed)
            {
                AdjustImagePosition(e);
            }
        }

        private void OnParentResize(object sender, EventArgs e)
        {
            Size = Parent.Size;
            Top = Parent.Top;
            Left = Parent.Left;
            IsZoomed = false;
        }

        public void LoadImage(Image image)
        {
            OriginalImage = image ?? throw new ArgumentNullException(nameof(image));
            Image = OriginalImage;
            IsZoomed = false;
        }

        private void ZoomImage(MouseEventArgs e)
        {
            int width = Size.Width;
            int height = Size.Height;

            if (!IsZoomed && e.Delta > 0)
            {
                width *= ZoomFactor;
                height *= ZoomFactor;

                IsZoomed = true;
            }
            else if (IsZoomed && e.Delta < 0)
            {
                width /= ZoomFactor;
                height /= ZoomFactor;

                Top = Parent.Top;
                Left = Parent.Left;

                IsZoomed = false;
            }

            Size = new Size(width, height);
        }

        private void AdjustImagePosition(MouseEventArgs e)
        {
            PointF mouseDelta = new PointF
            {
                X = e.X - StartDragPoint.X,
                Y = e.Y - StartDragPoint.Y
            };

            PointF mouseRatio = GetMouseRatio(mouseDelta);

            Left += (int)(mouseDelta.X * mouseRatio.X);
            Top += (int)(mouseDelta.Y * mouseRatio.Y);
        }

        private PointF GetMouseRatio(PointF mouseDelta)
        {
            Border border = new Border
            {
                Left = Parent.Left - Width / 2,
                Right = Parent.Width + Width / 2,
                Top = Parent.Top - Height / 2,
                Bottom = Parent.Height + Height / 2
            };

            PointF mouseRatio = new PointF(1.0f, 1.0f);

            if (Left < border.Left && mouseDelta.X < 0)
                mouseRatio.X = border.Left / (Left * 100);
            else if (Right > border.Right && mouseDelta.X > 0)
                mouseRatio.X = border.Right / (Right * 100);

            if (Top < border.Top && mouseDelta.Y < 0)
                mouseRatio.Y = border.Top / (Top * 100);
            else if (Bottom > border.Bottom && mouseDelta.Y > 0)
                mouseRatio.Y = border.Bottom / (Bottom * 100);

            return mouseRatio;
        }
    }
}
