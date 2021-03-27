using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.Filters;
using AForge.Imaging.ColorReduction;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Csharp
{
    public partial class Form1 : Form
    {
        int userPixel = 0;
        ImageManipulation imageClass;
        public Form1()
        {
            InitializeComponent();
            histogramToolStripMenuItem.Enabled = false;
            grayscalePicture2ToolStripMenuItem.Enabled = false;
            grayScaleToolStripMenuItem2.Enabled = false;
            masksToolStripMenuItem.Enabled = false;
            secondToolStripMenuItem.Enabled = false;
            processingToolStripMenuItem.Enabled = false;
            grayScaleToolStripMenuItem2.Enabled = false;
            grayscalePicture2ToolStripMenuItem.Enabled = false;
            operationsWithTwoPicturesToolStripMenuItem1.Visible = false;
            operationsWithTwoPicturesToolStripMenuItem.Visible = false;
        }
        private string OpenImage()
        {
            openFileDialog1.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }
            openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, sep, "All Files", "*.*");
            openFileDialog1.DefaultExt = ".png";

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return "fail";
        }
        private void firstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = OpenImage();
                if (fileName == "fail")
                    return;
                Bitmap image1 = new Bitmap(fileName, true);
                imageClass = new ImageManipulation(image1);
                new System.Threading.Thread(PictireForm1).Start();
                secondToolStripMenuItem.Enabled = true;
                grayScaleToolStripMenuItem1.Enabled = false;
                masksToolStripMenuItem.Enabled = false;
                histogramToolStripMenuItem.Enabled = false;
                processingToolStripMenuItem.Enabled = true;
                grayScaleToolStripMenuItem1.Enabled = false;
                grayScaleToolStripMenuItem2.Enabled = true;
                histogramToolStripMenuItem.Enabled = true;
                rGBToolStripMenuItem.Enabled = true;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Exception");
            }
        }
        private void secondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = OpenImage();
                if (fileName == "fail")
                    return;
                imageClass.imgBitmap2 = new Bitmap(fileName);
                new System.Threading.Thread(PictireForm2).Start();
                grayscalePicture2ToolStripMenuItem.Enabled = true;
                masksToolStripMenuItem.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception");
            }
        }
        void ResultPicture()
        {
            ResultPicture RP = new ResultPicture(imageClass.imgBitMap);
            RP.ShowDialog();
        }
        void PictireForm1()
        {
            PC1 pc1 = new PC1(imageClass.imgBitMap);
            pc1.ShowDialog();
        }
        void PictireForm2()
        {
            PC2 pc2 = new PC2(imageClass.imgBitmap2);
            pc2.ShowDialog();
        }
        void MasksForm()
        {
            Operations masks = new Operations(ref imageClass);
            masks.mask_imageClass = imageClass;
            masks.ShowDialog();
        }
        void GrayscaleHistogram()
        {
            GrayscaleHistogram grayscaleHistogram = new GrayscaleHistogram(ref imageClass);
            grayscaleHistogram.GrayscaleHistogram_imageClass = imageClass;
            grayscaleHistogram.ShowDialog();
        }
        private void grayScaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(GrayscaleHistogram).Start();
        }
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void grayScaleToolStripMenuItem2_Click(object sender, EventArgs e)
        { 
            imageClass.imgBitMap = imageClass.ConvertToGrayScale(imageClass.imgBitMap);
            imageClass.imgBitmapCOPY = imageClass.ConvertToGrayScale(imageClass.imgBitmapCOPY);
            rGBToolStripMenuItem.Enabled = false;
            grayScaleToolStripMenuItem1.Enabled = true;
            masksToolStripMenuItem.Enabled = true;
            new System.Threading.Thread(PictireForm1).Start();
        }
        private void grayscalePicture2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageClass.imgBitmap2 = imageClass.ConvertToGrayScale(imageClass.imgBitmap2);
            operationsWithTwoPicturesToolStripMenuItem.Enabled = true;
            new System.Threading.Thread(PictireForm2).Start();
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Autor: Taras Kuts");
        }
            void rgbhistogram()
        {
            RGBhistogram rgbhistogram = new RGBhistogram(ref imageClass);
            rgbhistogram.RGBhistogram_imageClass = imageClass;
            rgbhistogram.ShowDialog();
        }
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(rgbhistogram).Start();

        }
        private void masksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasksForm();
        }
        private void sUBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Subtract filtersub = new Subtract(imageClass.imgBitMap);
            imageClass.imgBitmapCOPY = filtersub.Apply(imageClass.imgBitmap2);
            ResultPicture result = new ResultPicture(imageClass.imgBitmapCOPY);
            result.ShowDialog();
        }

        private void xORToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageClass.OperationArythmeticandLogic(ArithmeticOperations.XOR);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }

        private void aNDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           imageClass.OperationArythmeticandLogic(ArithmeticOperations.AND);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }

        private void oRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             imageClass.OperationArythmeticandLogic(ArithmeticOperations.OR);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }

        private void aDDanotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
             imageClass.OperationArythmeticandLogic(ArithmeticOperations.ADD);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }

        private void sUBanotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageClass.OperationArythmeticandLogic(ArithmeticOperations.SUB);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }

        private void dIFFERENCEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            imageClass.OperationArythmeticandLogic(ArithmeticOperations.DIFF);
            ResultPicture resultP = new ResultPicture(imageClass.imgBitmapCOPY);
            resultP.ShowDialog();
        }
    }
}

       
