using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;

namespace Srpg.App.Domain.Unit
{
    public class WarriorBase : LivingCreature
    {
        private ICombatSkill combatSkill;

        public WarriorBase(long id, string name, int nowLevel, 
            int maxHealthPoint, int nowHealthPoint, double depensiveRate, 
            List<TurnLimitedCreatureStatusChangerBase> effects, ICombatSkill combatSkill) : base(id, name, nowLevel, maxHealthPoint, nowHealthPoint, depensiveRate, effects)
        {
            this.combatSkill = combatSkill;
        }

        public virtual void Attack(IEnumerable<LivingCreature> targets)
        {
            foreach (var target in targets)
            {
                Attack(target);
            }
        }

        public virtual void Attack(LivingCreature target)
        {
            combatSkill.CastSkill(this, target);
        }        

        public virtual void ChangeCombatSkill(ICombatSkill combatSkill)
        {
            this.combatSkill = combatSkill;
        }
    }
}