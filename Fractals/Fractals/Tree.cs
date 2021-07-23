using System;
using System.Drawing;

namespace Fractals
{
    class Tree : Fractal
    {
        private int Angle;
        public Tree(int depth, int width, int height, int angle) : base(depth, width, height)
        {
            Angle = angle;
        }

        public override Bitmap DrawFractal()
        {
            Image = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(Image);
            Pen = new Pen(Color.Black);
            
            double limitLength = 170;
            for (int i = 0; i < Depth; i++)
                limitLength /= 1.5;
            DrawTree(limitLength, Width / 2, 0, 170, 0);
            return Image;
        }

        public void DrawTree(double limitLength, int x, int y, double len, int angle)
        {
            int newX = (int)(x + len * Math.Sin(angle * 2 * Math.PI / 360));
            int newY = (int)(y + len * Math.Cos(angle * 2 * Math.PI / 360));
            Graph.DrawLine(Pen, x, Height - y, newX, Width - newY);
            if (len > limitLength)
            {
                DrawTree(limitLength, newX, newY, len / 1.5, angle + Angle);
                DrawTree(limitLength, newX, newY, len / 1.5, angle - Angle);
            }
        }
    }
}
