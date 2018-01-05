using System;
using System.Linq;
using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.AI;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.Battle
{
    public class TurnBaseBattleState : IState
    {
        private readonly ITurnBaseBattleRule rule;
        private readonly ICommandSelectAI commandSelector;

        public TurnBaseBattleState(ICommandSelectAI commandSelector)
        {
            this.commandSelector = commandSelector;
        }

        private ICommand SelectCommand(CreatureOnMap warrior, List<ICommand> commands)
        {
            ICommand command = null;

            if (warrior.TeamId != rule.PlayerTeamId)
            {
                command = commandSelector.SelectCommand(warrior, commands);
            }
            else
            {
                throw new NotImplementedException();
            }   

            return command;         
        }

        public void Update()
        {
            while (rule.WinnerTeamId != -1)
            {
                var warrior = rule.NextWarrior;
                var commands = rule.GetAbailableCommands(warrior.CreatureId);

                SelectCommand(warrior, commands).Execute();
            }
        }

        public void Render()
        {

        }

        public void OnEnter()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }
    }
}