using Srpg.App.Domain.Unit;
using Srpg.App.Domain.Unit.Effect;

namespace Srpg.App.Domain.CombatSkill
{
    public class MeleeAttackWithSingleDebuf : MeleeAttack
    {
        private readonly TurnLimitedCreatureStatusChangerBase debuf ;

        public MeleeAttackWithSingleDebuf(string name, int minimumDamage, int maximumDamage, TurnLimitedCreatureStatusChangerBase debuf) : base(name, minimumDamage, maximumDamage)
        {
            this.debuf = debuf;
        }

        override public void CastSkill(ICanCombat caster, ICreature target)
        {
            base.CastSkill(caster, target);
            target.AddTemporaryEffect(caster, debuf);
        }
    }

}