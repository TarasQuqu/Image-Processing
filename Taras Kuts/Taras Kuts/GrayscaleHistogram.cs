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
    partial class GrayscaleHistogram : Form
    {
        public ImageManipulation GrayscaleHistogram_imageClass { get; set; }
        MinMaxAveragePixel MinMaxAveragePixel = new MinMaxAveragePixel();
        public GrayscaleHistogram(ref ImageManipulation ImageClass)
        {
            GrayscaleHistogram_imageClass = ImageClass;
            InitializeComponent();
            HistogramShow();

        }
        public void HistogramShow()
        {
            GrayscaleHistogram_imageClass.GetHistogram(Histogram.Histogram);
            MinMaxAveragePixel = GrayscaleHistogram_imageClass.MaxMinPixelsMeth();
            histogramGrayscale.Invalidate();
            txtMax.Text = MinMaxAveragePixel.max.ToString();
            txtMin.Text = MinMaxAveragePixel.min.ToString();
            txtMean.Text = MinMaxAveragePixel.averageGrayscale.ToString();
            List<long> histogramGray = GrayscaleHistogram_imageClass.ListOfHistogramGrey[0].ToList<long>();
            histogramGrayscale.Series["Grey"].Points.DataBindXY(Enumerable.Range(1, 256).ToList(), histogramGray);
            Axis ax = histogramGrayscale.ChartAreas[0].AxisX;
            ax.Minimum = 0;
            ax.Maximum = 255;
        }


    }
}
