using System;
using System.Collections.Generic;
using System.Linq;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Map
{

    public class GridMap : IGridMap
    {
        private string name;
        private int xSize;
        private int ySize;
        private List<Tile> tileList;    

        public GridMap(string name, int xSize, int ySize, List<Tile> tileList)
        {
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
            this.tileList = tileList;
        }

        public GridMap(string name, int xSize, int ySize)
        {
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
            this.tileList = new List<Tile>();
        }

        public string Name => name;
        public int XSize => xSize;
        public int YSize => ySize;

        public void FillUpWith(Tile defaultTile)
        {
            for(int i = 0; i < xSize * ySize; i++)
            {
                tileList.Add(defaultTile);
            }
        }

        public Tile GetTile(int x, int y)
        {
            return tileList[(y * xSize) + x];
        }

        public void SetTile(Tile tile, int x, int y)
        {
            tileList[(y * xSize) + x] = tile;
        }

        public bool IsAbleToLanding(int x, int y)
        {
            bool result = false;
            try
            {
                result = GetTile(x, y).CanCreatureLanding;
            }
            catch(ArgumentOutOfRangeException)
            {
                result = false;
            }
            
            return result;
        }

        private int TileCount { get => xSize * ySize; }
    }
}