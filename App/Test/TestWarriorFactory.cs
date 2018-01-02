using System.Collections.Generic;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Unit;
using System;

namespace Srpg.App.Test
{
    public class TestWarriorFactory : IFactory<long, IWarrior>, ISearchableForName<IWarrior>
    {
        private Dictionary<long, IWarrior> repository;

        public IWarrior GetByKey(long key)
        {
            if(!repository.ContainsKey(key))
            {   
                throw new KeyNotFoundException();
            }

            return repository[key];
        }

        public IWarrior GetByName(string name)
        {
            foreach (var item in repository)
            {
                if(item.Value.Name == name)
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException();
        }
    }
}