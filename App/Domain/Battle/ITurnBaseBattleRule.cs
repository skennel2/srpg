using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Domain.Battle
{
    public interface ITurnBaseBattleRule
    {
        CreatureOnMap NextWarrior { get; }
        int NowTurn { get; }
        int PlayerTeamId { get; }
        int WinnerTeamId { get; }
        bool IsSetUpComplete { get; }
        void JoinToBattle(int teamId, IWarrior warrior, int xLocation, int yLocation);
        List<ICommand> GetAbailableCommands(int creatureId);
        void ExcuteCommand(ICommand command);
    }
}