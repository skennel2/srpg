using Srpg.App.ConsoleApp;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Test
{
    public class TestResolutionRoot : ICompositionRoot
    {
        private Test1 test1;

        public void SetUp()
        {
            test1 = new Test1();
        }

        public void Run()
        {
            Test1();
        }

        private void Test1()
        {
            IWarrior w1 = new WarriorBase(1, "w1", 1, 0, 500, 500, 0.1, new TileConsoleShape('★'), new MeleeAttack("melee", 30, 40));
            IWarrior w2 = new WarriorBase(2, "w2", 1, 0, 500, 450, 0.12, new TileConsoleShape('☆'), new MeleeAttack("melee2", 40, 40));            

            GridMap map = new GridMap("mapTest", 10, 10);
            map.PutCreatureOn(w1, 1, 0, 1);
            map.PutCreatureOn(w2, 1, 5, 5);

            map.FillUpWith(new Tile("DT", true, new TileConsoleShape('□')));

            ConsoleMapDrawer drawer = new ConsoleMapDrawer(map);
            drawer.Draw();
        }
    }
}