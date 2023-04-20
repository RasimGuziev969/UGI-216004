using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public static class ShapeCalculator
    {
        public static double GetOverAllArea(List<Shape> shapes)
        {
            double result = 0;
            
            foreach (Shape shape in shapes)
                result += shape.Area;
            
            return result;
        }
    }
}
