using Srpg.App.Domain.Unit.Effect;

namespace Srpg.App.Domain.Unit
{
    public interface IEffectReceptible
    {
        void AddTemporaryEffect(ICanCombat sender, TurnLimitedCreatureStatusChangerBase effect);
        void RemoveTemporaryEffect(TurnLimitedCreatureStatusChangerBase effect);
    }
}