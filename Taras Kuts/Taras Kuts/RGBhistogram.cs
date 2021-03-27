using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Csharp
{
        partial class RGBhistogram : Form
        {
        public ImageManipulation RGBhistogram_imageClass { get; set; }
        MinMaxAveragePixel MinMaxAveragePixel = new MinMaxAveragePixel();
        public RGBhistogram(ref ImageManipulation ImageClass)
        {
            RGBhistogram_imageClass = ImageClass;
            InitializeComponent();
            
            ShowRGBHistogram();
        }
        public void ShowRGBHistogram()
        {
            RGBhistogram_imageClass.GetHistogram(Histogram.HistogramRGB);
            MinMaxAveragePixel =  RGBhistogram_imageClass.MaxMinPixelsMeth();
            txtMeanBlue.Text = MinMaxAveragePixel.averageB.ToString();
            txtMeanGreen.Text = MinMaxAveragePixel.averageG.ToString();
            txtMeanRed.Text = MinMaxAveragePixel.averageR.ToString();



            List<long> histogramBlue = RGBhistogram_imageClass.ListOfHistogramRGB[0].ToList<long>();
            List<long> histogramGreen = RGBhistogram_imageClass.ListOfHistogramRGB[1].ToList<long>();
            List<long> histogramRed = RGBhistogram_imageClass.ListOfHistogramRGB[2].ToList<long>();


            histogramRGB.Series["Blue"].Points.DataBindXY(Enumerable.Range(1, 256).ToList(), histogramBlue);
            histogramRGB.Series["Green"].Points.DataBindXY(Enumerable.Range(1, 256).ToList(), histogramGreen);
            histogramRGB.Series["Red"].Points.DataBindXY(Enumerable.Range(1, 256).ToList(), histogramRed);
            Axis ax = histogramRGB.ChartAreas[0].AxisX;
            ax.Minimum = 0;
            ax.Maximum = 255;
        }
    }
}
