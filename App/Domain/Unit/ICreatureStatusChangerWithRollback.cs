namespace Srpg.App.Domain.Unit
{
    public interface ICreatureStatusChangerWithRollback : ICreatureStatusChanger
    {
        void RollbackCreature(LivingCreature creature);
    }
}