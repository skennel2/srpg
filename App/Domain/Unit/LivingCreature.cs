using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace Srpg.App.Domain.Unit
{
    public delegate void StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs>(object sender, StatusChangeEffectChangedEventArgs args);

    public abstract class LivingCreature : INotifyPropertyChanged
    {
        private readonly long id;
        private readonly string name;
        private int maxHealthPoint;
        private double depensiveRate;
        private int nowHealthPoint;
        private int nowLevel;   
        private bool isAlive;
        private readonly IList<TurnLimitedCreatureStatusChangerBase> effects;  

        public static string NowHealthPointPropertyName = "NowHealthPoint";
        public static string MaxHealthPointPropertyName = "NowHealthPoint";
        public static string NowLevelPropertyName = "NowLevel";

        public LivingCreature(long id, string name, int nowLevel, 
            int maxHealthPoint,
            int nowHealthPoint,
            double depensiveRate,
            List<TurnLimitedCreatureStatusChangerBase> effects)
        {
            this.id = id;
            this.name = name;
            this.NowLevel = nowLevel;
            this.maxHealthPoint = maxHealthPoint;
            this.NowHealthPoint = nowHealthPoint;
            this.depensiveRate = depensiveRate;
            this.effects = effects;
            this.IsAlive = true;
        }

        public string Name => name;
        public long Id => id;
        public int NowLevel 
        { 
            get => nowLevel;
            private set
            {
                nowLevel = value;
                OnPropertyChange(NowLevelPropertyName);   
            } 
        }
        public int MaxHealthPoint 
        {
            get => maxHealthPoint; 
            private set
            {
                maxHealthPoint = value;
                OnPropertyChange(MaxHealthPointPropertyName);   
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
                
                OnPropertyChange(NowHealthPointPropertyName);  
            } 
         }

        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public double DepensiveRate { get => depensiveRate; set => depensiveRate = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event StatusChangeEffectChangedEventHandler<StatusChangeEffectChangedEventArgs> EffectListChanged;

        public virtual void IncreaseLevel()
        {
            this.NowLevel += 1;
            OnPropertyChange(NowLevelPropertyName);
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

        public virtual void TakeADamage(LivingCreature attacker, int amount)
        {
            this.NowHealthPoint -= amount;
        }

        public virtual void TakeADamageWithDepensiveRate(LivingCreature attacker, int amount)
        {
            int damage = (int)Math.Round(amount - (amount * this.DepensiveRate));
            TakeADamage(attacker, damage);
        }

        private void OnPropertyChange(string propertyType)
        {
            var args = new PropertyChangedEventArgs(propertyType);
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