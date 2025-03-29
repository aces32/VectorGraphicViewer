using System.Text.Json;
using VectorGraphicViewer.Extensions.Enums;

namespace VectorGraphicViewer.Contracts
{
    public interface IShapeFactory
    {
        IShape CreateShape(Dictionary<string, object> shapeData);
        void AddShapeDeserializer(ShapeType shapeType, Func<string, JsonSerializerOptions, IShape> deserializer);
    }
}
