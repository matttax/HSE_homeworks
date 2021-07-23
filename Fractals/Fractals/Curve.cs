using System;
using System.Drawing;

namespace Fractals
{
    class Curve : Fractal
    {
        public Curve(int depth, int width, int height) : base(depth, width, height) { }

        public override Bitmap DrawFractal()
        {
            Image = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(Image);
            Pen = new Pen(Color.Black);
            Point start = new Point(0, Height / 2), finish = new Point(Width, Height / 2);
            DrawCurve(Depth, start, finish);
            return Image;
        }
        private void DrawCurve(int depth, Point start, Point finish)
        {
            if (depth == 0)
                Graph.DrawLine(Pen, start.X, Height - start.Y, finish.X, Width - finish.Y);
            else
            {
                Point firstLine = new Point((2 * start.X + finish.X) / 3, (2 * start.Y + finish.Y) / 3);
                Point secondLine = new Point((start.X + 2 * finish.X) / 3, (start.Y + 2 * finish.Y) / 3);
                Point top = new Point((int)((start.X + finish.X) / 2 + (start.Y - finish.Y) / (Math.Sqrt(3) * 2)), 
                    (int)((start.Y + finish.Y) / 2 + (finish.X - start.X) / (Math.Sqrt(3) * 2)));
                DrawCurve(depth - 1, start, firstLine);
                DrawCurve(depth - 1, firstLine, top);
                DrawCurve(depth - 1, top, secondLine);
                DrawCurve(depth - 1, secondLine, finish);
            }
        }
    }
}
