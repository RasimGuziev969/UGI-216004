using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        // по размеру старой картинки и параметрам определяет размер новой
        Func<Size, TParameters, Size> sizeTransform;

        // по точке новой картинки, старому размеру параметрам определяет какая точка
        // перейдет в неё из старой картинки или никакая
        Func<Point, Size, TParameters, Point?> pointTransform;

        public TransformFilter(string name, 
            Func<Size, TParameters, Size> sizeTransform, 
            Func<Point, Size, TParameters, Point?> pointTransform)
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);

            for(var x= 0; x< newSize.Width; x++)
                for(var y= 0; y< newSize.Height; y++)
                {
                    var oldPoint = pointTransform(new Point(x, y), oldSize, parameters);

                    if(oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }
    }
}
