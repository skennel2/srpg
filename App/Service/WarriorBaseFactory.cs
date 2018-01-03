using System.Collections.Generic;
using Srpg.App.ConsoleApp;
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

            warriorRepo = new Dictionary<string, WarriorBase>();

            warriorRepo.Add("test1", new WarriorBase(1, "test", 1, 0, 1500, 1500, 0.05, 
                new TileConsoleShape('☆'),
                multipleAttak));

            warriorRepo.Add("test2", new WarriorBase(2, "test2", 1, 0, 1500, 1500, 0.05, 
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