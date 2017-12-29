namespace Srpg.App.Domain.Unit
{
    public interface IPhysicalBody
    {
        int NowHealthPoint {get;}
        int MaxHealthPoint {get;}
        bool IsAlive {get;}
        double DepensiveRate {get;}
        void RecoveryHealth(int amount);
        void TakeDamage(int amount);
        void TakeDamage(ICanCombat attacker, int amount);
        void TakeDamageWithDepensiveRate(ICanCombat attacker, int amount);
    }
}