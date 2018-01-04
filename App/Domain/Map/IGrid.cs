using prj.App.Domain.Common;

namespace Srpg.App.Domain.Map
{
    public interface IGrid
    {
        int XSize { get; }
        int YSize { get; }
    }
}