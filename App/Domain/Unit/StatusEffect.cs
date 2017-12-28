namespace Srpg.App.Domain.Unit
{
    public class StatusEffect : TurnLimitedCreatureStatusChangerBase
    {
        public StatusEffect(int retentionTurn, ICreatureStatusChanger effect) : base(retentionTurn, effect)
        {
        }

        public override void GiveAEffect(LivingCreature creature)
        {
            Effect.GiveAEffect(creature);
            RetentionTurn -= 1;
        }

        public override void RollbackCreature(LivingCreature creature)
        {
        
        }
    }
}