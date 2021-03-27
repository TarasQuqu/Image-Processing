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
    public partial class PC1 : Form
    {
        int prevHeight;
        int prevWidth;
        private Bitmap _previewBitmap;
        public PC1(Bitmap bitmap)
        {
            if (bitmap == null) {return;}
            InitializeComponent();
            _previewBitmap = bitmap;
            pictureBox1.Image = _previewBitmap;
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
