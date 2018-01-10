using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Util;

namespace Srpg.App.Domain.AI
{
    public class MoqCommandSelectAI : ICommandSelectAI
    {
        public ICommand SelectCommand(CreatureOnMap warrior, List<ICommand> commands)
        {
            if(commands != null && commands.Count > 0)
            {
                int index = RandomNumberGenerator.NumberBetween(0, commands.Count - 1);
                
                return commands[index];
            }

            return null;
        }
    }
}