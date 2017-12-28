using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Unit
{
    public interface ICanCombat
    {
        ICombatSkill CombatSkill { get; }
        void Attack(ICreature target);
        void ChangeCombatSkill(ICombatSkill combatSkill);
    }
}