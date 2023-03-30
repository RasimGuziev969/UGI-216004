using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter<LighteningParameters>
    {
        public override Pixel ProcessPixel(Pixel pixel, LighteningParameters parameters)
        {
            return pixel * parameters.Coefficient;
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
