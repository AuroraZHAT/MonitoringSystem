namespace MonitoringSystem.Forms.Map
{
    public partial class Main : Form
    {
        private readonly ZoomablePictureBox zoomablePictureBox;

        public Main()
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
            Image? image = GetImageFromFile();
            if (image != null)
            {
                zoomablePictureBox.LoadImage(image);
            }
        }

        private static Image? GetImageFromFile()
        {
            using var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
                RestoreDirectory = true
            };

            return (openFileDialog.ShowDialog() == DialogResult.OK)
                    ? Image.FromFile(openFileDialog.FileName)
                    : null;
        }
    }
}
