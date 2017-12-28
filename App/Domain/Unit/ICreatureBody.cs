namespace Srpg.App.Domain.Unit
{
    public interface ICreatureBody
    {
        int NowHealthPoint {get;}
        int MaxHealthPoint {get;}
        bool IsAlive {get;}

        double DepensiveRate {get;}

        void RecoveryHealth(int amount);
        void TakeADamage(int amount);
        void TakeADamage(WarriorBase attacker, int amount);
        void TakeADamageWithDepensiveRate(WarriorBase attacker, int amount);
    }
}