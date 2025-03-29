using System.IO;

namespace VectorGraphicViewer.Contracts
{
    public interface IShapeDataReader
    {
        Task<List<Dictionary<string, object>>> ReadShapesAsync(Stream stream);
    }
}
