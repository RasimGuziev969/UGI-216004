using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public static class Drawer
    {
        public static void DrawShapes(List<IDrawable> shapes)
        {
            foreach (IDrawable shape in shapes)
                shape.Draw();
        }
    }
}
