using System;
using System.Collections;
using System.Collections.Generic;

namespace Srpg.App.Domain.Map
{
    public class CretureOnMapList : IDictionary<long, CreatureOnMap>
    {
        public CreatureOnMap this[long key] 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public ICollection<long> Keys => throw new NotImplementedException();

        public ICollection<CreatureOnMap> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(long key, CreatureOnMap value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<long, CreatureOnMap> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<long, CreatureOnMap> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(long key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<long, CreatureOnMap>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<long, CreatureOnMap>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(long key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<long, CreatureOnMap> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(long key, out CreatureOnMap value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}