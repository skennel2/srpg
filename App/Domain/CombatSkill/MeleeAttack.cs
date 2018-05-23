using Srpg.App.Domain.Unit;
using Srpg.App.Util;

namespace Srpg.App.Domain.CombatSkill
{
    public class MeleeAttack : ICombatSkill
    {
        private readonly string name;
        private readonly int minimumDamage;
        private readonly int maximumDamage;
        
        public MeleeAttack(string name, int minimumDamage, int maximumDamage)
        {
            this.name = name;
            this.maximumDamage = maximumDamage;
            this.minimumDamage = minimumDamage;
        }

        public string Name { get; private set; }
        public int MinimumDamage => minimumDamage;
        public int MaximumDamage => maximumDamage;
        
        public virtual void CastSkill(ICanCombat caster, ICreature target)
        {
            int damage = RandomNumberGenerator.NumberBetween(minimumDamage, maximumDamage);
            target.TakeDamageWithDepensiveRate(caster, damage);
        }
    }
}