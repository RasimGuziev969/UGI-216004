using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class GSquare : IMeasureable
    {
        public Point TopLeft { get; set; }
        public double Side { get; set; }

        public double Area => Side * Side;

        public double Perimetr => 4 * Side;

        public GSquare(double x, double y, double side)
        { 
            TopLeft = new Point(x, y);
            Side = side;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
