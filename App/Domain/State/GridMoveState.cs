using System;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.State
{
    public class GridMoveState : IState
    {
        private readonly IGridMap map;
        private readonly CreatureOnMap creature;

        public GridMoveState(IGridMap map, CreatureOnMap creature)
        {
            this.map = map;
            this.creature = creature;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void Render()
        {
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < map.XSize * map.YSize; i++)
            {
                if (creature.CretureXLocation != xPosition || creature.CretureYLocation != yPosition)
                {
                    map.GetTile(xPosition, yPosition).TileShape.Draw();
                }
                else
                {
                    Console.Write("#");
                }

                xPosition++;

                if (xPosition >= map.XSize)
                {
                    xPosition = 0;
                    yPosition++;
                    Console.WriteLine();
                }
            }
        }

        public void Update()
        {
            ConsoleKeyInfo keyInfo;
            while (ConsoleKey.Escape != keyInfo.Key)
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.W)
                {
                    creature.MoveUp();
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    creature.MoveDown();
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    creature.MoveLeft();
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    creature.MoveRight();
                }

                Console.Clear();
                Render();                
            }
        }
    }
}