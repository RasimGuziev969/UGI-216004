using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Rectangle
    {
        public override double Height 
        { 
            get => base.Height;
            set => base.Height = base.Width = value;
        }

        public override double Width 
        { 
            get => base.Width;
            set => base.Height = base.Width = value;
        }
        
        public Square(double x, double y, double side): base(x, y, side, side) { }

    }
}
