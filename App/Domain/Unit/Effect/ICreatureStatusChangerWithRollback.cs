namespace Srpg.App.Domain.Unit.Effect
{
    public interface ICreatureStatusChangerWithRollback : ICreatureStatusChanger
    {
        void RollbackCreature(ICreature creature);
    }
}