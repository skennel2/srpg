using System.Collections.Generic;
using System.Linq;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{
    public class MapImpl
    {
        private readonly string name;
        private readonly int ySize;
        private readonly int xSize;
        private Tile[,] tileArray;
        private readonly Dictionary<int, MapOnALivingCreature> creatures;

        public MapImpl(string name, int xSize, int ySize)
        {
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;

            tileArray = new Tile[xSize, ySize];
        }

        public Tile[,] TileArray { get => tileArray; private set => tileArray = value; }
        public string Name => name;

        public void PutCreatureOn(LivingCreature creature, int teamId, int xLocation, int yLocation)
        {
            var creatureOnMap = new MapOnALivingCreature(creatures.Count + 1, teamId, this, creature, xLocation, yLocation);
            this.creatures.Add(creatureOnMap.CreatureId, creatureOnMap);            
        }

        public bool CanCreatureMove(int creatureId, int x, int y)
        {
            return creatures.ContainsKey(creatureId) && !IsSizeOver(x, y) && GetLivingCreature(x, y) == null;
        }

        public MapOnALivingCreature GetLivingCreature(int x, int y)
        {
            return creatures.Values.FirstOrDefault(c=> c.CretureXLocation == x && c.CretureYLocation == y);                    
        }

        public void FillUpWith(Tile defaultTile)
        {
            if(defaultTile == null) throw new System.ArgumentNullException("defaultTile");

            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    tileArray[i, j] = defaultTile;
                }
            }
        }

        public void SetTile(Tile tile, int x, int y)
        {            
            try
            {
                VetifySizeOver(x, y);
                tileArray[x, y] = tile;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
        }

        public void VetifySizeOver(int x, int y)
        {
            if(x >= xSize)
            {                
                string exceptionMessage = "x size : " + xSize.ToString() + "but " + x.ToString();
                throw new System.ArgumentOutOfRangeException("x", exceptionMessage);
            }
            if(y >= ySize)
            {                
                string exceptionMessage = " y size : " + ySize.ToString()  + "but " + y.ToString();
                throw new System.ArgumentOutOfRangeException("y", exceptionMessage);
            }
        }  

        public bool IsSizeOver(int x, int y)
        {
            if(x >= xSize || y >= ySize)
            {                
               return true;
            }
            
            return false;
        }                
    }
}