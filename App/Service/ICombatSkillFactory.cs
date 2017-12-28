using Srpg.App.Domain.CombatSkill;

namespace Srpg.App.Service
{
    public interface ICombatSkillFactory
    {
        ICombatSkill GetByName(string name);
    }
}