using Srpg.App.ConsoleApp;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.MapGenerator
{
    public class MockTileSetMapper : ITileSetMapper
    {
        public Tile GetTile(int key)
        {
            if(key == 0)
                return new Tile("DT", true, new TileConsoleShape('□'));
            if(key == 1)
                return new Tile("DT", false, new TileConsoleShape('@'));
            if(key == 2)
                return new Tile("DT", true, new TileConsoleShape('□'));
                        
            return new Tile("DT", true, new TileConsoleShape('□'));                                
        }
    }
}
