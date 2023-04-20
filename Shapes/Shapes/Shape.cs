using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape : IDrawable, IMeasureable
    {
        public abstract double Area { get; }

        public abstract double Perimetr {get; }

        public abstract void Draw();
    }
}
