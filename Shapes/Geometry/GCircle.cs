using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class GCircle : IMeasureable
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public double Area => Math.PI * Radius * Radius;

        public double Perimetr => 2 * Math.PI * Radius;

        public GCircle(double x, double y, double r)
        {
            Center = new Point(x, y);
            Radius = r;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
