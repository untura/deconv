namespace GUI
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.Inverse_filter = new System.Windows.Forms.Button();
            this.Wiener_filter = new System.Windows.Forms.Button();
            this.Const_value = new System.Windows.Forms.TextBox();
            this.mu_in = new System.Windows.Forms.TextBox();
            this.sigma_in = new System.Windows.Forms.TextBox();
            this.Blur_value = new System.Windows.Forms.TextBox();
            this.PSNR_static = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PSNR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Blur_value_1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 307);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(370, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(268, 307);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Channel Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(132, 115);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(720, 176);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(268, 307);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Blur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inverse_filter
            // 
            this.Inverse_filter.Location = new System.Drawing.Point(473, 57);
            this.Inverse_filter.Name = "Inverse_filter";
            this.Inverse_filter.Size = new System.Drawing.Size(75, 23);
            this.Inverse_filter.TabIndex = 11;
            this.Inverse_filter.Text = "Inverse";
            this.Inverse_filter.UseVisualStyleBackColor = true;
            this.Inverse_filter.Click += new System.EventHandler(this.Inverse_filter_Click);
            // 
            // Wiener_filter
            // 
            this.Wiener_filter.Location = new System.Drawing.Point(473, 115);
            this.Wiener_filter.Name = "Wiener_filter";
            this.Wiener_filter.Size = new System.Drawing.Size(75, 23);
            this.Wiener_filter.TabIndex = 12;
            this.Wiener_filter.Text = "Wiener";
            this.Wiener_filter.UseVisualStyleBackColor = true;
            this.Wiener_filter.Click += new System.EventHandler(this.Wiener_filter_Click);
            // 
            // Const_value
            // 
            this.Const_value.Location = new System.Drawing.Point(554, 117);
            this.Const_value.Name = "Const_value";
            this.Const_value.Size = new System.Drawing.Size(52, 20);
            this.Const_value.TabIndex = 13;
            // 
            // mu_in
            // 
            this.mu_in.Location = new System.Drawing.Point(213, 77);
            this.mu_in.Name = "mu_in";
            this.mu_in.Size = new System.Drawing.Size(52, 20);
            this.mu_in.TabIndex = 14;
            // 
            // sigma_in
            // 
            this.sigma_in.Location = new System.Drawing.Point(271, 77);
            this.sigma_in.Name = "sigma_in";
            this.sigma_in.Size = new System.Drawing.Size(52, 20);
            this.sigma_in.TabIndex = 15;
            // 
            // Blur_value
            // 
            this.Blur_value.Location = new System.Drawing.Point(213, 40);
            this.Blur_value.Name = "Blur_value";
            this.Blur_value.Size = new System.Drawing.Size(52, 20);
            this.Blur_value.TabIndex = 16;
            // 
            // PSNR_static
            // 
            this.PSNR_static.AutoSize = true;
            this.PSNR_static.Location = new System.Drawing.Point(768, 125);
            this.PSNR_static.Name = "PSNR_static";
            this.PSNR_static.Size = new System.Drawing.Size(37, 13);
            this.PSNR_static.TabIndex = 17;
            this.PSNR_static.Text = "PSNR";
            this.PSNR_static.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(811, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 18;
            // 
            // PSNR
            // 
            this.PSNR.AutoSize = true;
            this.PSNR.Location = new System.Drawing.Point(817, 125);
            this.PSNR.Name = "PSNR";
            this.PSNR.Size = new System.Drawing.Size(13, 13);
            this.PSNR.TabIndex = 19;
            this.PSNR.Text = "0";
            this.PSNR.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "blur kernel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "noise parameters";
            // 
            // Blur_value_1
            // 
            this.Blur_value_1.Location = new System.Drawing.Point(319, 40);
            this.Blur_value_1.Name = "Blur_value_1";
            this.Blur_value_1.Size = new System.Drawing.Size(52, 20);
            this.Blur_value_1.TabIndex = 22;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 532);
            this.Controls.Add(this.Blur_value_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PSNR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PSNR_static);
            this.Controls.Add(this.Blur_value);
            this.Controls.Add(this.sigma_in);
            this.Controls.Add(this.mu_in);
            this.Controls.Add(this.Const_value);
            this.Controls.Add(this.Wiener_filter);
            this.Controls.Add(this.Inverse_filter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Inverse_filter;
        private System.Windows.Forms.Button Wiener_filter;
        private System.Windows.Forms.TextBox Const_value;
        private System.Windows.Forms.TextBox mu_in;
        private System.Windows.Forms.TextBox sigma_in;
        private System.Windows.Forms.TextBox Blur_value;
        private System.Windows.Forms.Label PSNR_static;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PSNR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Blur_value_1;
    }
}

