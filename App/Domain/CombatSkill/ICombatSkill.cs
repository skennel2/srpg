using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.CombatSkill
{
    public interface ICombatSkill : IHaveName
    {
        void CastSkill(WarriorBase caster, LivingCreature target);
    }
}