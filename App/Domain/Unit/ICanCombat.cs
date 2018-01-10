using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Unit
{
    public interface ICanCombat
    {
        ICombatSkill CombatSkill { get; }
        void Attack(ICreature target);        
        void Attack(IEnumerable<ICreature> targets);
        void ChangeCombatSkill(ICombatSkill combatSkill);        
    }
}