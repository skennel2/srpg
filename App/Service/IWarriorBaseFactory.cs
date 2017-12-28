using Srpg.App.Domain.Unit;

namespace Srpg.App.Service
{
    public interface IWarriorBaseFactory
    {
        WarriorBase GetByName(string name);
    }
}