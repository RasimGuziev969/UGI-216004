using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : IDrawable
    {
        GSquare square;

        public Square(GSquare square)
        {
            this.square = square;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
