using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class GrayScaleFilter : IFilter
    {
        public ParameterInfo[] GetParametersInfo()
        {
            return new ParameterInfo[0];
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (var x = 0; x < original.Width; x++)
                for (var y = 0; y < original.Height; y++)
                {
                    var lightness = 0.3 * original[x, y].R + 0.6 * original[x, y].G + 0.1 * original[x, y].B;
                    newPhoto[x, y] = new Pixel(lightness, lightness, lightness);
                }

            return newPhoto;
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }
    }
}
