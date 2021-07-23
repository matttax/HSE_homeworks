using System.Drawing;

namespace Fractals
{
    class Triangle : Fractal
    {
        public Triangle(int depth, int width, int height) : base(depth, width, height) { }

        public override Bitmap DrawFractal()
        {
            Image = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(Image);
            PointF topPoint = new PointF(Width / 2f, 0);
            PointF leftPoint = new PointF(0, Height);
            PointF rightPoint = new PointF(Width, Height);
            DrawTriangle(Depth, topPoint, leftPoint, rightPoint);
            return Image;
        }
        private void DrawTriangle(int depth, PointF top, PointF left, PointF right)
        {
            if (depth == 0)
            {
                PointF[] points = new PointF[3] { top, right, left };
                Graph.FillPolygon(Brushes.Blue, points);
            }
            else
            {
                PointF leftMid = MidPoint(top, left);
                PointF rightMid = MidPoint(top, right);
                PointF topMid = MidPoint(left, right);
                DrawTriangle(depth - 1, top, leftMid, rightMid);
                DrawTriangle(depth - 1, leftMid, left, topMid);
                DrawTriangle(depth - 1, rightMid, topMid, right);
            }
        }
        private PointF MidPoint(PointF p1, PointF p2) => new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
    }
}
