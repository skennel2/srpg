namespace Srpg.App.Domain.Unit
{
    public interface ICreatureBody
    {
        int NowHealthPoint {get;}
        int MaxHealthPoint {get;}
        bool IsAlive {get;}

        double DepensiveRate {get;}

        void RecoveryHealth(int amount);
        void TakeDamage(int amount);
        void TakeDamage(WarriorBase attacker, int amount);
        void TakeDamageWithDepensiveRate(WarriorBase attacker, int amount);
    }
}