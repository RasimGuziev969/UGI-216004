using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public static class ShapeCalculator
    {
        public static double GetOverAllArea(List<IMeasureable> shapes)
        {
            double result = 0;
            
            foreach (IMeasureable shape in shapes)
                result += shape.Area;
            
            return result;
        }
    }
}
