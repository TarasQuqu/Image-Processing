namespace Csharp
{
    partial class GrayscaleHistogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.histogramGrayscale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMean = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.histogramGrayscale)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramGrayscale
            // 
            chartArea1.Name = "ChartArea1";
            this.histogramGrayscale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.histogramGrayscale.Legends.Add(legend1);
            this.histogramGrayscale.Location = new System.Drawing.Point(12, 12);
            this.histogramGrayscale.Name = "histogramGrayscale";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Gray;
            series1.Legend = "Legend1";
            series1.Name = "Grey";
            this.histogramGrayscale.Series.Add(series1);
            this.histogramGrayscale.Size = new System.Drawing.Size(492, 386);
            this.histogramGrayscale.TabIndex = 4;
            this.histogramGrayscale.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(623, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(543, 36);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(39, 20);
            this.txtMax.TabIndex = 8;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(543, 62);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(39, 20);
            this.txtMin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mean";
            // 
            // txtMean
            // 
            this.txtMean.Location = new System.Drawing.Point(543, 89);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new System.Drawing.Size(39, 20);
            this.txtMean.TabIndex = 11;
            // 
            // GrayscaleHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 403);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histogramGrayscale);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GrayscaleHistogram";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.histogramGrayscale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart histogramGrayscale;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMean;
    }
}