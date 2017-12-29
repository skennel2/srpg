using System;
using System.Collections.Generic;
using System.Linq;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{

    public class GridMap : IGridMap
    {
        private readonly string name;
        private readonly int xSize;
        private readonly int ySize;
        private Tile[,] tileArray;
        private readonly Dictionary<int, CreatureOnMap> creatures;

        public GridMap(string name, int xSize, int ySize)
        {
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
            tileArray = new Tile[xSize, ySize];
            creatures = new Dictionary<int, CreatureOnMap>();
        }

        public string Name => name;
        public int XSize => xSize;
        public int YSize => ySize;
        public Tile[,] TileArray { get => tileArray; private set => tileArray = value; }        

        public void PutCreatureOn(ICreature creature, int teamId, int xLocation, int yLocation)
        {
            var creatureOnMap = new CreatureOnMap(creatures.Count + 1, teamId, this, creature, xLocation, yLocation);
            
            this.creatures.Add(creatureOnMap.CreatureId, creatureOnMap);            
        }

        public bool CanCreatureMove(int creatureId, int x, int y)
        {
            return creatures.ContainsKey(creatureId) && !IsSizeOver(x, y) && GetLivingCreatureAt(x, y) == null;
        }

        public CreatureOnMap GetLivingCreatureAt(int x, int y)
        {
            return creatures.Values.FirstOrDefault(c=> c.CretureXLocation == x && c.CretureYLocation == y);                    
        }

        public void FillUpWith(Tile defaultTile)
        {
            if(defaultTile == null) throw new ArgumentNullException("defaultTile");

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
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
        }

        public void VetifySizeOver(int x, int y)
        {
            if(x >= xSize)
            {                
                string exceptionMessage = "x size : " + xSize.ToString() + "but " + x.ToString();
                throw new ArgumentOutOfRangeException("x", exceptionMessage);
            }
            if(y >= ySize)
            {                
                string exceptionMessage = " y size : " + ySize.ToString()  + "but " + y.ToString();
                throw new ArgumentOutOfRangeException("y", exceptionMessage);
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

        public bool IsAbleToLanding(int x, int y)
        {
            return GetTile(x, y).CanCreatureLanding;
        }

        public Tile GetTile(int x, int y)
        {
            return tileArray[x, y];
        }
    }
}