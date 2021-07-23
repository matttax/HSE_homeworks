using System.Drawing;

namespace Fractals
{
    class Carpet : Fractal
    {
        public Carpet(int depth, int width, int height) : base(depth, width, height) { }
        public override Bitmap DrawFractal()
        {
            Image = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(Image);
            RectangleF carpet = new RectangleF(0, 0, Width, Height);
            DrawCarpet((int)Depth, carpet);
            return Image;
        }
        private void DrawCarpet(int depth, RectangleF carpet)
        {
            if (depth == 0)
                Graph.FillRectangle(Brushes.Blue, carpet);
            else
            {
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;
                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                DrawCarpet(depth - 1, new RectangleF(x1, y1, width, height));
                DrawCarpet(depth - 1, new RectangleF(x2, y1, width, height));
                DrawCarpet(depth - 1, new RectangleF(x3, y1, width, height));
                DrawCarpet(depth - 1, new RectangleF(x1, y2, width, height));
                DrawCarpet(depth - 1, new RectangleF(x3, y2, width, height));
                DrawCarpet(depth - 1, new RectangleF(x1, y3, width, height));
                DrawCarpet(depth - 1, new RectangleF(x2, y3, width, height));
                DrawCarpet(depth - 1, new RectangleF(x3, y3, width, height));
            }
        }
    }
}
