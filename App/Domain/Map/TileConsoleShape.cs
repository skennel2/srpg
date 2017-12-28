using System;

namespace Srpg.App.Domain.Map
{
    public class TileConsoleShape : IDrawable
    {
        private readonly char shape;

        public TileConsoleShape(char shape)
        {
            this.shape = shape;
        }

        public char Shape => shape;

        public void Draw()
        {
            Console.Write(Shape);
        }
    }
}