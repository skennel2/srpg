using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;

namespace Srpg.App.Domain.MapGenerator
{
    public class JsonToGridMapGenerator : IFileToGridMapGenerator
    {
        private readonly ITileSetMapper tileMapper;

        public JsonToGridMapGenerator(ITileSetMapper tileMapper)
        {
            this.tileMapper = tileMapper;
        }

        public IGridMap GenerateMap(string filePath)
        {
            GridMap map = null;

            using (StreamReader r = new StreamReader(filePath))
            {
                try
                {
                    JsonMap jsonMap = JsonConvert.DeserializeObject<JsonMap>(r.ReadToEnd());

                    if(jsonMap.IsValidate())
                    {
                        map = new GridMap(jsonMap.Name, jsonMap.Width, jsonMap.Height, MapIntegerToTile(jsonMap.Tiles));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return map;
        }

        public List<IGridMap> GenerateMaps(string filePath)
        {
            List<IGridMap> maps = new List<IGridMap>();

            using (StreamReader r = new StreamReader(filePath))
            {
                try
                {
                    List<JsonMap> jsonMaps = JsonConvert.DeserializeObject<List<JsonMap>>(r.ReadToEnd());

                    foreach (var jsonMap in jsonMaps)
                    {
                        if(jsonMap.IsValidate())
                        {
                            maps.Add( new GridMap(jsonMap.Name, jsonMap.Width, jsonMap.Height, MapIntegerToTile(jsonMap.Tiles)));
                        }                        
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return maps;
        }        

        private List<Tile> MapIntegerToTile(int[] tileInt)
        {
            List<Tile> tiles = new List<Tile>();

            foreach (var item in tileInt)
            {
                tiles.Add(tileMapper.GetTile(item));
            }

            return tiles;
        }

        internal struct JsonMap : IValidatable
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int[] Tiles { get; set; }

            public bool IsValidate()
            {
                if(Width < 1 || Height < 1)
                {
                    return false;
                }

                if(Tiles.Length != Width * Height)
                {
                    return false;
                }
                
                return true;
            }
        }
    }
}