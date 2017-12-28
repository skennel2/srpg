using Srpg.App.Domain.Common;
using Srpg.App.Domain;

namespace Srpg.App.Domain.Map
{
    public class Tile : IHaveName
    {
        private readonly string name;
        private readonly bool canCreatureLanding;
        private readonly IDrawable tileShape;

        public Tile(string name, bool canCreatureLanding, IDrawable tileShape)
        {
            this.tileShape = tileShape;
            this.canCreatureLanding = canCreatureLanding;
            this.name = name;
        }

        public string Name => name;
        public bool CanCreatureLanding => canCreatureLanding;
        public IDrawable TileShape => tileShape;
    }
}