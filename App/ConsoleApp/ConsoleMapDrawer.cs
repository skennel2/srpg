using System;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.ConsoleApp
{
    public class ConsoleMapDrawer : IDrawable
    {
        private readonly IGridMap map;

        public ConsoleMapDrawer(IGridMap map)
        {
            this.map = map;
        }

        public void ShowName()
        {
            Console.WriteLine("*** " + map.Name + "***");
        
        }

        public void Draw()
        {
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < map.XSize * map.YSize; i++)
            {
                map.GetTile(xPosition, yPosition).TileShape.Draw();

                xPosition++;

                if(xPosition >= map.XSize)
                {
                    xPosition = 0;
                    yPosition++;
                    Console.WriteLine();
                }
            }
        }
    }
}
