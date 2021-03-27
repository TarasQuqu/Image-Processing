using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    class MinMaxAveragePixel
    {
        public int min, max;
        public double averageGrayscale;
        public double averageR, averageB, averageG;
        public MinMaxAveragePixel()
        {
            averageB = 0;
            averageG = 0;
            averageR = 0;
            averageGrayscale = 0;
            min = 255;
            max = 0;
        }
    }
}
