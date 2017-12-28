using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Unit
{
    public delegate void StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs>(object sender, StatusChangeEffectChangedEventArgs args);

    public abstract class LivingCreature : IHaveName, ICreatureBody, ICanGrowUp, INotifyPropertyChanged
    {
        private readonly long id;
        private readonly string name;
        private int maxHealthPoint;
        private int nowHealthPoint;
        private double depensiveRate;
        private int level;   
        private int experiencePoint;
        private bool isAlive;
        private readonly IList<TurnLimitedCreatureStatusChangerBase> effects;  
        private readonly IShapable creatureShape;

        public LivingCreature(long id, string name, int level, int experiencePoint,
            int maxHealthPoint,
            int nowHealthPoint,
            double depensiveRate,
            List<TurnLimitedCreatureStatusChangerBase> effects,
            IShapable creatureShape)
        {
            this.id = id;
            this.name = name;
            this.Level = level;
            this.experiencePoint = experiencePoint;
            this.MaxHealthPoint = maxHealthPoint;
            this.NowHealthPoint = nowHealthPoint;
            this.DepensiveRate = depensiveRate;
            this.effects = effects;
            this.IsAlive = true;
            this.creatureShape = creatureShape; 
        }

        public string Name => name;

        public long Id => id;

        public int Level 
        { 
            get => level;
            private set
            {
                this.level = value;
                OnPropertyChange();   
            } 
        }

        public int ExperiencePoint 
        {
            get => experiencePoint;
            private set
            {
                this.experiencePoint = value;
                OnPropertyChange();
            }
        }

        public int MaxHealthPoint 
        {
            get => maxHealthPoint; 
            private set
            {
                maxHealthPoint = value;
                OnPropertyChange();   
            } 
        }       

        public int NowHealthPoint 
        { 
            get => nowHealthPoint; 
            private set 
            {
                nowHealthPoint = value;
                if(nowHealthPoint > maxHealthPoint)
                {
                    this.nowHealthPoint = maxHealthPoint;
                }

                if(nowHealthPoint <= 0)
                {
                    IsAlive = false;
                    nowHealthPoint = 0;
                }
                
                OnPropertyChange();  
            } 
         }

        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public double DepensiveRate { get => depensiveRate; set => depensiveRate = value; }
        public IDrawable CreatureShape => creatureShape;

        public event PropertyChangedEventHandler PropertyChanged;
        public event StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs> EffectListChanged;

        public virtual void IncreaseLevel()
        {
            this.Level += 1;
        }

        public void AcquireExperiencePoint(int amount)
        {
            this.ExperiencePoint += amount;
        }        

        public virtual void AddATemporaryEffect(LivingCreature sender, TurnLimitedCreatureStatusChangerBase effect)
        {
            this.effects.Add(effect); 
            OnEffectListChange(effect.Name, false);
        }

        public virtual void RemoveTemporaryEffect(TurnLimitedCreatureStatusChangerBase effect)
        {
            if(effects.Contains(effect))
            {
                this.effects.Remove(effect);
                effect.RollbackCreature(this);
                OnEffectListChange(effect.Name, true);
            }
        }

        public void UpdateStatus()
        {
            TurnLimitedCreatureStatusChangerBase effectRemove = null;
            foreach(var effect in effects)
            {
                if(effect.IsExpired)
                {
                    effectRemove = effect;
                    effect.RollbackCreature(this);
                }
                else
                {
                    effect.GiveAEffect(this);
                }
            }

            if(effectRemove != null)
            {
                effects.Remove(effectRemove);
                OnEffectListChange(effectRemove.Name, true); 
            } 
        }

        public virtual void RecoveryHealth(int amount)
        {
            this.NowHealthPoint += amount;
        }

        public void TakeADamage(int amount)
        {
            this.NowHealthPoint -= amount;
        }

        public virtual void TakeADamage(WarriorBase attacker, int amount)
        {
            TakeADamage(amount);
        }

        public virtual void TakeADamageWithDepensiveRate(WarriorBase attacker, int amount)
        {
            int damage = (int)Math.Round(amount - (amount * this.DepensiveRate));

            TakeADamage(attacker, damage);
        }

        protected void OnPropertyChange([CallerMemberName]string propertyName="")
        {
            var args = new PropertyChangedEventArgs(propertyName);

            if(PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }

        private void OnEffectListChange(string effectName, bool isRemoved)
        {
            var args = new StatusChangeEffectChangedEventArgs(effectName, isRemoved);

            if(PropertyChanged != null)
            {
                EffectListChanged(this, args);
            }
        }
    }    
}