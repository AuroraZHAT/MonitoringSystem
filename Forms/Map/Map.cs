using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class Map : Form
    {
        private ZoomablePictureBox zoomablePictureBox;

        public Map()
        {
            InitializeComponent();

            zoomablePictureBox = new ZoomablePictureBox(pictureBoxPanel)
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = pictureBoxPanel.Size
            };

            pictureBoxPanel.Controls.Add(zoomablePictureBox);
        }

        private void OnLoadImageButtonClick(object sender, EventArgs e)
        {
            Image image = GetImageFromFile();
            if (image != null)
            {
                zoomablePictureBox.LoadImage(image);
            }
        }

        private Image GetImageFromFile()
        {
            using (var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
                RestoreDirectory = true
            })
            {
                return (openFileDialog.ShowDialog() == DialogResult.OK)
                    ? Image.FromFile(openFileDialog.FileName)
                    : null;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Map());
        }

    }
}
