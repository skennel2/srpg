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

        override public void CastSkill(ICanCombat caster, ICreature targets)
        {
            int damage = RandomNumberGenerator.NumberBetween(MinimumDamage, MaximumDamage);
            targets.TakeDamageWithDepensiveRate(caster, damage);
            
            if(caster is IPhysicalBody)
            {
                (caster as IPhysicalBody).RecoveryHealth((int)Math.Round(damage * vomitedRate));
            }
        }
    }
}