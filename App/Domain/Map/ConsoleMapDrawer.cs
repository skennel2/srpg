using System;

namespace Srpg.App.Domain.Map
{
    public class ConsoleMapDrawer : IDrawable
    {
        private readonly MapImpl map;

        public ConsoleMapDrawer(MapImpl map)
        {
            this.map = map;
        }

        public void ShowName()
        {
            Console.WriteLine("*** " + map.Name + "***");
        
        }

        public void Draw()
        {
            for (int x = 0; x < map.TileArray.GetLength(0); x++)
            {
                for (int y = 0; y < map.TileArray.GetLength(1); y++)
                {
                    map.TileArray[x, y].Drawable.Draw();
                }

                Console.WriteLine();
            }
        }
    }
}
