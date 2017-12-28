using System.Collections.Generic;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.CombatSkill
{
    public interface ICombatSkill
    {
        string Name {get;}
        void CastSkill(WarriorBase caster, LivingCreature target);
    }
}