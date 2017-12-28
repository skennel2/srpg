using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Service
{
    public class WarriorBaseFactoryTest : IWarriorBaseFactory
    {
        Dictionary<string, WarriorBase> warriorRepo;
        
        public WarriorBaseFactoryTest()
        {
            var meleeAttack = new MeleeAttack("Melee", 50, 60);
            var multipleAttak = new MultipleAttak("4/25 MulpipleAttack", 100, 120, 4, 0.25);
            var vomitedAttack = new VomitedAttack("Vomited Attack", 75, 85, 0.25);
            var effectAttack = new MeleeAttackWithSingleDebuf("poison", 50,50, 
                new StatusEffect(15, new PoisonDamageEffect("poison", 5, 15)));


            warriorRepo = new Dictionary<string, WarriorBase>();

            warriorRepo.Add("test1", new WarriorBase(1, "test", 1, 1500, 1500, 0.05, 
                new List<TurnLimitedCreatureStatusChangerBase>(), 
                new TileConsoleShape('☆'),
                effectAttack));

            warriorRepo.Add("test2", new WarriorBase(2, "test2", 1, 1500, 1500, 0.05, 
                new List<TurnLimitedCreatureStatusChangerBase>(),
                new TileConsoleShape('☆'),
                vomitedAttack));      
        } 

        public WarriorBase GetByName(string name)
        {
            if(warriorRepo.ContainsKey(name))
            {
                return warriorRepo[name];
            }

            return null;
        }
    }
}