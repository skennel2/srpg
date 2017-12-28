namespace Srpg.App.Domain.Unit
{
    public class HealthPointRecoveryEffect : ICreatureStatusChanger
    {
        private readonly int amount;
        private readonly CretureStatusChangerType temporaryEffectType;
        private readonly string name;

        public HealthPointRecoveryEffect(string name, int amount)
        {
            this.name = name;
            this.name = name;
            this.temporaryEffectType = CretureStatusChangerType.RecoveryNowValue;
            this.amount = amount;
        }
        public CretureStatusChangerType EffectType { get; }
        public string Name => name;

        public void GiveAEffect(ICreature creature)
        {
            creature.RecoveryHealth(amount);
        }

        public void RollbackCreature(ICreature creature)
        {
            // Do Nothing..
        }
    }
}