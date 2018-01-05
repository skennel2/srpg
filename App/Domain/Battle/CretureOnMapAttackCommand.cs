using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Battle
{
    public class CretureOnMapAttackCommand : ICommand
    {
        private readonly ICreature attacker;
        private readonly List<ICreature> targets;

        public CretureOnMapAttackCommand(ICreature attacker, List<ICreature> targets)
        {
            this.targets = targets;
            this.attacker = attacker;
        }

        public ICreature Attacker => attacker;
        public List<ICreature> Targets => targets;

        public void Execute()
        {
            if (attacker is IWarrior)
            {
                (attacker as IWarrior).Attack(targets);
            }
        }
    }
}