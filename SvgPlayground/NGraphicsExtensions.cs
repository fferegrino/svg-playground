using NGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgPlayground
{
    public static class NGraphicsExtensions
    {
        public static Rect Resize(this Rect rect, double size)
        {

            return rect.Resize(size, size);
        }
        public static Rect Resize(this Rect rect, double sizeX, double sizeY)
        {
            var originalX = rect.X;
            var originalY = rect.Y;
            var newX = originalX + (-1 * sizeX);
            var newY = originalY + (-1 * sizeY);
            return new Rect(newX, newY, rect.Width + (sizeX * 2), rect.Height + (sizeY * 2));
        }

        public static Rect RectInsideEllipse(this Rect rect)
        {
            var a = rect.Width;
            var b = rect.Height;

            var newWidth = (a * Math.Sqrt(2)) / 2;
            var newHeight = (b * Math.Sqrt(2)) / 2;

            var diffW = newWidth - a;
            var diffH = newHeight - b;

            return rect.Resize(diffW / 2, diffH / 2);
        }

        public static Point GetCenter(this Rect rect)
        {
            var originalX = rect.X;
            var originalY = rect.Y;

            return new Point(originalX + (rect.Width / 2), originalY + (rect.Height / 2));
        }
    }
}
