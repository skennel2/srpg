using System.Collections.Generic;
using Srpg.App.Domain.Unit;

namespace Srpg.App.Test
{
    public class TestWarriorFactory : IFactory<long, IWarrior>, ISearchableForName<IWarrior>
    {
        private Dictionary<long, IWarrior> repository;

        public IWarrior GetByKey(long key)
        {
            if(repository.ContainsKey(key))
            {
                return repository[key];
            }

            return null;
        }

        public IWarrior GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}