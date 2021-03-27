namespace Csharp
{
    partial class RGBhistogram
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.histogramRGB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeanBlue = new System.Windows.Forms.TextBox();
            this.txtMeanRed = new System.Windows.Forms.TextBox();
            this.txtMeanGreen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.histogramRGB)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramRGB
            // 
            chartArea1.Name = "ChartArea1";
            this.histogramRGB.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.histogramRGB.Legends.Add(legend1);
            this.histogramRGB.Location = new System.Drawing.Point(8, 9);
            this.histogramRGB.Name = "histogramRGB";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Lime;
            series1.Legend = "Legend1";
            series1.Name = "Green";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Red";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Aqua;
            series3.Legend = "Legend1";
            series3.Name = "Blue";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Gray;
            series4.Legend = "Legend1";
            series4.Name = "Grey";
            this.histogramRGB.Series.Add(series1);
            this.histogramRGB.Series.Add(series2);
            this.histogramRGB.Series.Add(series3);
            this.histogramRGB.Series.Add(series4);
            this.histogramRGB.Size = new System.Drawing.Size(467, 386);
            this.histogramRGB.TabIndex = 5;
            this.histogramRGB.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mean of Blue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mean of Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mean of Green";
            // 
            // txtMeanBlue
            // 
            this.txtMeanBlue.Location = new System.Drawing.Point(582, 20);
            this.txtMeanBlue.Name = "txtMeanBlue";
            this.txtMeanBlue.Size = new System.Drawing.Size(60, 20);
            this.txtMeanBlue.TabIndex = 9;
            // 
            // txtMeanRed
            // 
            this.txtMeanRed.Location = new System.Drawing.Point(582, 70);
            this.txtMeanRed.Name = "txtMeanRed";
            this.txtMeanRed.Size = new System.Drawing.Size(60, 20);
            this.txtMeanRed.TabIndex = 10;
            // 
            // txtMeanGreen
            // 
            this.txtMeanGreen.Location = new System.Drawing.Point(582, 44);
            this.txtMeanGreen.Name = "txtMeanGreen";
            this.txtMeanGreen.Size = new System.Drawing.Size(60, 20);
            this.txtMeanGreen.TabIndex = 11;
            // 
            // RGBhistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 422);
            this.Controls.Add(this.txtMeanGreen);
            this.Controls.Add(this.txtMeanRed);
            this.Controls.Add(this.txtMeanBlue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histogramRGB);
            this.Name = "RGBhistogram";
            this.Text = "RGBhistogram";
            ((System.ComponentModel.ISupportInitialize)(this.histogramRGB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart histogramRGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMeanBlue;
        private System.Windows.Forms.TextBox txtMeanRed;
        private System.Windows.Forms.TextBox txtMeanGreen;
    }
}