using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open .bmp file";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFile.FileName);
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
