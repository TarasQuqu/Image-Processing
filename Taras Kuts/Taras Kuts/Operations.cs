using AForge.Imaging.Filters;
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
     partial class Operations : Form
    {
        public ImageManipulation mask_imageClass { get; set; }
        int Max,Min;
        uint kDiv = 0;
        int userPixel = 0;
        int ComprSize;
        int TreshCur;
        int Pi1, Pi2, Q1, Q2;
        int medUserPixel = 0;
        short[,] rombs = { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
        short[,] square = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        List<TextBox> txtMaskMatrixList = new List<TextBox>();
        List<TextBox> txtEdgeMatrixList = new List<TextBox>();
        List<TextBox> txtGraduationMatrixList = new List<TextBox>();
        List<TextBox> txtSize1 = new List<TextBox>();
        List<TextBox> txtSize2 = new List<TextBox>();
        List<TextBox> txtEdgeList = new List<TextBox>();
        List<int[,]> intMaskList = new List<int[,]>();
        List<int[,]> intEdgeList = new List<int[,]>();
        List<int[,]> intGraduationList = new List<int[,]>();
        int maskSizeX = 3, maskSizeY = 3;
        masksAplied mask;
        public Operations(ref ImageManipulation ImageClass)
        {
            mask_imageClass = ImageClass;
            InitializeComponent();
            rdReductionwithpar.Enabled = false;
            rdStratchingMinMax.Enabled = false;
            rdTreshholdMinMax.Enabled = false;
            rdTreshhold.Enabled = false;
            pictureBox1.Image = ImageClass.imgBitMap;
            init();
            initMasks();
        }
        void parseUserPixel()
        {
            int userPixel;
            Int32.TryParse(txtUserPixel.Text, out userPixel);
        }
        private void initMasks()
        {
            intMaskList.Add(new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } }); //onNine 
            intMaskList.Add(new int[3, 3] { { 1, 1, 1 }, { 1, 2, 1 }, { 1, 1, 1 } });//onTen
            intMaskList.Add(new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } });//onSixteen
            intMaskList.Add(new int[3, 3] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } });//cyfrowaLaplas
            intMaskList.Add(new int[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } });//laplasA
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } });//laplasB
            intMaskList.Add(new int[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } });//laplasC
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } });//laplasD
            intMaskList.Add(new int[3, 3] { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } });//edgeOne
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } });//edgeTwo
            intMaskList.Add(new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } });//edgeThree
            intMaskList.Add(new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } });//Sobela
            intMaskList.Add(new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } });//Sobela2
            intMaskList.Add(new int[3, 3] { { -1, 0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } });//Prewitt
            intMaskList.Add(new int[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } });//Prewitt2
            intMaskList.Add(new int[3, 3] { { -2, -2, -2 }, { 1, 0, 1 }, { 3, 1, 3 } });//Universal
            intMaskList.Add(new int[3, 3] { { -4, -4, -1 }, { 2, 2, 2 }, { 4, 4, 4 } });//Universal2
        }
        void init()
        {
            string[] masks = new string[] { "Wygladzanie 1/9", "Wygladzanie 1/10", "Wygladzanie 1/16", "Wyostrzanie cyfroweLaplasa", "LaplasA", "LaplasB", "LaplasC", "LaplasD", "edgeOne", "edgeTwo", "edgeThree", "Sobela", "Sobela2", "Prewitt", "Prewitt2", "Universal", "Universal2" };
            foreach (var item in masks) { cbMasks.Items.Add(item); }
            string[] edges = new string[] { "Nothing to change","Random","UserPixel","Black" };
            foreach (var item in edges) { cbEdge.Items.Add(item); }
            string[] graduations = new string[] { "Grad1", "Grad2", "Grad3" };
            foreach (var item in graduations) { cbGraduation.Items.Add(item); }
            string[] edges2 = new string[] { "NothingToChange", "Random", "Your","Black" };
            foreach (var item in edges2) { cmEdge2.Items.Add(item); }
            string[] Size1 = new string[] { "3", "5", "7"};
            foreach (var item in Size1) { cmFirstSize.Items.Add(item); }
            string[] Size2 = new string[] { "3", "5", "7"};
            foreach (var item in Size2) { cmSecondSize.Items.Add(item); }

            // }
            var query = tabCtrlLab.TabPages[0].Controls.Cast<Control>().OrderBy((ctrl) => ctrl.Location.Y).ThenBy((ctrl) => ctrl.Location.X).Where((ctrl) => ctrl is TextBox && ctrl.Name.Substring(0, 7) == "txtMask").Select((ctrl) => ctrl as TextBox);
            foreach (var item in query)
            {
                txtMaskMatrixList.Add(item);
            }

        }
        private void cbMasks_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mask = (masksAplied)cbMasks.SelectedIndex;
            int k = 0;
            for (int i = 0; i < maskSizeX; i++)
            {
                for (int j = 0; j < maskSizeY; j++)
                {
                    txtMaskMatrixList[k].Text = Convert.ToString(intMaskList[(int)mask].GetValue(i, j));
                    k++;
                }
            }
        }
        private void btnApplyMask_Click_1(object sender, EventArgs e)
        {
            if (cbOwnMask.Checked)
            {
                try
                {
                    int k = 0;
                    int[,] ownMask = new int[maskSizeX, maskSizeY];
                    for (int i = 0; i < maskSizeX; i++)
                    {
                        for (int j = 0; j < maskSizeY; j++)
                        {
                            ownMask[i, j] = Convert.ToInt32(txtMaskMatrixList[k].Text);
                            k++;
                        }
                    }
                    mask_imageClass.MaskOnImage(ownMask);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Exception");
                }
            }
            else if (mask <= masksAplied.onSixteen)
            {
                kDiv = 16;
                mask_imageClass.MaskOnImage(intMaskList[(int)mask], kDiv);
            }
            else if (mask <= masksAplied.onNine)
            {
                kDiv = 9;
                mask_imageClass.MaskOnImage(intMaskList[(int)mask], kDiv);
            }
            else if (mask <= masksAplied.onTen)
            {
                kDiv = 10;
                mask_imageClass.MaskOnImage(intMaskList[(int)mask], kDiv);
            }
            else { mask_imageClass.MaskOnImage2((int)userPixel, intMaskList[(int)mask], (edgeMethods)cbEdge.SelectedIndex, (Graduation)cbGraduation.SelectedIndex); }
            pictureBox1.Image = mask_imageClass.imgBitMap;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ResultPicture resultPicture = new ResultPicture(mask_imageClass.imgBitMap);
            resultPicture.ShowDialog();
        }
        private void cbOwnMask_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in txtMaskMatrixList)
            {
                item.ReadOnly = !cbOwnMask.Checked;
            }
        }
        private void Txbmin_TextChanged(object sender, EventArgs e)
        {
            rdTreshholdMinMax.Enabled = (Int32.TryParse(Txbmax.Text, out Max) && (Int32.TryParse(Txbmin.Text, out Min)));
            rdStratchingMinMax.Enabled = (Int32.TryParse(Txbmax.Text, out Max) && (Int32.TryParse(Txbmin.Text, out Min)));   
        }
            private void txtTreshhold_TextChanged(object sender, EventArgs e)
        {
            rdTreshhold.Enabled = (Int32.TryParse(txtTreshhold.Text, out TreshCur));
        }
        private void txtPi2_TextChanged(object sender, EventArgs e)
        {
            rdReductionwithpar.Enabled = (Int32.TryParse(txtPi1.Text, out Pi1) && Int32.TryParse(txtPi2.Text, out Pi2) && Int32.TryParse(txtQ1.Text, out Q1) && Int32.TryParse(txtQ2.Text, out Q2));
        }
        private void txtQ1_TextChanged(object sender, EventArgs e)
        {
            rdReductionwithpar.Enabled = (Int32.TryParse(txtPi1.Text, out Pi1) && Int32.TryParse(txtPi2.Text, out Pi2) && Int32.TryParse(txtQ1.Text, out Q1) && Int32.TryParse(txtQ2.Text, out Q2));
        }

        private void txtComressionPar_TextChanged(object sender, EventArgs e)
        {
            rdCompressionPar.Enabled = (Int32.TryParse(txtComressionPar.Text, out ComprSize));
        }

        private void btnCompression_Click(object sender, EventArgs e)
        {
            if (rdCodeHuff.Checked == true) { mask_imageClass.kompresjaHuffman(mask_imageClass.imgBitMap); }
            else if (rdRead.Checked == true) { mask_imageClass.kompresjaREAD(mask_imageClass.imgBitMap); }            
            else if(rdReductionwithpar.Checked == true)
            {
                if(ComprSize < 0 || ComprSize > 32) { MessageBox.Show("Enter number in range 0-32"); }
                else
                {
                    mask_imageClass.kompresjaBlokowa(mask_imageClass.imgBitMap, ComprSize);
                }
            }
        }
        void CountingMeanOfGray()
        {
            mask_imageClass.GetHistogram(Histogram.Histogram);
        }
        void ShowPicture()
        {
            pictureBox1.Image = mask_imageClass.imgBitMap;
        }

        private void btnApplyEqua_Click(object sender, EventArgs e)
        {
            CountingMeanOfGray();
            if (rdEqua1.Checked == true) { mask_imageClass.equalizingHistogram(equalizationsMetods.metoda1); pictureBox1.Image = mask_imageClass.imgBitMap; ShowPicture(); }
            else if (rdEqua2.Checked == true) { mask_imageClass.equalizingHistogram(equalizationsMetods.metoda2); ShowPicture(); }
            else if (rdEqua3.Checked == true) { mask_imageClass.equalizingHistogram(equalizationsMetods.metoda3); ShowPicture(); }
            else if (rdEqua4.Checked == true) { mask_imageClass.equalizingHistogram(equalizationsMetods.metoda4); ShowPicture(); }
            else if (rdStretching.Checked == true) { mask_imageClass.equalizingHistogram(equalizationsMetods.metoda4); ShowPicture(); }
        }

        private void btnApplyMediana_Click(object sender, EventArgs e)
        {
            mask_imageClass.MedianOnImage((maskSize)cmFirstSize.SelectedIndex, (maskSize)cmFirstSize.SelectedIndex, 3, 3, (edgeMethods)cmEdge2.SelectedIndex, medUserPixel);
            ShowPicture();
        }

        private void txtUserPixel1_TextChanged(object sender, EventArgs e)
        {
            if(cmEdge2.SelectedIndex == 2)
            {
                Int32.TryParse(txtUserPixel1.Text, out medUserPixel);
            }
        }

        private void txtQ2_TextChanged(object sender, EventArgs e)
        {
            rdReductionwithpar.Enabled = (Int32.TryParse(txtPi1.Text, out Pi1) && Int32.TryParse(txtPi2.Text, out Pi2) && Int32.TryParse(txtQ1.Text, out Q1) && Int32.TryParse(txtQ2.Text, out Q2));
        }
        private void btnApllyFilter_Click(object sender, EventArgs e)
        {
            if (rdDilation.Checked == true)
            {
                Dilatation dilation = new Dilatation();
                dilation.ApplyInPlace(mask_imageClass.imgBitMap);
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else if (rdErode.Checked == true)
            {
                Erosion erosion = new Erosion();
                erosion.ApplyInPlace(mask_imageClass.imgBitMap);
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else if (rdOpen.Checked == true)
            {
                Opening opening = new Opening();
                opening.ApplyInPlace(mask_imageClass.imgBitMap);
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else if (rdClosed.Checked == true)
            {
                Closing closing = new Closing();
                closing.ApplyInPlace(mask_imageClass.imgBitMap);
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else if(rdNegative.Checked == true)
            {
                mask_imageClass.imgBitMap = mask_imageClass.Negate(mask_imageClass.imgBitMap);
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else if(rdReductionwithpar.Checked == true)
            {
                if (Q1 < 0 || Q1 > 255 || Q2 < 0 || Q2 > 255 || Pi1 < 0 || Pi1 > 255 || Pi2 < 0 || Pi2 > 255) { MessageBox.Show("Enter numbers in range 0 - 255"); }
                else
                {
                    mask_imageClass.Redukcja(Pi1, Pi2, Q1, Q2);
                    pictureBox1.Image = mask_imageClass.imgBitMap;
                }
            }
            else if(rdStratchingMinMax.Checked == true)
            {
                if (Min < 0 || Min > 255)
                {
                    MessageBox.Show("Min gets numbers from  1 to 255");
                }
                else if (Min <= 0 || Min > 254)
                {
                    MessageBox.Show("Max gets numbers form 0 to 254");
                }
                else
                {
                    mask_imageClass.StratchingRang(Max, Min);
                    pictureBox1.Image = mask_imageClass.imgBitMap;
                }
            }
            else if(rdTreshholdMinMax.Checked == true)
            {
                if (Min < 0 || Min > 255)
                {
                    MessageBox.Show("Min gets numbers from  1 to 255");
                }
                else if (Min <= 0 || Min > 254)
                {
                    MessageBox.Show("Max gets numbers form 0 to 254");
                }
                else
                {
                    mask_imageClass.TresholdMinMax(Max, Min);
                    pictureBox1.Image = mask_imageClass.imgBitMap;
                }
            }
            else if(rdTreshhold.Checked == true)
            {
                if (TreshCur < 0 || TreshCur > 255) MessageBox.Show("The threshold value is in the [0, 255] range");
                else { mask_imageClass.Treshold(TreshCur); }
                pictureBox1.Image = mask_imageClass.imgBitMap;
            }
            else
            {
                MessageBox.Show("Choose one of the filters first");
            }
        }
        private void txtPi1_TextChanged(object sender, EventArgs e)
        {
            rdReductionwithpar.Enabled = (Int32.TryParse(txtPi1.Text, out Pi1) && Int32.TryParse(txtPi2.Text,out Pi2) && Int32.TryParse(txtQ1.Text, out Q1) && Int32.TryParse(txtQ2.Text,out  Q2));
        }

        private void Txbmax_TextChanged(object sender, EventArgs e)
        {
            rdStratchingMinMax.Enabled = (Int32.TryParse(Txbmax.Text, out Max) && (Int32.TryParse(Txbmin.Text,out Min)));
            rdStratchingMinMax.Enabled = (Int32.TryParse(Txbmax.Text, out Max) && (Int32.TryParse(Txbmin.Text, out Min)));
        }

        private void txtMask1_1_TextChanged(object sender, EventArgs e)
        {
            int temp;
            btnApplyMask.Enabled = Int32.TryParse((sender as TextBox).Text, out temp);
        }

   
    }
}
