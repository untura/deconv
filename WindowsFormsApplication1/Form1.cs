using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageArray;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ImageYUV im;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open .bmp file";

            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Bitmap bmp = new Bitmap(openFile.FileName);
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
            var arr = new double[,]{
                                {1, 2, 1},
                                {2, 4, 2},
                                {1, 2, 1}
                                };
            double div = 0;
            foreach (var item in arr)
                div += item;

            ImageYUV im_sm = im;

            for (int i = 1; i < im.Height - 1; i++)
                for (int j = 1; j < im.Width - 1; j++)
                {
                    im_sm.Y[i, j] = (im.Y[i - 1, j - 1] * arr[0, 0] + im.Y[i - 1, j] * arr[0, 1] + im.Y[i - 1, j + 1] * arr[0, 2] +
                                     im.Y[i,     j - 1] * arr[1, 0] + im.Y[i,     j] * arr[1, 1] + im.Y[i,     j + 1] * arr[1, 2] +
                                     im.Y[i + 1, j - 1] * arr[2, 0] + im.Y[i + 1, j] * arr[2, 1] + im.Y[i + 1, j + 1] * arr[2, 2])
                                    / div;
                }

            pictureBox3.Image = im_sm.ToBitmap();
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
