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

namespace GUI
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
    }
}
