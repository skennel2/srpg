using Srpg.App.Domain.Common;
using Srpg.App.Util;

namespace Srpg.App.Domain.Unit.Effect
{
    public class PoisonDamageEffect : ICreatureStatusChanger
    {
        private readonly int minimumDamage;
        private readonly int maximumDamage;
        private readonly string name;

        public PoisonDamageEffect(string name, int minimumDamage, int maximumDamage)
        {
            this.name = name;
            this.maximumDamage = maximumDamage;
            this.minimumDamage = minimumDamage;
        }

        public CretureStatusChangerType EffectType => CretureStatusChangerType.DepressNowValue;
        public int MinimumDamage => minimumDamage;
        public int MaximumDamage => maximumDamage;
        public string Name => name;

        public void GiveAEffect(ICreature creature)
        {
            int damage = RandomNumberGenerator.NumberBetween(minimumDamage, maximumDamage);
            creature.TakeDamage(null, damage);
        }

        public void RollbackCreature(ICreature creature)
        {

        }
    }
}