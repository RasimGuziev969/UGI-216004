using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class GRectangle : IMeasureable
    {
        public Point TopLeft { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area => Width * Height;

        public double Perimetr => 2 * (Width + Height);

        public GRectangle(double x, double y, double width, double height) 
        {
            TopLeft = new Point(x, y);
            Width = width;
            Height = height;
        }   

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
