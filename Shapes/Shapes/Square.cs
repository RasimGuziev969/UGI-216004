using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        public Point TopLeft { get; set; }
        public double Side { get; set; }

        public override double Area => Side * Side;
                
        public Square(double x, double y, double side)
        { 
            TopLeft = new Point(x, y);
            Side = side;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
