using System;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{
    public class MapOnALivingObject
    {
        private readonly int creatureId;
        private readonly int teamId;        
        private readonly LivingCreature creature;        
        private readonly MapImpl map;
        private int cretureXLocation;
        private int cretureYLocation;

        public MapOnALivingObject(int creatureId, int teamId, MapImpl map, LivingCreature creature, int cretureXLocation, int cretureYLocation)
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
        public MapImpl Map => map;
        public LivingCreature Creature => creature;

        public int CretureXLocation { get => cretureXLocation; private set => cretureXLocation = value; }
        public int CretureYLocation { get => cretureYLocation; private set => cretureYLocation = value; }

        public void MoveUp()
        {
            int x = cretureXLocation;
            int y = cretureYLocation + 1;
            Move(x, y);
        }

        public void MoveDown()
        {
            int x = cretureXLocation;
            int y = cretureYLocation - 1;
            Move(x, y);
        }

        public void MoveLeft()
        {
            int x = cretureXLocation + 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        public void MoveRight()
        {
            int x = cretureXLocation - 1;
            int y = cretureYLocation;
            Move(x, y);
        }

        public void Move(int x, int y)
        {
            if (map.CanCreatureMove(creatureId, x, y))
            {            
                this.CretureXLocation = x;
                this.CretureYLocation = y;
            }
        }
    }
}