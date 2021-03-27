using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp
{
    public partial class ResultPicture : Form
    {
        int prevHeight;
        int prevWidth;
        private Bitmap _previewBitmap;
        public ResultPicture(Bitmap bitmap)
        {
            InitializeComponent();
            _previewBitmap = bitmap;
            pictureBox1.Image = _previewBitmap;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "| *.bmp | PNG files | *.png | JPEG files | *.jpg | GIF files | *.gif | TIFF files | *.tif | Image files | *.bmp; *.jpg; *.gif; *.png; *.tif | All files | *.*";
            if (f.ShowDialog() == DialogResult.OK)
            {
                _previewBitmap.Save(f.FileName);
            }
        }

        private void zoomINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevHeight = _previewBitmap.Height;
            prevWidth = _previewBitmap.Width;
            int zoom = 10;
            if (zoom < 20)
            {
                this.pictureBox1.Width += (int)(prevWidth * 0.1);
                this.pictureBox1.Height += (int)(prevHeight * 0.1);
                zoom++;
                this.AutoSize = true;
            }
        }

        private void zoomOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int zoom = 10;
            if (zoom > 0)
            {
                this.pictureBox1.Width -= (int)(this.pictureBox1.Width * 0.1);
                this.pictureBox1.Height -= (int)(this.pictureBox1.Height * 0.1);
                zoom--;
                this.Size = new Size(pictureBox1.Width, pictureBox1.Height);
            }
        }
    }
}
