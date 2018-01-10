using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.AI
{
    /// <summary>
    /// ICommand를 선택하는 AI
    /// </summary>
    public interface ICommandSelectAI
    {
        ICommand SelectCommand(CreatureOnMap warrior, List<ICommand> commands);
    }
}