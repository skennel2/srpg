using System;
using Srpg.App.Domain.Unit;
using Srpg.App.Util;

namespace Srpg.App.Domain.CombatSkill
{
    public class VomitedAttack : MeleeAttack
    {
        private readonly double vomitedRate;

        public VomitedAttack(string name, int minimumDamage, int maximumDamage, double vomitedRate) : base(name, minimumDamage, maximumDamage)
        {
            this.vomitedRate = vomitedRate;
        }

        override public void CastSkill(WarriorBase caster, LivingCreature targets)
        {
            int damage = RandomNumberGenerator.NumberBetween(MinimumDamage, MaximumDamage);
            damage = (int)Math.Round(damage - (damage * targets.DepensiveRate));
            targets.TakeADamage(caster, damage);

            caster.RecoveryHealth((int)Math.Round(damage * vomitedRate));
        }
    }
}