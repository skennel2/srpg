using Srpg.App.Domain.Common;

namespace Srpg.App.Domain.Map
{
    public class CretureOnMapMoveCommand : ICommand
    {
        private readonly CreatureMoveDirection direction;
        private readonly CreatureOnMap creature;

        public CretureOnMapMoveCommand(CreatureOnMap creature, CreatureMoveDirection direction)
        {
            this.creature = creature;
            this.direction = direction;
        }

        public CreatureMoveDirection Direction => direction;
        public CreatureOnMap Creature => creature;

        public void Execute()
        {
            if (direction == CreatureMoveDirection.Up)
            {
                creature.MoveUp();
            }
        }
    }
}