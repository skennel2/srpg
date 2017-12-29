namespace Srpg.App.Domain.Common
{
    public interface ISearchableForName<T>
    {
         T GetByName(string name);
    }
}