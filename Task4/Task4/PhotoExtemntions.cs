using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class PhotoExtemntions
    {
        public static List<Pixel> GetNeighbours(this Photo photo, int x, int y) 
        {
            int[] d = { -1, 0, 1 };

            return d
                .SelectMany(dx => d.Select(dy => (X: x + dx, Y: y + dy)))
                .Where(p => p.X >= 0 && p.Y >= 0 && p.X < photo.Width && p.Y < photo.Height)
                .Select(p => photo[p.X, p.Y])
                .ToList();
        }
    }
}
