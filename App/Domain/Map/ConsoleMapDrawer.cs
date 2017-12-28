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
            for (int i = 0; i < map.TileArray.GetLength(0); i++)
            {
                for (int j = 0; j < map.TileArray.GetLength(1); j++)
                {
                    map.TileArray[i, j].Drawable.Draw();
                }

                Console.WriteLine();
            }
        }
    }
}