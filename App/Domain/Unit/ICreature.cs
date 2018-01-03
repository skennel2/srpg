using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Unit
{
    public interface ICreature: IEntity<long>, IHaveName, IPhysicalBody, ICanGrowUp, IShapable
    {
         
    }
}