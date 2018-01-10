using System;
using Srpg.App.Domain.Common;

namespace Srpg.App.ConsoleApp
{
    /// <summary>
    /// 콘솔에 Tile에 대한 표현
    /// </summary>
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