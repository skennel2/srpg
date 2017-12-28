using System.Collections.Generic;
using Srpg.App.Domain.CombatSkill;

namespace Srpg.App.Service
{
    public class CombatSkillFactory : ICombatSkillFactory
    {
        private readonly Dictionary<string, ICombatSkill> skillRepo;

        public ICombatSkill GetByName(string name)
        {   
            if(skillRepo.ContainsKey(name))
            {
                return skillRepo[name];
            }   

            return null;
        }
    }
}