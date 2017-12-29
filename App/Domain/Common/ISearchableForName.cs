namespace Srpg.App.Domain.Common
{
    public interface ISearchableForName<T> where T : IHaveName
    {
         T GetByName(string name);
    }
}