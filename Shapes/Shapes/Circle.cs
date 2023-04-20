using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        GCircle circle;

        public Circle(GCircle circle)
        {
            this.circle = circle;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
