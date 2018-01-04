using System;
using Srpg.App.ConsoleApp;
using Srpg.App.Domain.Map;
using Srpg.App.Service;

namespace Srpg.App.Test
{
    public class Test1
    {
        public void OneOnOneBattleTest()
        {
            WarriorBaseFactoryTest factory = new WarriorBaseFactoryTest();
            var w1 = factory.GetByName("test1");
            var w2 = factory.GetByName("test2");

            var oneOnOne = new OneOnOneConsoleBattle(w1, w2);
            oneOnOne.StartBattle();
        }      
    }
}