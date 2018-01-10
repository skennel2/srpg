using System.Collections.Generic;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.MapGenerator
{
    public interface IFileToGridMapGenerator
    {
        IGridMap GenerateMap(string filePath);
        List<IGridMap> GenerateMaps(string filePath);
    }
}
