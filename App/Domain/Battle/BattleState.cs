using System;
using System.Collections.Generic;
using System.Linq;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Battle
{
    public class BattleState : IState
    {
        private int nowTurn;
        private readonly List<CreatureOnMap> creatures;
        private readonly IGridMap map;
        private readonly int playerTeamId;

        public BattleState(int nowTurn, IGridMap map, int playerTeamId)
        {
            this.nowTurn = nowTurn;
            this.map = map;
            this.playerTeamId = playerTeamId;
            creatures = new List<CreatureOnMap>();
        }

        public int NowTurn { get => nowTurn; }
        public IGridMap Map => map;
        public int PlayerTeamId => playerTeamId;

        public void JoinToBattle(int teamId, IWarrior warrior, int xLocation, int yLocation)
        {
            if (creatures.Count > map.XSize * map.YSize)
            {
                throw new OverflowException();
            }
            if (GetCreatureAt(xLocation, yLocation) != null)
            {
                throw new Exception();
            }

            var creatureOnMap = new CreatureOnMap(creatures.Count + 1, teamId, map, warrior, xLocation, yLocation);
            creatures.Add(creatureOnMap);
        }

        public CreatureOnMap GetCreature(int creatureId)
        {
            return creatures.FirstOrDefault(c => c.CreatureId == creatureId);
        }

        public CreatureOnMap GetCreatureAt(int x, int y)
        {
            return creatures.FirstOrDefault(c => c.CretureXLocation == x && c.CretureYLocation == y);
        }

        public List<ICommand> GetCommandList(int creatureId)
        {
            List<ICommand> commandList = new List<ICommand>();

            var creature = GetCreature(creatureId);
            if (creature != null)
            {
                if (IsCreatureCanMove(creature, CreatureMoveDirection.Right))
                {
                    commandList.Add(new CretureOnMapMoveCommand(creature, CreatureMoveDirection.Right));
                }
                if (IsCreatureCanMove(creature, CreatureMoveDirection.Left))
                {
                    commandList.Add(new CretureOnMapMoveCommand(creature, CreatureMoveDirection.Left));
                }
                if (IsCreatureCanMove(creature, CreatureMoveDirection.Down))
                {
                    commandList.Add(new CretureOnMapMoveCommand(creature, CreatureMoveDirection.Down));
                }
                if (IsCreatureCanMove(creature, CreatureMoveDirection.Up))
                {
                    commandList.Add(new CretureOnMapMoveCommand(creature, CreatureMoveDirection.Up));
                }
            }

            return commandList;
        }

        private bool IsCreatureCanMove(CreatureOnMap creature, CreatureMoveDirection direction)
        {
            int newXpos = creature.CretureXLocation;
            int newYpos = creature.CretureYLocation;

            if (direction == CreatureMoveDirection.Up)
            {
                newYpos -= 1;
            }
            else if (direction == CreatureMoveDirection.Down)
            {
                newYpos += 1;
            }
            else if (direction == CreatureMoveDirection.Left)
            {
                newXpos -= 1;
            }
            else if (direction == CreatureMoveDirection.Right)
            {
                newXpos += 1;
            }

            if (GetCreatureAt(newXpos, newYpos) != null)
            {
                return false;
            }
            if (!map.IsAbleToLanding(newXpos, newYpos))
            {
                return false;
            }

            return true;
        }

        public void MoveCreature(int creatureId, CreatureMoveDirection direction)
        {
            IGridMovable moveable = GetCreature(creatureId);

            if (moveable == null)
            {
                return;
            }

            moveable.Move(direction);
        }

        public void OnEnter()
        {

        }

        public void Render()
        {
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < map.XSize * map.YSize; i++)
            {
                var creature = GetCreatureAt(xPosition, yPosition);
                if (creature == null)
                {
                    map.GetTile(xPosition, yPosition).TileShape.Draw();
                }
                else
                {
                    creature.Creature.Draw();
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

        }

        public void OnExit()
        {

        }
    }

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