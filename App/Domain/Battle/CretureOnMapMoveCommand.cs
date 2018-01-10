using System;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.Battle
{
    public class CretureOnMapMoveCommand : ICommand
    {
        private readonly CreatureMoveDirection direction;
        private readonly IGridMovable creature;

        public CretureOnMapMoveCommand()
        {
        }

        public CretureOnMapMoveCommand(IGridMovable creature, CreatureMoveDirection direction)
        {
            this.creature = creature;
            this.direction = direction;
        }

        public CreatureMoveDirection Direction => direction;
        public IGridMovable Creature => creature;

        public void Execute()
        {
            creature.Move(direction);
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(CreatureMoveDirection), direction);
        }
    }
}