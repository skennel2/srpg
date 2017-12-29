using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Map
{
    public interface IGridMap : IHaveName, IGrid
    {
        Tile GetTile(int x, int y);
        void SetTile(Tile tile, int x, int y);
        void FillUpWith(Tile defaultTile);
        bool IsAbleToLanding(int x, int y);
    }
}