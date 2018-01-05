using System;
using Srpg.App.ConsoleApp;
using Srpg.App.Domain.Battle;
using Srpg.App.Domain.CombatSkill;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Test
{
    public class TestResolutionRoot : ICompositionRoot
    {
        public void SetUp()
        {
        }

        public void Run()
        {
            Test3();
        }

        private void Test1()
        {
            IWarrior w1 = new WarriorBase(1, "w1", 1, 0, 500, 500, 0.1, new TileConsoleShape('★'), new MeleeAttack("melee", 30, 40));
            IWarrior w2 = new WarriorBase(2, "w2", 1, 0, 500, 450, 0.12, new TileConsoleShape('☆'), new MeleeAttack("melee2", 40, 40));            

            IGridMap map = new GridMap("mapTest", 22, 10);

            var t1 = new Tile("DT", true, new TileConsoleShape('□'));
            var t2 = new Tile("DT", true, new TileConsoleShape('#'));
            
            map.FillUpWith(new Tile("DT", true, new TileConsoleShape('□')));
            map.SetTile(t2, 1, 6);

            ConsoleMapDrawer drawer = new ConsoleMapDrawer(map);
            drawer.Draw();
        }

        private void Test2()
        {
            IWarrior w1 = new WarriorBase(1, "w1", 1, 0, 500, 500, 0.1, new TileConsoleShape('★'), new MeleeAttack("melee", 30, 40));
            IWarrior w2 = new WarriorBase(2, "w2", 1, 0, 500, 450, 0.12, new TileConsoleShape('#'), new MeleeAttack("melee2", 40, 40));            

            IGridMap map = new GridMap("mapTest", 22, 10);

            var t1 = new Tile("DT", true, new TileConsoleShape('□'));
            var t2 = new Tile("DT", true, new TileConsoleShape('#'));
            
            map.FillUpWith(new Tile("DT", true, new TileConsoleShape('□')));

            // start
            BattleState battleState = new BattleState(0, map, 1);
            battleState.JoinToBattle(1, w1, 0,0);
            battleState.JoinToBattle(2, w2, 3,3);
            var list = battleState.GetCommandList(1);
            
            foreach(var c in list)
            {
                c.Execute();
            }

            //battleState.GetCreatureAt(0,1).MoveDown();


            battleState.Render();
        }

        private void Test3()
        {
            IWarrior w1 = new WarriorBase(1, "w1", 1, 0, 500, 500, 0.1, new TileConsoleShape('★'), new MeleeAttack("melee", 30, 40));
            IWarrior w2 = new WarriorBase(2, "w2", 1, 0, 500, 450, 0.12, new TileConsoleShape('#'), new MeleeAttack("melee2", 40, 40));            

            IGridMap map = new GridMap("mapTest", 22, 10);

            map.FillUpWith(new Tile("DT", true, new TileConsoleShape('□')));

            GridMoveState moveState = new GridMoveState(map, new CreatureOnMap(1,1,map,w1,0,0));
            moveState.Update();
        }        
    }
}