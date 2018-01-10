using System;
using System.ComponentModel;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Service
{
    public class OneOnOneConsoleBattle
    {
        private int nowTurn = 0;
        private bool turnToggle = true;

        private readonly WarriorBase w1;
        private readonly WarriorBase w2;

        public OneOnOneConsoleBattle(WarriorBase w1, WarriorBase w2)
        {
            this.w1 = w1;
            this.w2 = w2;
            w1.PropertyChanged += new PropertyChangedEventHandler(WarriorPropertyChange);
            w2.PropertyChanged += new PropertyChangedEventHandler(WarriorPropertyChange);

            w1.EffectListChanged += new StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs>(WarriorEffectChange);
            w2.EffectListChanged += new StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs>(WarriorEffectChange);
        }

        private void WarriorEffectChange(object sender, StatusChangeEffectChangedEventArgs args)
        {
            WarriorBase warrior = sender as WarriorBase;
            if(args.isRemoved)
            {
                System.Console.WriteLine(warrior.Name + " remove " + args.EffectName);
            }
            else
            {
                System.Console.WriteLine(warrior.Name + " got " + args.EffectName);
            }
        }

        private void WarriorPropertyChange(object sender, PropertyChangedEventArgs args)
        {   
            WarriorBase warrior = sender as WarriorBase;

            if(args.PropertyName == nameof(WarriorBase.NowHealthPoint))
            {
                Console.WriteLine(warrior.Name +"'s "+ nameof(WarriorBase.NowHealthPoint) + " : " + warrior.NowHealthPoint);
            }
        }

        public void StartBattle()
        {
            while(w1.IsAlive && w2.IsAlive)
            {
                nowTurn++;
                PrintTurnChangeMessage();
                
                WarriorBase attacker = turnToggle ? w1 : w2;
                WarriorBase depender = !turnToggle ? w1 : w2;
                Console.WriteLine(attacker.Name + " attack " +depender.Name + "!!!");

                attacker.Attack(depender);


                turnToggle = !turnToggle;
            } 

            Console.WriteLine("Winner is " + Winner.Name);  
        }

        private void PrintTurnChangeMessage()
        {
            System.Console.WriteLine("------------------------------------------------");
            Console.WriteLine(nowTurn + " Turn is Start");
        }

        public WarriorBase Winner
        {
            get
            {
                if(w1.IsAlive && w2.IsAlive)
                {
                    return null;
                }
                else if(w1.IsAlive)
                {
                    return w1;
                }
                else
                {
                    return w2;
                }
            }
        }
    }
}