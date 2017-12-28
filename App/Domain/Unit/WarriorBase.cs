using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Unit
{
    public class WarriorBase : LivingCreature, IHaveCombatSkill
    {
        private ICombatSkill combatSkill;

        public WarriorBase(long id, string name, int nowLevel, int experiencePoint,
            int maxHealthPoint, int nowHealthPoint, double depensiveRate, 
            List<TurnLimitedCreatureStatusChangerBase> effects, IShapable creatureShape, ICombatSkill combatSkill) 
                : base(id, name, nowLevel, experiencePoint, maxHealthPoint, nowHealthPoint, depensiveRate, effects, creatureShape)
        {
            this.combatSkill = combatSkill;
        }

        public ICombatSkill CombatSkill { get => combatSkill; }

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