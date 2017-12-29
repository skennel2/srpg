namespace Srpg.App.Domain.Common
{
    public interface IFactory<Key, T> where T : IEntity<Key>
    {
        T GetByKey(Key key);
    }
}