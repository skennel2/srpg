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

        private CreatureOnMap GetCreature(int creatureId)
        {
            return creatures.FirstOrDefault(c => c.CreatureId == creatureId);
        }

        private CreatureOnMap GetCreatureAt(int x, int y)
        {
            return creatures.FirstOrDefault(c => c.CretureXLocation == x && c.CretureYLocation == y && c.Creature.IsAlive);
        }

        private List<ICommand> GetCommandList(int creatureId)
        {
            List<ICommand> commandList = new List<ICommand>();

            var creature = GetCreature(creatureId);
            if (creature != null) 
            {
                // move
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

                //attack
                var directionList =  new List<CreatureMoveDirection>()
                {
                    CreatureMoveDirection.Down,
                    CreatureMoveDirection.Up,
                    CreatureMoveDirection.Left,
                    CreatureMoveDirection.Right
                };

                foreach(var direction in directionList)
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

                    var target = GetCreatureAt(newXpos, newYpos);
                    if(target != null && creature.Creature is WarriorBase)
                    {
                        commandList.Add(new CretureOnMapAttackCommand
                        (
                            creature.Creature as WarriorBase,
                            new List<ICreature>(){ target.Creature }
                        ));
                    }
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

        public void MoveCreature(int creatureId, CreatureMoveDirection direction)
        {
            IGridMovable moveable = GetCreature(creatureId);

            if (moveable == null)
            {
                return;
            }

            moveable.Move(direction);
        }

        public void Render()
        {
            int xPosition = 0;
            int yPosition = 0;

            ShowStatus();
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

            while(true)
            {
                Render();
                Update();
                Thread.Sleep(700);
                Console.Clear();
            }        

            this.state = RunningState.End;
        }

        public void Reset()
        {
            this.creatures.Clear();
            this.nowTurn = 0;
            this.state = RunningState.Prepere;
        }

        public void Update()
        {     
            CreatureOnMap creature = creatures.Peek();
            var commands = GetCommandList(creature.CreatureId);

            ICommand commandSelected = null;

            if(creature.TeamId == this.PlayerTeamId)
            {
                commandSelected = GetPlayerCommand(commands);
            }
            else
            {
                commandSelected = GetEnemyCommand(creature, commands);
            }
            
            commandSelected?.Execute();

            Console.WriteLine(creature.Creature.NowHealthPoint);
            
            NextTurn();
        }

        private void NextTurn()
        {
            nowTurn++; 

            var peek = creatures.Dequeue();

            if(peek.Creature.IsAlive)
            {
                creatures.Enqueue(peek);
            }
        }

        private void ShowStatus()
        {
            Console.WriteLine(NowTurn + "Turns");

            foreach(var creature in creatures)
            {
                var c = creature.Creature;
                Console.WriteLine(c.Name + " HP :  " + c.NowHealthPoint.ToString() + "/" + c.MaxHealthPoint.ToString());
            }
        }

        private ICommand GetEnemyCommand(CreatureOnMap creature, List<ICommand> commands)
        {
            return new MoqCommandSelectAI().SelectCommand(creature, commands);
        }

        private ICommand GetPlayerCommand(List<ICommand> commands)
        {
            ShowCommandList(commands);

            if(commands.Count > 0)
            {
                return commands[GetInputNumber(commands.Count - 1)];
            }

            return null;
        }

        private void ShowCommandList(List<ICommand> commands)
        {
            foreach (var com in commands)
            {
                Console.WriteLine(com.ToString());
            }
        }

        private int GetInputNumber(int maximumNumber)
        {   
            int result = -1;

            if(!int.TryParse(Console.ReadLine(), out result) || result < 0 || result > maximumNumber)
            {
                result = GetInputNumber(maximumNumber);
            }

            return result;
        }

        public void OnExit()
        {

        }

        public void OnEnter()
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