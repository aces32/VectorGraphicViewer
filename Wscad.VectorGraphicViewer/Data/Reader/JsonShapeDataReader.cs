using System.IO;
using System.Text.Json;
using Wscad.VectorGraphicViewer.Contracts;

namespace Wscad.VectorGraphicViewer.Data.Reader
{
    public class JsonShapeDataReader : IShapeDataReader
    {
        public async Task<List<Dictionary<string, object>>> ReadShapesAsync(Stream stream)
        {
            var shapeDataList = await JsonSerializer.DeserializeAsync<List<Dictionary<string, object>>>(stream);
            if (shapeDataList == null)
            {
                return new List<Dictionary<string, object>>();
            }
            return shapeDataList;
        }
    }
}
