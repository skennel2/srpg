using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.AI
{
    public interface ICommandSelectAI
    {
        ICommand SelectCommand(CreatureOnMap warrior, List<ICommand> commands);
    }

    public class MoqCommandSelectAI : ICommandSelectAI
    {
        public ICommand SelectCommand(CreatureOnMap warrior, List<ICommand> commands)
        {
            if(commands != null && commands.Count > 0)
            {
                return commands[0];
            }

            return null;
        }
    }
}