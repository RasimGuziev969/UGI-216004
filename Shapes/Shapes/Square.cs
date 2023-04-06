using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(double x, double y, double side): base(x, y, side, side) { }
    }
}
