using System;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{
    public class LivingCreatureOnMap : IGridMovable
    {
        private readonly int creatureId;
        private readonly int teamId;
        private readonly LivingCreature creature;
        private readonly GridMap map;
        private int cretureXLocation;
        private int cretureYLocation;
        
        public LivingCreatureOnMap(int creatureId, int teamId, GridMap map, LivingCreature creature, int cretureXLocation, int cretureYLocation)
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
        public GridMap Map => map;
        public LivingCreature Creature => creature;

        public int CretureXLocation { get => cretureXLocation; private set => cretureXLocation = value; }
        public int CretureYLocation { get => cretureYLocation; private set => cretureYLocation = value; }

        public void MoveRight()
        {
            int x = cretureXLocation;
            int y = cretureYLocation + 1;
            Move(x, y);
        }

        public void MoveLeft()
        {
            int x = cretureXLocation;
            int y = cretureYLocation - 1;
            Move(x, y);
        }

        public void MoveDown()
        {
            int x = cretureXLocation + 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        public void MoveUp()
        {
            int x = cretureXLocation - 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        private void Move(int x, int y)
        {
            if (map.CanCreatureMove(creatureId, x, y))
            {
                this.CretureXLocation = x;
                this.CretureYLocation = y;
            }
        }
    }
}