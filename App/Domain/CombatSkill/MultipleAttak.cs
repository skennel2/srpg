using System;
using Srpg.App.Domain.Unit;
using Srpg.App.Util;

namespace Srpg.App.Domain.CombatSkill
{
    public class MultipleAttak : MeleeAttack
    {
        private readonly int attackTimes;
        private readonly double damageRate;

        public MultipleAttak(string name, int minimumDamage, int maximumDamage, int attackTimes, double damageRate) : base(name, minimumDamage, maximumDamage)
        {
            this.damageRate = damageRate;
            this.attackTimes = attackTimes;
        }

        public int AttackTimes => attackTimes;
        public double DamageRate => damageRate;

        override public void CastSkill(ICanCombat caster, ICreature target)
        {
            for (int i = 0; i < attackTimes; i++)
            {
                int damage = RandomNumberGenerator.NumberBetween(MinimumDamage, MaximumDamage);
                damage = (int)Math.Round(damage - (damage * damageRate));

                target.TakeDamageWithDepensiveRate(caster, damage);
            }
        }
    }
}