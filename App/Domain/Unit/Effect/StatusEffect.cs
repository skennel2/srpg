namespace Srpg.App.Domain.Unit.Effect
{
    public class StatusEffect : TurnLimitedCreatureStatusChangerBase
    {
        public StatusEffect(int retentionTurn, ICreatureStatusChanger effect) : base(retentionTurn, effect)
        {
        }

        public override void GiveAEffect(ICreature creature)
        {
            Effect.GiveAEffect(creature);
            RetentionTurn -= 1;
        }

        public override void RollbackCreature(ICreature creature)
        {
        
        }
    }
}