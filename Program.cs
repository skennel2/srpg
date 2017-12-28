using System;
using System.Collections.Generic;
using Srpg.App.Domain.Map;
using Srpg.App.Service;

namespace Srpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");  

            OneOnOneBattleTest();
            MapDrawTest();

            Console.ReadKey();
        } 

        public static void OneOnOneBattleTest()
        {
            WarriorBaseFactoryTest factory = new WarriorBaseFactoryTest();
            var w1 = factory.GetByName("test1");
            var w2 = factory.GetByName("test2");

            var oneOnOne = new OneOnOneConsoleBattle(w1, w2);
            oneOnOne.StartBattle();
        }      

        public static void MapDrawTest()
        {
            var map = new MapImpl("test", 10, 10);
            var defaultTile = new Tile("12", true, new TileConsoleShape('□'));
            var tile2 = new Tile("23", true, new TileConsoleShape('◆'));

            map.Fill(defaultTile);
            map.SetTile(tile2, 0, 0);
            map.SetTile(tile2, 10, 9);

            var mapDrawer = new ConsoleMapDrawer(map);

            mapDrawer.ShowName();
            mapDrawer.Draw();
        } 
    }
}
