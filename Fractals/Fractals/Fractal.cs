using System.Drawing;

namespace Fractals
{
    abstract class Fractal
    {
        protected Bitmap Image;
        protected Pen Pen;
        protected Graphics Graph;
        protected int Depth;
        protected int Width;
        protected int Height;
        public Fractal(int depth, int width, int height) { 
            Depth = depth;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Draw selected fractal recursively.
        /// </summary>
        /// <returns> Bitmap of fractal; </returns>
        public abstract Bitmap DrawFractal();
    }
}
