using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Unit
{
    public interface ICreatureStatusChanger : IHaveName
    {
        CretureStatusChangerType EffectType { get; }
        void GiveAEffect(ICreature creature);
    }
}