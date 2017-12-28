namespace Srpg.App.Domain.Unit
{
    public interface ICreatureStatusChanger
    {
        string Name {get;}
        CretureStatusChangerType EffectType { get; }
        void GiveAEffect(LivingCreature creature);
        void RollbackCreature(LivingCreature creature);
    }
}