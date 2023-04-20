using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        GRectangle rectangle;

        public Rectangle(GRectangle rectangle) 
        {
            this.rectangle = rectangle;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
