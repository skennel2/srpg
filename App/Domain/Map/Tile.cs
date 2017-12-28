using Srpg.App.Domain;

namespace Srpg.App.Domain.Map
{
    public class Tile
    {
        private readonly string name;
        private readonly bool canCreatureLanding;
        private readonly IDrawable drawable;

        public Tile(string name, bool canCreatureLanding, IDrawable drawable)
        {
            this.drawable = drawable;
            this.canCreatureLanding = canCreatureLanding;
            this.name = name;
        }

        public string Name => name;
        public bool CanCreatureLanding => canCreatureLanding;
        public IDrawable Drawable => drawable;
    }
}