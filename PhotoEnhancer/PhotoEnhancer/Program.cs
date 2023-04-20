using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient));
            
            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                    return new Pixel(lightness, lightness, lightness);
                }));

            //mainForm.AddFilter(new TransformFilter(
            //    "Отражение по горизонтали",
            //    size => size,
            //    (point, size) => new Point(size.Width - point.X - 1, point.Y)
            //    ));

            //mainForm.AddFilter(new TransformFilter(
            //    "Поворот на 90° против ч. с.",
            //    size => new Size(size.Height, size.Width),
            //    (point, size) => new Point(size.Width - point.Y - 1, point.X)
            //    ));

            Func<Size, RotationParameters, Size> sizeRotator = (size, parameters) =>
            {
                var angleInRadians = parameters.AngleInDegrees * Math.PI / 180;
                return new Size(
                    (int)(size.Width * Math.Abs(Math.Cos(angleInRadians)) +
                        size.Height * Math.Abs(Math.Sin(angleInRadians))),
                    (int)(size.Width * Math.Abs(Math.Sin(angleInRadians)) +
                        size.Height * Math.Abs(Math.Cos(angleInRadians))));
            };

            Func<Point, Size, RotationParameters, Point?> pointRotator = (point, oldSize, parameters) =>
            {
                var newSize = sizeRotator(oldSize, parameters);
                var angleInRadians = parameters.AngleInDegrees * Math.PI / 180;
                point = new Point(point.X- newSize.Width / 2, point.Y - newSize.Height / 2);
                var x = (int)(point.X * Math.Cos(angleInRadians) - point.Y * Math.Sin(angleInRadians) + oldSize.Width / 2);
                var y = (int)(point.X * Math.Sin(angleInRadians) + point.Y * Math.Cos(angleInRadians) + oldSize.Height / 2);

                if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                    return null;

                return new Point(x, y);
            };

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол",
                sizeRotator,
                pointRotator
                ));

            Application.Run(mainForm);
        }
    }
}
