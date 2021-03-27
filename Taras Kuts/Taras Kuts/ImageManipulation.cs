using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp
{
    enum Graduation { first, second, third };
    enum maskSize { three = 0, five = 1, seven = 2 };
    enum edgeMethods { first, second, third, mine };
    enum masksAplied { onNine, onTen, onSixteen, cyfrowaLaplas, laplasA, laplasB, laplasC, laplasD, edgeOne, edgeTwo, edgeThree, Roberts, Roberts2, Prewitt, Prewitt2, Uniwersal1, Uniwersal }
    enum equalizationsMetods { metoda1, metoda2, metoda3, metoda4 };
    enum ArithmeticOperations { ADD, SUB, DIFF, OR, AND, XOR };
    enum Histogram { HistogramRGB, Histogram };
    class ImageManipulation
    {
        public Bitmap imgBitmapCOPY { set; get; }
        public Bitmap imgBitmap2 { set; get; }
        public Bitmap imgBitMap { set; get; }
        public List<long[]> ListOfHistogramGrey = new List<long[]>();
        public List<long[]> ListOfHistogramRGB = new List<long[]>();
        long[] histogramBlue = new long[256];
        long[] histogramRed = new long[256];
        long[] histogramGreen = new long[256];
        long[] histogramGray = new long[256];
        int min = 255;
        int max = 0;
        static int levels = 256;
        public double histogramAVG { get; set; }
        private static object imageLocker = new object();
        void Temp(out  BitmapData bmData, out int bytesPerPixel, out int heightInPixels, out int widthInPixels)//zeby kazdy raz nie pisac
        {
            bmData = imgBitMap.LockBits(new Rectangle(0, 0, imgBitMap.Width, imgBitMap.Height), ImageLockMode.ReadOnly, imgBitMap.PixelFormat);
            bytesPerPixel = Bitmap.GetPixelFormatSize(imgBitMap.PixelFormat) / 8;
            heightInPixels = imgBitMap.Height;
            widthInPixels = imgBitMap.Width * bytesPerPixel;
        }
        public ImageManipulation(Bitmap imgBitmap)
        {
            this.imgBitMap = imgBitmap;
            this.imgBitmapCOPY = imgBitmap;

        }
        public byte GetPixel(int x, int y, BitmapData bmpData)
        {
            unsafe
            {
                byte* ptr = (byte*)((byte*)bmpData.Scan0 + (y * bmpData.Stride) + x);
                return *ptr;
            }
        }
        public void SetPixel(int x, int y, BitmapData bmpData, byte value)
        {
            unsafe
            {
                byte* ptr = (byte*)((byte*)bmpData.Scan0 + (y * bmpData.Stride) + x);
                *ptr = value;
            }
        }
        public void MaskOnImage(int[,] maskArray, uint K)
        {
            Convolution applyMask = new Convolution(maskArray, (int)K);
            applyMask.ApplyInPlace(imgBitMap);
        }
        public void MaskOnImage(int[,] maskArray)
        {
            Convolution applyMask = new Convolution(maskArray);
            applyMask.ApplyInPlace(imgBitMap);
        }
        public void StratchingRang(int Max, int Min)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out  bmData, out  bytesPerPixel, out  heightInPixels, out  widthInPixels);
                for (int y = 0; y < heightInPixels; y++)
                {

                    for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                    {
                        if (Min <= GetPixel(x, y, bmData) && Max >= GetPixel(x, y, bmData))
                        {
                            SetPixel(x, y, bmData, (byte)((GetPixel(x, y, bmData) - Min) * (15 / (Max - Min))));
                        }
                        if (GetPixel(x, y, bmData) <= Min && GetPixel(x, y, bmData) > Max)
                        {
                            SetPixel(x, y, bmData, 0);
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in StratchingRange func");
                }
                catch
                {
                    throw new Exception("Some problem in StratchingRange func");
                }
            }
        }
        public void Redukcja(int pi1, int pi2, int q1, int q2)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int y = 0; y < heightInPixels; y++)
                {
                    for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                    {
                        if (GetPixel(x, y, bmData) <= pi1)
                            SetPixel(x, y, bmData, (byte)q1);
                        else if (GetPixel(x, y, bmData) > pi1 && GetPixel(x, y, bmData) <= pi2)
                        {
                            SetPixel(x, y, bmData, (byte)q2);
                        }
                        else
                        {
                            SetPixel(x, y, bmData, (byte)levels);
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in Redukcja func");
                }
                catch
                {
                    throw new Exception("Some problem in Redukcja func");
                }
            }
        }
        public void TresholdMinMax(int Max, int Min)
        {

            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int y = 0; y < heightInPixels; y++)
                {
                    for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                    {
                        if (GetPixel(x, y, bmData) < Min || GetPixel(x, y, bmData) > Max)
                        {
                            SetPixel(x, y, bmData, 0);
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in TreshholdMinMax func");
                }
                catch
                {
                    throw new Exception("Some problem in TreshholdMinMax func");
                }
            }

        }
        public void Treshold(int CurTresh)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                for (int y = 0; y < heightInPixels; y++)
                {
                    for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                    {
                        if (GetPixel(x, y, bmData) < CurTresh)
                            SetPixel(x, y, bmData, 0);
                        else
                            SetPixel(x, y, bmData, 255);
                    }
                }

                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in Treshhold func");
                }
                catch
                {
                    throw new Exception("Some problem in Treshhold func");
                }
            }

        }
        public void GetHistogram(Histogram histogramy)
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* ptrFirstPixel = (byte*)(void*)Scan0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            switch (histogramy)
                            {
                                case Histogram.HistogramRGB:
                                    histogramBlue[currentLine[x]]++;
                                    histogramGreen[currentLine[x + 1]]++;
                                    histogramRed[currentLine[x + 2]]++;
                                    break;
                                case Histogram.Histogram:
                                    histogramGray[currentLine[x]]++;
                                    break;
                            }
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in Histogram func");
                }
                catch
                {
                    throw new Exception("Some problem in Histogram func");
                }
            }
            ListOfHistogramGrey.Add(histogramGray);
            ListOfHistogramRGB.Add(histogramBlue);
            ListOfHistogramRGB.Add(histogramRed);
            ListOfHistogramRGB.Add(histogramGreen);
        }
        public MinMaxAveragePixel MaxMinPixelsMeth()
        {
            BitmapData bmData = null;
            MinMaxAveragePixel MinMaxAverage = new MinMaxAveragePixel();
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            MinMaxAverage.max = Math.Max(MinMaxAverage.max, GetPixel(x,y,bmData));
                            MinMaxAverage.min = Math.Min(MinMaxAverage.min, GetPixel(x,y,bmData));
                        }
                    }
                MinMaxAverage.averageG = histogramGreen.Average();
                MinMaxAverage.averageB = histogramBlue.Average();
                MinMaxAverage.averageR = histogramRed.Average();
                MinMaxAverage.averageGrayscale = histogramGray.Average();
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Some problem in MinMaxAverage func");
                }
                catch
                {
                    throw new Exception("Some problem in MinMaxAverage func");
                }
            }
            return MinMaxAverage;
        }
        public unsafe Bitmap Negate(Bitmap originalImage)
        {
            Bitmap finalImage = new Bitmap(
            originalImage.Width,
            originalImage.Height,
            PixelFormat.Format24bppRgb);

            lock (imageLocker)
            {
                BitmapData originalImageData = originalImage.LockBits(
                new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

                BitmapData finalImageData = finalImage.LockBits(
                new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

                int originalImageRemain = originalImageData.Stride - originalImageData.Width * 3;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width * 3;

                byte* originalImagePointer = (byte*)originalImageData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < originalImage.Height; ++i)
                {
                    for (int j = 0; j < originalImage.Width; ++j)
                    {
                        finalImagePointer[2] = (byte)(255 - originalImagePointer[2]);
                        finalImagePointer[1] = (byte)(255 - originalImagePointer[1]);
                        finalImagePointer[0] = (byte)(255 - originalImagePointer[0]);
                        originalImagePointer += 3;
                        finalImagePointer += 3;
                    }
                    originalImagePointer += originalImageRemain;
                    finalImagePointer += finalImageRemain;
                }
                imgBitMap.UnlockBits(originalImageData);
                finalImage.UnlockBits(finalImageData);
            }

            return finalImage;
        }
        public unsafe Bitmap ConvertToGrayScale(Bitmap originalImage)
        {
            Bitmap finalImage = new Bitmap(
            originalImage.Width,
            originalImage.Height,
            PixelFormat.Format8bppIndexed);

            //setting up a nice grayscale palette for a final image 
            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                BitmapData originalImageData = originalImage.LockBits(
                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

                BitmapData finalImageData = finalImage.LockBits(
                new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format8bppIndexed);

                //getting number of bits which are used for pad the bitmap 
                int originalImageRemain = originalImageData.Stride - originalImageData.Width * 3;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                //getting the pointers
                byte* originalImagePointer = (byte*)originalImageData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < originalImage.Height; ++i)
                {
                    for (int j = 0; j < originalImage.Width; ++j)
                    {
                        byte gray = (byte)(originalImagePointer[2] * 0.2989 +
                        originalImagePointer[1] * 0.5870 +
                        originalImagePointer[0] * 0.1140);

                        finalImagePointer[0] = gray;

                        originalImagePointer += 3;
                        finalImagePointer += 1;
                    }
                    originalImagePointer += originalImageRemain;
                    finalImagePointer += finalImageRemain;
                }
                originalImage.UnlockBits(originalImageData);
                finalImage.UnlockBits(finalImageData);
            }

            return finalImage;
        }
        public void equalizingHistogram(equalizationsMetods Metody)
        {
            double[] NEW = new double[256];
            long[] Right = new long[256];
            long[] Left = new long[256];
            int R = 0;
            long H = 0;
            BitmapData bmData = null;
            histogramAVG = histogramGray.Average();
            //double[] histogramGray = new double[256]; 
            int bytesPerPixel, heightInPixels, widthInPixels; 
            Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
            System.IntPtr Scan0 = bmData.Scan0;
            for (int z = 0; z <= 255; ++z)
            {
                Left[z] = Right[z];
                H += histogramGray[z];
                while (H > histogramAVG)
                {
                    H -= (int)histogramAVG;
                    R++;
                }
                Right[z] = R;
                switch (Metody)
                {
                    case equalizationsMetods.metoda1:
                        NEW[z] = (Right[z] + Left[z]) / 2;
                        break;
                    case equalizationsMetods.metoda2:
                        NEW[z] = (Right[z] - Left[z]);
                        break;
                    case equalizationsMetods.metoda4:
                        NEW[z] = (Right[z] + Left[z] / 2) + (Right[z] / 2);
                        break;
                    default:
                        break;
                }
            }


            unsafe
            {
                Point[] neighbourPoints = new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) };
                for (int i = 0; i < neighbourPoints.Length; i++)
                {
                    neighbourPoints[i].X = neighbourPoints[i].X * bytesPerPixel;
                }
                byte* ptrFirstPixel = (byte*)(void*)Scan0;
                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                    for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                    {
                        if (Left[currentLine[x]] == Right[currentLine[x]])
                        {
                            currentLine[x] = (byte)Left[currentLine[x]];
                        }
                        else
                        {
                            Random rnd = new Random();
                            switch (Metody)
                            {
                                case equalizationsMetods.metoda1:
                                    currentLine[x] = (byte)NEW[currentLine[x]];
                                    break;
                                case equalizationsMetods.metoda2:
                                    currentLine[x] = (byte)(rnd.Next(0, Convert.ToInt32(NEW[currentLine[x]])) + (Left[currentLine[x]]));
                                    break;
                                case equalizationsMetods.metoda3:
                                    int avg = 0, count = 0;
                                    foreach (var Point in neighbourPoints)
                                    {
                                        if (x + Point.X >= 0 && x + Point.X < widthInPixels && y + Point.Y >= 0 && y + Point.Y < heightInPixels)
                                        {
                                            byte* tempLine = ptrFirstPixel + ((y + Point.Y) * bmData.Stride);

                                            avg += tempLine[x + Point.X];
                                            ++count;
                                        }
                                    }
                                    avg /= count;
                                    if (avg > Right[currentLine[x]]) currentLine[x] = (byte)Right[currentLine[x]];
                                    else if (avg < Left[currentLine[x]]) currentLine[x] = (byte)Left[currentLine[x]];
                                    else currentLine[x] = (byte)avg;
                                    break;
                                case equalizationsMetods.metoda4:
                                    currentLine[x] = (byte)NEW[currentLine[x]];
                                    break;
                                default:
                                    break;
                            }


                        }
                    }
                }
            }
            imgBitMap.UnlockBits(bmData);

        }
        public void OperationArythmeticandLogic(ArithmeticOperations operations)
        {
            BitmapData bmData1 = null;
            BitmapData bmData2 = null;
            BitmapData bmDataResult = null;
            Bitmap bit1 = null;
            Bitmap bit2 = null;

            try
            {
                bmData1 = imgBitMap.LockBits(new Rectangle(0, 0, imgBitMap.Width, imgBitMap.Height), ImageLockMode.ReadOnly, imgBitMap.PixelFormat);
                bmData2 = imgBitmap2.LockBits(new Rectangle(0, 0, imgBitmap2.Width, imgBitmap2.Height), ImageLockMode.ReadOnly, imgBitmap2.PixelFormat);
                int bytesPerPixel = Bitmap.GetPixelFormatSize(imgBitMap.PixelFormat) / 8;
                int heightInPixels = imgBitMap.Height > imgBitMap.Height ? imgBitMap.Height : imgBitMap.Height;
                int widthInPixels = imgBitmap2.Width > imgBitmap2.Width ? imgBitmap2.Width * bytesPerPixel : imgBitMap.Width * bytesPerPixel;
                imgBitMap.UnlockBits(bmData1);
                imgBitmap2.UnlockBits(bmData2);
                bit1 = new Bitmap(imgBitMap, widthInPixels, heightInPixels);
                bit2 = new Bitmap(imgBitmap2, widthInPixels, heightInPixels);
                bmData1 = bit1.LockBits(new Rectangle(0, 0, bit1.Width, bit1.Height), ImageLockMode.ReadOnly, bit1.PixelFormat);
                bmData2 = bit2.LockBits(new Rectangle(0, 0, bit2.Width, bit2.Height), ImageLockMode.ReadOnly, bit2.PixelFormat);
                bmDataResult = imgBitmapCOPY.LockBits(new Rectangle(0, 0, imgBitmapCOPY.Width, imgBitmapCOPY.Height), ImageLockMode.ReadOnly, imgBitmapCOPY.PixelFormat);


                System.IntPtr Scan01 = bmData1.Scan0;
                System.IntPtr Scan02 = bmData2.Scan0;
                System.IntPtr Scan0Res = bmDataResult.Scan0;
                unsafe
                {
                    byte* ptrFirstPixel1 = (byte*)(void*)Scan01;
                    byte* ptrFirstPixel2 = (byte*)(void*)Scan02;
                    byte* ptrFirstPixelRes = (byte*)(void*)Scan0Res;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine1 = ptrFirstPixel1 + (y * bmData1.Stride);
                        byte* currentLine2 = ptrFirstPixel2 + (y * bmData2.Stride);
                        byte* currentLineRes = ptrFirstPixelRes + (y * bmDataResult.Stride);
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            switch (operations)
                            {
                                case ArithmeticOperations.OR:
                                    currentLineRes[x] = (byte)(currentLine1[x] | currentLine2[x]);
                                    break;
                                case ArithmeticOperations.AND:
                                    currentLineRes[x] = (byte)(currentLine1[x] & currentLine2[x]);
                                    break;
                                case ArithmeticOperations.ADD:
                                    currentLineRes[x] = (byte)((currentLine1)[x] + currentLine2[x]);
                                    break;
                                case ArithmeticOperations.XOR:
                                    currentLineRes[x] = (byte)(currentLine1[x] ^ currentLine2[x]);
                                    break;
                                case ArithmeticOperations.DIFF:
                                    currentLineRes[x] = (byte)Math.Abs(currentLine1[x] - currentLine2[x]);
                                    break;
                                case ArithmeticOperations.SUB:
                                    currentLineRes[x] = (byte)(currentLine1[x] - currentLine2[x]);
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
                bit1.UnlockBits(bmData1);
                bit2.UnlockBits(bmData2);
                imgBitmapCOPY.UnlockBits(bmDataResult);
            }
            catch
            {
                try
                {
                    bit1.UnlockBits(bmData1);
                    bit2.UnlockBits(bmData2);
                    imgBitmapCOPY.UnlockBits(bmDataResult);
                }
                catch
                {
                }
            }
        }

        public void StretchHistogram()
        {
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                System.IntPtr Scan0 = bmData.Scan0;
                int multiplier = max != 0 ? 255 / (max - min) : 0;
                int newPixel;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            int oldPixel = GetPixel(x,y,bmData);
                            if (oldPixel <= min || oldPixel > max) newPixel = 0;
                            else newPixel = (oldPixel - min) * multiplier;
                            SetPixel(x,y,bmData, (byte)newPixel);
                        }
                    }
               
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                    throw new Exception("Error in stretch histogram function");

                }
                catch
                {
                    throw new Exception("Error in stretch histogram function");

                }
            }
        }
        public void MedianOnImage(maskSize xSize, maskSize ySize, int xSizeInt, int ySizeInt, edgeMethods method, int userPixel)
        {
            BitmapData bmData = null;
            Random rnd = new Random();
            Point[] points = new Point[xSizeInt * ySizeInt];
            int heightInPixels, widthInPixels, bytesPerPixel;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                //Lock it fixed with 32bpp 
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* ptrFirstPixel = (byte*)bmData.Scan0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (!((y >= heightInPixels - 1 - (int)ySize) || (y <= (int)ySize) || (x >= widthInPixels - 1 - (int)xSize) || (x <= (int)xSize)))
                            {

                                int[] neighbours = new int[xSizeInt * ySizeInt];
                                int a = 0;
                                for (int k = -xSizeInt / 2; k <= xSizeInt / 2; ++k)
                                    for (int l = -ySizeInt / 2; l <= ySizeInt / 2; ++l)
                                    {
                                        neighbours[a++] = Marshal.ReadByte((IntPtr)((byte*)Scan0 + ((y + l) * bmData.Stride) + (x + k)));
                                    }

                                Array.Sort(neighbours);
                                if (neighbours.Length % 2 == 1)
                                    currentLine[x] = (byte)neighbours[neighbours.Length / 2];
                                else
                                    currentLine[x] = (byte)Math.Min((neighbours[neighbours.Length / 2] + neighbours[(neighbours.Length / 2) + 1]) / 2, levels - 1);
                            }
                            else
                            {
                                OnEdgeOperation(currentLine, x, method, userPixel);
                            }
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public unsafe void OnEdgeOperationForMorph(edgeMethods methods, int userPixel)
        {
            Random rnd = new Random();
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                //Lock it fixed with 32bpp 
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* ptrFirstPixel = (byte*)(void*)Scan0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (((y == heightInPixels - 1) || (y == 0) || (x == widthInPixels - 1 || (x == 0))))
                            {
                                OnEdgeOperation(currentLine, x, methods, userPixel);
                            }
                        }
                    }
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public unsafe void OnEdgeOperation(byte* currentLine, int x, edgeMethods method, int userPixel)
        {
            Random rnd = new Random();
            unsafe
            {
                switch (method)
                {
                    case edgeMethods.first:
                        return;
                        break;
                    case edgeMethods.second:
                        currentLine[x] = (byte)rnd.Next(0, 255);
                        break;
                    case edgeMethods.third:
                        currentLine[x] = (byte)userPixel;
                        break;
                    case edgeMethods.mine:
                        currentLine[x] = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        public unsafe void MaskOnImage2(int userPixel, int[,] maskArray, edgeMethods methods, Graduation graduation)
        {
            Convolution applyMask = new Convolution(maskArray);
            applyMask.ApplyInPlace(imgBitMap);
            Random rnd = new Random();
            BitmapData bmData = null;
            int bytesPerPixel, heightInPixels, widthInPixels;
            try
            {
                Temp(out bmData, out bytesPerPixel, out heightInPixels, out widthInPixels);
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* ptrFirstPixel = (byte*)(void*)Scan0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                        for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                        {
                            if (((y == heightInPixels - 1) || (y == 0) || (x == widthInPixels - 1 || (x == 0))))
                            {
                                OnEdgeOperation(currentLine, x, methods, userPixel);
                            }
                        }
                    }
                    Graduation(graduation);
                }
                imgBitMap.UnlockBits(bmData);
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                }
                catch
                {
                }
            }
        }
        public void kompresjaREAD(Bitmap bitmap)
        {
            BitmapData bmData = null;

            const int PIXELLEN = 1;
            const int WORDLEN = 1;

            int newColor = 255, lastColor = 0;
            int repeatCount = 0;
            int total = 0;

            int width = bitmap.Width;
            int height = bitmap.Height;
            int fld = width * height;
            int before, after;
            float stopien;

            before = fld * PIXELLEN;
            try
            {
                //Lock it fixed with 32bpp 
                bmData = imgBitMap.LockBits(new Rectangle(0, 0, imgBitMap.Width, imgBitMap.Height), ImageLockMode.ReadOnly, imgBitMap.PixelFormat);

                //Przeglad wierszami
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        newColor = GetPixel(x, y, bmData);

                        //Jesli ten sam kolor
                        if (newColor == lastColor)
                        {
                            repeatCount++;
                        }
                        else
                        {

                            if (repeatCount > 0)
                            {
                                total += WORDLEN + PIXELLEN;
                                repeatCount = 0;
                            }

                            total += WORDLEN + PIXELLEN;
                        }

                        lastColor = GetPixel(x, y, bmData);
                    }

                if (repeatCount > 0)
                {
                    total += WORDLEN + PIXELLEN;
                    repeatCount = 0;
                }

                //Przeglad kolumnami
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        newColor = GetPixel(x, y, bmData);

                        //Jesli ten sam kolor
                        if (newColor == lastColor)
                        {
                            repeatCount++;
                        }
                        else
                        {
                            if (repeatCount > 0)
                            {
                                total += WORDLEN + PIXELLEN;
                                repeatCount = 0;
                            }
                            total += WORDLEN + PIXELLEN;
                        }
                        lastColor = GetPixel(x, y, bmData);
                    }

                if (repeatCount > 0)
                {
                    total += WORDLEN + PIXELLEN;
                    repeatCount = 0;
                }

                after = total / 2;
                stopien = (float)(float)before / (float)after;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int Levels = (int)Math.Pow(2, i);
                    if (Levels < levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                imgBitMap.UnlockBits(bmData);
                MessageBox.Show("\nRozmiar przed kompresją: " + before * div
                                + "\n\nRozmiar po kompresji: " + after * div
                                + "\n\nStopień kompresji: " + stopien, "Kompresja READ");
            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);

                }
                catch
                {
                    throw new Exception("Can't Kompresion");
                }
            }

        }
        public Bitmap kompresjaBlokowa(Bitmap originalImage, int size)
        {
            int color = 0;
            float avg;
            float avgUP;
            float avgDOWN;
            int countUP;
            int countDOWN;
            int countAVG;
            int sizeAfter = 0;
            Bitmap bmp = (Bitmap)originalImage.Clone();
            BitmapData bmData = null;
            try
            {
                bmData = imgBitMap.LockBits(new Rectangle(0, 0, imgBitMap.Width, imgBitMap.Height), ImageLockMode.ReadOnly, imgBitMap.PixelFormat);

                for (int y = 0; y < originalImage.Size.Height; y += size)
                    for (int x = 0; x < originalImage.Size.Width; x += size)
                    {
                        avg = 0;
                        countAVG = 0;
                        for (int yy = 0; yy < size; ++yy)
                        {
                            for (int xx = 0; xx < size; ++xx)
                            {
                                if (x + xx < originalImage.Size.Width && y + yy < originalImage.Size.Height)
                                {
                                    color = GetPixel(x + xx, y + yy, bmData);
                                    avg += color;
                                    ++countAVG;
                                }
                            }
                        }
                        avg /= countAVG;
                        avg = (int)avg;

                        avgUP = 0;
                        avgDOWN = 0;
                        countDOWN = 0;
                        countUP = 0;
                        for (int yy = 0; yy < size; ++yy)
                        {
                            for (int xx = 0; xx < size; ++xx)
                            {
                                if (x + xx < originalImage.Size.Width && y + yy < originalImage.Size.Height)
                                {
                                    color = GetPixel(x + xx, y + yy, bmData);
                                    if (color >= avg) { avgUP += color; ++countUP; }
                                    else { avgDOWN += color; ++countDOWN; }
                                }
                            }
                        }
                        avgUP /= countUP;
                        avgDOWN /= countDOWN;
                        avgUP = (int)avgUP;
                        avgDOWN = (int)avgDOWN;

                        for (int yy = 0; yy < size; ++yy)
                            for (int xx = 0; xx < size; ++xx)
                                if (x + xx < originalImage.Size.Width && y + yy < originalImage.Size.Height)
                                    if (GetPixel(x + xx, y + yy, bmData) >= avg) SetPixel(x + xx, y + yy, bmData, (byte)avgUP);
                                    else SetPixel(x + xx, y + yy, bmData, (byte)avgDOWN);

                        sizeAfter += countAVG + 16;
                    }

                int sizeBefore = originalImage.Size.Width * originalImage.Size.Height * 8;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int Levels = (int)Math.Pow(2, i);
                    if (Levels < levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                imgBitMap.UnlockBits(bmData);
                MessageBox.Show("\nRozmiar przed kompresją: " + sizeBefore * div
                            + "\n\nRozmiar po kompresji: " + sizeAfter * div
                            + "\n\nStopień kompresji: " + (float)sizeBefore / (float)sizeAfter, "Kompresja blokowa");

            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                }
                catch
                {
                    imgBitMap.UnlockBits(bmData);
                }
            }


            return bmp;
        }

        public void kompresjaHuffman(Bitmap originalImage)
        {

            int x = 2;
            int licznik = 0;
            int przed;
            int po = 0;
            float stopien;
            int moc = 2;
            int ilosc = 0;
            BitmapData bmData = null;
            int[] phist = new int[levels];
            przed = originalImage.Width * originalImage.Height;
            try
            {
                bmData = imgBitMap.LockBits(new Rectangle(0, 0, imgBitMap.Width, imgBitMap.Height), ImageLockMode.ReadOnly, imgBitMap.PixelFormat);

                for (int y = 0; y < originalImage.Height; y++)
                    for (int xx = 0; xx < originalImage.Width; xx++)
                        phist[GetPixel(xx, y, bmData)] += 1;

                for (int i = 0; i < levels; i++)
                {
                    if (phist[i] != 0)
                    {
                        licznik++;
                        po += (licznik * phist[i]);

                        if (licznik >= Math.Pow((double)x, (double)moc))
                        {
                            licznik = 0;
                            moc++;
                        }
                        ilosc++;
                    }

                    if (licznik == 1)
                    {
                        po = przed + 1;
                    }
                }

                po /= 8;
                po += (ilosc * 2);

                stopien = (float)(float)przed / (float)po;

                int bits = 0;
                for (int i = 1; i <= 8; i++)
                {
                    int Levels = (int)Math.Pow(2, i);
                    if (Levels < levels) continue;
                    bits = i;
                    break;
                }
                float div = bits / 8.0f;
                imgBitMap.UnlockBits(bmData);
                MessageBox.Show("\nRozmiar przed kompresją: " + przed * div
                + "\n\nRozmiar po kompresji: " + po * div
                + "\n\nStopień kompresji: " + stopien, "Kompresja Huffman");

            }
            catch
            {
                try
                {
                    imgBitMap.UnlockBits(bmData);
                }
                catch
                {

                }
            }
        }
        public unsafe void Graduation(Graduation graduation)
                {
                    Random rnd = new Random();
                    BitmapData bmData = null;
                    int bytesPerPixel, heightInPixels, widthInPixels;
                    try
                    {
                //Lock it fixed with 32bpp 
                        Temp(out bmData,out bytesPerPixel,out  heightInPixels,out  widthInPixels);
                        System.IntPtr Scan0 = bmData.Scan0;
                        unsafe
                        {
                            byte* ptrFirstPixel = (byte*)(void*)Scan0;
                            for (int y = 0; y < heightInPixels; y++)
                            {
                                byte* currentLine = ptrFirstPixel + (y * bmData.Stride);
                                for (int x = 0; x < widthInPixels; x += bytesPerPixel)
                                {
                                    switch (graduation)
                                    {
                                        case Csharp.Graduation.first:
                                            currentLine[x] = (byte)((currentLine[x] - min) / (max - min) * (levels - 1));
                                            break;
                                        case Csharp.Graduation.second:
                                            if (currentLine[x] < 0)
                                            {
                                                currentLine[x] = 0;
                                            }
                                            else if (currentLine[x] > 0)
                                            {
                                                currentLine[x] = (byte)(levels - 1);
                                            }
                                            else
                                            {
                                                currentLine[x] = (byte)(levels - 1);
                                            }

                                            break;
                                        case Csharp.Graduation.third:
                                            if (currentLine[x] < 0)
                                            {
                                                currentLine[x] = 0;
                                            }
                                            else if (0 <= currentLine[x] && currentLine[x] <= levels - 1)
                                            {
                                                currentLine[x] = currentLine[x];
                                            }
                                            else if (currentLine[x] > levels - 1)
                                            {
                                                currentLine[x] = (byte)(levels - 1);
                                            }
                                            break;
                                    }
                                }
                            }
                            imgBitMap.UnlockBits(bmData);
                        }
                    }
                    catch
                    {
                        try
                        {
                            imgBitMap.UnlockBits(bmData);
                        }
                        catch
                        {
                        }
                    }
                }

            }
}

    



