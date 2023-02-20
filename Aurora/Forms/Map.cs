using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Application = System.Windows.Forms.Application;
using Button = System.Windows.Forms.Button;

namespace Aurora.Forms
{
    public partial class Map : Form
    {
        private SQLVariables _SQLVariables = new SQLVariables();
        private SQLConfig _SQLConfig = new SQLConfig();
        public Map()
        {
            InitializeComponent();
            if (!_SQLVariables.Connected())
            {
                DialogResult mb;
                mb = MessageBox.Show("SQL сервер не доступен. \n\r Открыть настройки?", "Не доступен SQL сервер", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (mb == DialogResult.Yes)
                {

                }
                if (mb == DialogResult.No)
                {

                }
            }
            //FillMenuObjects();
            //Режим измененния размера в PictureBox = StretchImage
            string FileWay = @"C:\Users\salta\Downloads\PlanОfis_2.png";
            //pictureBox1.Image = Bitmap.FromFile(FileWay);
            Bitmap n = new Bitmap(FileWay);
            pictureBox1.UpdateImage(n);
            //pictureBox1.MouseWheel += PictudreBox_MouseWheel;
           // panel1.MouseWheel += Panel1_MouseWheel;
            


        }

       

        string FileWay = @"C:\Users\salta\Downloads\more_zdaniia_siluety_740030_1920x1080.jpg";

        int Xclick, Yclick;
        private void FillMenuObjects()
        {
            //объектыToolStripMenuItem
            _SQLConfig.ApplyConfig();
            string sqlConnection = _SQLConfig.DatabaseConnectionString;
            string ReadObjectsType = "SELECT * FROM ObjectsType";

            SqlCommand sqlCommand = new SqlCommand(ReadObjectsType, _SQLVariables.Connection);
            _SQLVariables.Connection.Open();
            SqlDataReader readObjType = sqlCommand.ExecuteReader();
            if (readObjType.HasRows)
            {
                while (readObjType.Read())
                {
                    объектыToolStripMenuItem.DropDownItems.Add(readObjType.GetString(0));
                    
                }
            }
            _SQLVariables.Connection.Close();
            
        }

        private void добавитьТипОбъектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
               Xclick = this.clickPosition.X = e.X;
               Yclick = this.clickPosition.Y = e.Y;
               // MessageBox.Show(e.X + "\n\r" + e.Y);
            }
            
        }

     


        private void buttonZoomPlus_Click(object sender, EventArgs e)
        {
           // pictureBox1.Height += Convert.ToInt32(scaleFactor / constant);
           // pictureBox1.Width += scaleFactor;
        }

        private void buttonZoomMinus_Click(object sender, EventArgs e)
        {
            PictureControl nn = new PictureControl();
            nn.DecreaseZoom();
            Bitmap n = new Bitmap(FileWay);
            nn.UpdateImage(n);
            // pictureBox1.Height -= Convert.ToInt32(scaleFactor / constant);
            // pictureBox1.Width -= scaleFactor;
        }





        int i = 2;



        private void компьютерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Xclick+ "\n\r" + Yclick);

            // Bitmap bit = new Bitmap(@"C:\Users\salta\Downloads\c23facf99daaddc169351f80a4f3a416.jpg");
           // PictureControl _osName = new PictureControl();
       //     Button _osName = new Button();
            Label nn = new Label();
            nn.Location = new Point(Xclick-30, Yclick-7);
            nn.AutoSize = true;
            nn.Name = "pictureBox" + i.ToString();
            nn.Text = "Компьютер";
            nn.TabIndex = i;
            nn.BackColor = Color.DarkOrange;
            //  _osName.Click += new EventHandler(nn_Click);
           // _osName.MouseDown += new MouseEventHandler(nn_MouseDown); 
            nn.TabStop = false;
            //_osName.Image = bit; 
            //Controls.Add(_osName);
            i++;
            this.Controls.Add(panel1);
            panel1.Controls.Add(nn);
        }

        // private void nn_MouseDown(object sender, MouseEventArgs e)
        //  {
        //  if()
        // {

        // }
        //   }

        ///  private void nn_Click(object sender, EventArgs e)
        //  {
        //        throw new NotImplementedException();
        //   }


        protected Point clickPosition;
        protected Point scrollPosition;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scrollPosition.X = scrollPosition.X + clickPosition.X - e.X;
                scrollPosition.Y = scrollPosition.Y + clickPosition.Y - e.Y;
                this.panel1.AutoScrollPosition = scrollPosition;
            }
        }

        private void измениеИнтерфейсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfaceMain interfaceMainWindow = new InterfaceMain();
            if (Application.OpenForms.OfType<InterfaceMain>().Count() > 0)
            {

            }
            else
            {
                interfaceMainWindow.TopMost = true;
                interfaceMainWindow.Show();
            }
        }

        private void добвитьНовыйОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NewWriteAdd newWrite = new NewWriteAdd();
            //if (Application.OpenForms.OfType<NewWriteAdd>().Count() > 0)
            //{

            //}
            //else
            //{
            //    newWrite.TopMost = true;
            //    newWrite.Show();
            //}  
        }

        private void добавитьНовуюСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OsMain osMainWindow = new OsMain();
            if (Application.OpenForms.OfType<OsMain>().Count() > 0)
            {

            }
            else
            {
                osMainWindow.TopMost = true;
                osMainWindow.Show();
            }
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
                Xclick = this.clickPosition.X = e.X;
                Yclick = this.clickPosition.Y = e.Y;
        }
    }
}
