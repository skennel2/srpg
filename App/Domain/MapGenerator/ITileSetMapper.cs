using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.MapGenerator
{
    public interface ITileSetMapper
    {
        Tile GetTile(int key);
    }
}