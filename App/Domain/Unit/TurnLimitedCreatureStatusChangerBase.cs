using System;

namespace Srpg.App.Domain.Unit
{
    public abstract class TurnLimitedCreatureStatusChangerBase : ICreatureStatusChanger
    {
        private int retentionTurn;
        private readonly ICreatureStatusChanger effect;
        private bool isAlreadyTaken;        

        public TurnLimitedCreatureStatusChangerBase(int retentionTurn, ICreatureStatusChanger effect)
        {
            this.retentionTurn = retentionTurn;
            this.effect = effect;
            this.IsAlreadyTaken = false;
        }

        public abstract void GiveAEffect(ICreature creature);

        public abstract void RollbackCreature(ICreature creature);

        public bool IsExpired
        {
            get => retentionTurn == 0;
        }

        public CretureStatusChangerType EffectType => Effect.EffectType;
        public string Name => Effect.Name;
        public ICreatureStatusChanger Effect => effect;
        public int RetentionTurn { get => retentionTurn; set => retentionTurn = value; }
        public bool IsAlreadyTaken { get => isAlreadyTaken; set => isAlreadyTaken = value; }
    }
}