using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double r)
        {
            Center = new Point(x, y);
            Radius = r;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
