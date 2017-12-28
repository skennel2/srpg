﻿using System;
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
            Console.Clear();

            WarriorBaseFactoryTest factory = new WarriorBaseFactoryTest();
            var w1 = factory.GetByName("test1");

            var map = new GridMap("test", 10, 10);
            var defaultTile = new Tile("12", true, new TileConsoleShape('□'));
            var tile2 = new Tile("23", true, new TileConsoleShape('◆'));

            map.FillUpWith(defaultTile);
            map.SetTile(tile2, 0, 0);
            map.SetTile(tile2, 9, 9);
            map.PutCreatureOn(w1, 1, 1, 1);

            var c = map.GetLivingCreatureAt(1,1);
            c.MoveDown();
            c.MoveDown();
            c.MoveDown();
            c.MoveLeft();
            c.MoveLeft();
            Console.WriteLine(c.CretureXLocation.ToString() + "---" + c.CretureYLocation.ToString());

            var mapDrawer = new ConsoleMapDrawer(map);
            mapDrawer.ShowName();
            mapDrawer.Draw();
        } 
    }
}
