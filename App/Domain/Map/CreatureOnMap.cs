using System;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{
    public class CreatureOnMap : IGridMovable
    {
        private readonly int creatureId;
        private readonly int teamId;
        private readonly ICreature creature;
        private readonly IGridMap map;
        private int cretureXLocation;
        private int cretureYLocation;

        public CreatureOnMap(int creatureId, int teamId, IGridMap map, ICreature creature, int cretureXLocation, int cretureYLocation)
        {
            this.cretureYLocation = cretureYLocation;
            this.cretureXLocation = cretureXLocation;
            this.creature = creature;
            this.map = map;
            this.teamId = teamId;
            this.creatureId = creatureId;
        }

        public int CreatureId => creatureId;
        public int TeamId => teamId;
        public IGridMap Map => map;
        public ICreature Creature => creature;

        public int CretureXLocation { get => cretureXLocation; private set => cretureXLocation = value; }
        public int CretureYLocation { get => cretureYLocation; private set => cretureYLocation = value; }

        public void MoveRight()
        {
            int x = cretureXLocation + 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        public void MoveLeft()
        {
            int x = cretureXLocation - 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        public void MoveDown()
        {
            int x = cretureXLocation;
            int y = cretureYLocation + 1;
            Move(x, y);
        }

        public void MoveUp()
        {
            int x = cretureXLocation;
            int y = cretureYLocation - 1;
            Move(x, y);
        }

        public void Move(CreatureMoveDirection direction)
        {
            if(direction == CreatureMoveDirection.Up)
            {
                MoveUp();
            }
            else if(direction == CreatureMoveDirection.Down)
            {
                MoveDown();
            }
            else if(direction == CreatureMoveDirection.Left)
            {
                MoveLeft();
            }
            else if(direction == CreatureMoveDirection.Right)
            {
                MoveRight();
            }
        }

        private void Move(int x, int y)
        {
            this.CretureXLocation = x;
            this.CretureYLocation = y;
        }
    }
}