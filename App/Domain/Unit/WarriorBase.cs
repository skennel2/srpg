using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.Unit
{
    public class WarriorBase : CreatureBase, IWarrior
    {
        private ICombatSkill combatSkill;

        public WarriorBase(long id, string name, int nowLevel, int experiencePoint,
            int maxHealthPoint, int nowHealthPoint, double depensiveRate, IShapable creatureShape, ICombatSkill combatSkill) 
                : base(id, name, nowLevel, experiencePoint, maxHealthPoint, nowHealthPoint, depensiveRate, creatureShape)
        {
            this.combatSkill = combatSkill;
        }

        public ICombatSkill CombatSkill { get => combatSkill; }

        public virtual void Attack(IEnumerable<ICreature> targets)
        {
            foreach (var target in targets)
            {
                Attack(target);
            }
        }

        public virtual void Attack(ICreature target)
        {
            combatSkill.CastSkill(this, target);
        }

        public virtual void ChangeCombatSkill(ICombatSkill combatSkill)
        {
            this.combatSkill = combatSkill;
        }
    }
}