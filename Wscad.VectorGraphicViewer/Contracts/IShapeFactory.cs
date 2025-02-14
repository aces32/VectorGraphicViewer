using System.Text.Json;
using Wscad.VectorGraphicViewer.Extensions.Enums;

namespace Wscad.VectorGraphicViewer.Contracts
{
    public interface IShapeFactory
    {
        IShape CreateShape(Dictionary<string, object> shapeData);
        void AddShapeDeserializer(ShapeType shapeType, Func<string, JsonSerializerOptions, IShape> deserializer);
    }
}
