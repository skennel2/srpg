namespace Srpg.App.Domain.Unit
{
    public interface ICreatureStatusChangerWithRollback : ICreatureStatusChanger
    {
        void RollbackCreature(ICreature creature);
    }
}