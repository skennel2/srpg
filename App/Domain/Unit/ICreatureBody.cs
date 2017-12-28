namespace Srpg.App.Domain.Unit
{
    public interface ICreatureBody
    {
        int NowHealthPoint {get;}
        int MaxHealthPoint {get;}
        bool IsAlive {get;}
        void RecoveryHealth(int amount);
        void TakeADamage(LivingCreature attacker, int amount);
        void TakeADamageWithDepensiveRate(LivingCreature attacker, int amount);
    }
}