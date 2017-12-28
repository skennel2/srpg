using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Unit
{
    public interface ICreature: IHaveName, IPhysicalBody, ICanGrowUp
    {
         
    }

    public interface IWarrior : ICreature, ICanCombat
    {

    }

    public class WarriorImpl : IWarrior
    {
        public string Name => throw new System.NotImplementedException();

        public int NowHealthPoint => throw new System.NotImplementedException();

        public int MaxHealthPoint => throw new System.NotImplementedException();

        public bool IsAlive => throw new System.NotImplementedException();

        public double DepensiveRate => throw new System.NotImplementedException();

        public int Level => throw new System.NotImplementedException();

        public int ExperiencePoint => throw new System.NotImplementedException();

        public ICombatSkill CombatSkill => throw new System.NotImplementedException();

        public void AcquireExperiencePoint(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Attack(LivingCreature target)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeCombatSkill(ICombatSkill combatSkill)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseLevel()
        {
            throw new System.NotImplementedException();
        }

        public void RecoveryHealth(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(WarriorBase attacker, int amount)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamageWithDepensiveRate(WarriorBase attacker, int amount)
        {
            throw new System.NotImplementedException();
        }
    }

}