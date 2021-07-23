using System.Drawing;

namespace Fractals
{
    class Set : Fractal
    {
        double Gap;
        public Set(int depth, int width, int height, double gap) : base(depth, width, height) { Gap = gap; }
        public override Bitmap DrawFractal()
        {
            Image = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(Image);
            Pen = new Pen(Color.Black);
            Point start = new Point(0, Height / 2);
            Point finish = new Point(Width, Height / 2);
            for (int i = 0; i < Depth; i++)
                DrawSet(i, start, finish, Gap);
            return Image;
        }
        private void DrawSet(int depth, Point start, Point finish, double gap)
        {
            if (depth == 0)
                Graph.DrawLine(Pen, start.X, Height - start.Y, finish.X, Width - finish.Y);
            else
            {
                Point firstPart = new Point((int)(start.X + (finish.X - start.X) * Gap), start.Y + 20);
                Point secondPart = new Point((int)(start.X + (finish.X - start.X) * (1-Gap)), start.Y + 20);
                start = new Point(start.X, start.Y + 20);
                finish = new Point(finish.X, finish.Y + 20);
                DrawSet(depth - 1, start, firstPart, gap);
                DrawSet(depth - 1, secondPart, finish, gap);
            }
        }
    }
}
