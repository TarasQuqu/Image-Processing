namespace Csharp
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscalePicture2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsWithTwoPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xORToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDanotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sUBanotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIFFERENCEToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsWithTwoPicturesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.masksToolStripMenuItem,
            this.operationsWithTwoPicturesToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.operationsWithTwoPicturesToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(758, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstToolStripMenuItem,
            this.secondToolStripMenuItem});
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.openFileToolStripMenuItem.Text = "OpenFile";
            // 
            // firstToolStripMenuItem
            // 
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            this.firstToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.firstToolStripMenuItem.Text = "First";
            this.firstToolStripMenuItem.Click += new System.EventHandler(this.firstToolStripMenuItem_Click);
            // 
            // secondToolStripMenuItem
            // 
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.secondToolStripMenuItem.Text = "Second";
            this.secondToolStripMenuItem.Click += new System.EventHandler(this.secondToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem1,
            this.rGBToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // grayScaleToolStripMenuItem1
            // 
            this.grayScaleToolStripMenuItem1.Name = "grayScaleToolStripMenuItem1";
            this.grayScaleToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.grayScaleToolStripMenuItem1.Text = "Grayscale";
            this.grayScaleToolStripMenuItem1.Click += new System.EventHandler(this.grayScaleToolStripMenuItem1_Click);
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem2,
            this.grayscalePicture2ToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.processingToolStripMenuItem.Text = "RGBtoGrayscale";
            // 
            // grayScaleToolStripMenuItem2
            // 
            this.grayScaleToolStripMenuItem2.Name = "grayScaleToolStripMenuItem2";
            this.grayScaleToolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
            this.grayScaleToolStripMenuItem2.Text = "First Picture";
            this.grayScaleToolStripMenuItem2.Click += new System.EventHandler(this.grayScaleToolStripMenuItem2_Click);
            // 
            // grayscalePicture2ToolStripMenuItem
            // 
            this.grayscalePicture2ToolStripMenuItem.Name = "grayscalePicture2ToolStripMenuItem";
            this.grayscalePicture2ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.grayscalePicture2ToolStripMenuItem.Text = "Second Picture";
            this.grayscalePicture2ToolStripMenuItem.Click += new System.EventHandler(this.grayscalePicture2ToolStripMenuItem_Click);
            // 
            // masksToolStripMenuItem
            // 
            this.masksToolStripMenuItem.Name = "masksToolStripMenuItem";
            this.masksToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.masksToolStripMenuItem.Text = "Operations with one  picture";
            this.masksToolStripMenuItem.Click += new System.EventHandler(this.masksToolStripMenuItem_Click);
            // 
            // operationsWithTwoPicturesToolStripMenuItem
            // 
            this.operationsWithTwoPicturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xORToolStripMenuItem1,
            this.aNDToolStripMenuItem1,
            this.oRToolStripMenuItem1,
            this.aDDanotherToolStripMenuItem,
            this.sUBanotherToolStripMenuItem,
            this.dIFFERENCEToolStripMenuItem2});
            this.operationsWithTwoPicturesToolStripMenuItem.Name = "operationsWithTwoPicturesToolStripMenuItem";
            this.operationsWithTwoPicturesToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.operationsWithTwoPicturesToolStripMenuItem.Text = "Operations with two pictures";
            // 
            // xORToolStripMenuItem1
            // 
            this.xORToolStripMenuItem1.Name = "xORToolStripMenuItem1";
            this.xORToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.xORToolStripMenuItem1.Text = "XOR";
            this.xORToolStripMenuItem1.Click += new System.EventHandler(this.xORToolStripMenuItem1_Click);
            // 
            // aNDToolStripMenuItem1
            // 
            this.aNDToolStripMenuItem1.Name = "aNDToolStripMenuItem1";
            this.aNDToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.aNDToolStripMenuItem1.Text = "AND";
            this.aNDToolStripMenuItem1.Click += new System.EventHandler(this.aNDToolStripMenuItem1_Click);
            // 
            // oRToolStripMenuItem1
            // 
            this.oRToolStripMenuItem1.Name = "oRToolStripMenuItem1";
            this.oRToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.oRToolStripMenuItem1.Text = "OR";
            this.oRToolStripMenuItem1.Click += new System.EventHandler(this.oRToolStripMenuItem1_Click);
            // 
            // aDDanotherToolStripMenuItem
            // 
            this.aDDanotherToolStripMenuItem.Name = "aDDanotherToolStripMenuItem";
            this.aDDanotherToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aDDanotherToolStripMenuItem.Text = "ADD";
            this.aDDanotherToolStripMenuItem.Click += new System.EventHandler(this.aDDanotherToolStripMenuItem_Click);
            // 
            // sUBanotherToolStripMenuItem
            // 
            this.sUBanotherToolStripMenuItem.Name = "sUBanotherToolStripMenuItem";
            this.sUBanotherToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sUBanotherToolStripMenuItem.Text = "SUB";
            this.sUBanotherToolStripMenuItem.Click += new System.EventHandler(this.sUBanotherToolStripMenuItem_Click);
            // 
            // dIFFERENCEToolStripMenuItem2
            // 
            this.dIFFERENCEToolStripMenuItem2.Name = "dIFFERENCEToolStripMenuItem2";
            this.dIFFERENCEToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.dIFFERENCEToolStripMenuItem2.Text = "DIFFERENCE";
            this.dIFFERENCEToolStripMenuItem2.Click += new System.EventHandler(this.dIFFERENCEToolStripMenuItem2_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // operationsWithTwoPicturesToolStripMenuItem1
            // 
            this.operationsWithTwoPicturesToolStripMenuItem1.Name = "operationsWithTwoPicturesToolStripMenuItem1";
            this.operationsWithTwoPicturesToolStripMenuItem1.Size = new System.Drawing.Size(171, 20);
            this.operationsWithTwoPicturesToolStripMenuItem1.Text = "Operations with two pictures";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 384);
            this.Controls.Add(this.menuStrip2);
            this.MinimumSize = new System.Drawing.Size(627, 422);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem grayscalePicture2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsWithTwoPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsWithTwoPicturesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xORToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aNDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oRToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aDDanotherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sUBanotherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dIFFERENCEToolStripMenuItem2;
    }
}

