namespace Srpg.App.Domain.Common
{
    public interface IEntity<Key>
    {
        Key Id { get; }
    }
}