using System.Text.Json;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Extensions.Enums;

namespace VectorGraphicViewer.Extensions.Helpers
{
    public static class ShapeFactoryHelpers
    {
        public static ShapeType ParseShapeType(string type)
        {
            if (!Enum.TryParse<ShapeType>(type, ignoreCase: true, out var shapeType))
            {
                throw new NotSupportedException("Shape type is not supported.");
            }

            return shapeType;
        }

        public static IShape DeserializeShape(string json, JsonSerializerOptions options, Func<string, JsonSerializerOptions, IShape> deserializer)
        {
            return deserializer(json, options) ?? throw new InvalidOperationException("Failed to deserialize shape data.");
        }

        public static string ValidateShapeData(Dictionary<string, object> shapeData)
        {
            if (!shapeData.TryGetValue("type", out var typeObj))
            {
                throw new ArgumentException("Shape data must contain a valid 'type' field.");
            }

            return typeObj?.ToString()?.ToLower() ?? throw new InvalidOperationException("Shape type is null.");
        }
    }
}
