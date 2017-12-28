using System;
using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Map
{
    public class TileConsoleShape : IShapable
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