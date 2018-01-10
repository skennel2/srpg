using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Srpg.App.Domain.AI;
using Srpg.App.Domain.Battle;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.State
{
    public class BattleState : IState
    {
        private int nowTurn;
        private readonly Queue<CreatureOnMap> creatures;
        private readonly IGridMap map;
        private readonly int playerTeamId;        

        private bool isRunning = true;
        private RunningState state = RunningState.Prepere;

        public BattleState(int nowTurn, IGridMap map, int playerTeamId)
        {
            this.nowTurn = nowTurn;
            this.map = map;
            this.playerTeamId = playerTeamId;
            creatures = new Queue<CreatureOnMap>();
        }

        public int NowTurn { get => nowTurn;}
        public IGridMap Map => map;
        public int PlayerTeamId => playerTeamId;

        public void JoinToBattle(int teamId, int warriorId, IWarrior warrior, int xLocation, int yLocation)
        {
            if(RunningState.Prepere != state) throw new Exception();

            if (creatures.Count > map.XSize * map.YSize)
            {
                throw new OverflowException();
            }
            if (GetCreatureAt(xLocation, yLocation) != null)
            {
                throw new Exception();
            }

            var creatureOnMap = new CreatureOnMap(warriorId, teamId, map, warrior, xLocation, yLocation);
            creatures.Enqueue(creatureOnMap);
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

        public void Run()
        {
            this.state = RunningState.Running;

            while(nowTurn < 20)
            {
                Render();
                Update();
                Thread.Sleep(5000);
                Console.Clear();
            }        
        }

        public void Update()
        {
            nowTurn++;                    
            CreatureOnMap creature = creatures.Dequeue();
            var commandsList = GetCommandList(creature.CreatureId);

            Console.WriteLine(creature.CreatureId);
            Console.WriteLine(creature.TeamId);
            Console.WriteLine(commandsList.Count);

            ICommand command = null;
            if(creature.TeamId == this.PlayerTeamId)
            {
                foreach (var item in commandsList)
                {
                    Console.WriteLine(item.ToString());
                }

                if(commandsList.Count > 0)
                {
                    int intTemp = Convert.ToInt32(Console.ReadLine());

                    command = commandsList[intTemp];
                }
            }
            else
            {
                command = new MoqCommandSelectAI().SelectCommand(creature, commandsList);
            }
            
            command?.Execute();
            creatures.Enqueue(creature);

        }

        public void OnExit()
        {

        }
    }



    public enum RunningState 
    {
        Prepere, 
        Running,
        End,
    }
}