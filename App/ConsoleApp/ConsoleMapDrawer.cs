using System;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.ConsoleApp
{
    public class ConsoleMapDrawer : IDrawable
    {
        private readonly GridMap map;

        public ConsoleMapDrawer(GridMap map)
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
                    var creature = map.GetLivingCreatureAt(x, y);
                    
                    if(creature == null)
                    {
                        map.TileArray[x, y].TileShape.Draw();
                    }
                    else
                    {
                        creature.Creature.Draw();                    
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
