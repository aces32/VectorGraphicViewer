using System.IO;

namespace Wscad.VectorGraphicViewer.Contracts
{
    public interface IShapeDataReader
    {
        Task<List<Dictionary<string, object>>> ReadShapesAsync(Stream stream);
    }
}
