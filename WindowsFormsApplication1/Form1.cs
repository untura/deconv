using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageArray;
using Convolution;
using Fourier;
using System.IO;

namespace GUI
{
    public partial class BaseForm : Form
    {
        ImageYUV im;
        
        public BaseForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            im = new ImageYUV(bm);

            for (int i = 0; i < im.Height; i++)
                for (int j = 0; j < im.Width; j++)
                {
                    im.U[i, j] = 0;
                    im.V[i, j] = 0;
                }

            pictureBox2.Image = im.ToBitmap();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Filter fil = new Filter(comboBox1.Text);
            fil.Apply(im.Y);
            
            pictureBox3.Image = im.ToBitmap();
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] select = {"Gauss", "Sharpen", "Emboss"};
            comboBox1.Items.AddRange(select);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open .bmp file";

            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Bitmap bmp = new Bitmap(openFile.FileName);
            im = new ImageYUV(bmp);

            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox2.Image = bmp;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".bmp";
            saveFile.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream save_str = saveFile.OpenFile();
                pictureBox2.Image.Save(save_str, System.Drawing.Imaging.ImageFormat.Bmp);
                save_str.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double[,] fil = new double[im.Y.GetLength(0), im.Y.GetLength(1)];
           
            for (int i = im.Y.GetLength(0) / 2 - 1; i < im.Y.GetLength(0) / 2 + 1; i++)
                for (int j = im.Y.GetLength(0) / 2 - 1; j < im.Y.GetLength(0) / 2 + 1; j++)
                    fil[i, j] = 0.7;

            double[,] res = FFT.Convolute(im.Y, fil);

            for (int i = 0; i < im.Y.GetLength(0); i++)
                for (int j = 0; j < im.Y.GetLength(1); j++)
                    im.Y[i, j] = res[i, j];

            pictureBox3.Image = im.ToBitmap();
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
