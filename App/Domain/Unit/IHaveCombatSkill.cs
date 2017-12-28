using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Unit
{
    public interface IHaveCombatSkill
    {
        ICombatSkill CombatSkill { get; }
        void Attack(LivingCreature target);
        void ChangeCombatSkill(ICombatSkill combatSkill);
    }
}