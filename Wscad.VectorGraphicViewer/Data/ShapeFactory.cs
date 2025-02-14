using System.Text.Json;
using Wscad.VectorGraphicViewer.Contracts;
using Wscad.VectorGraphicViewer.Extensions.Enums;
using Wscad.VectorGraphicViewer.Extensions.Helpers;
using Wscad.VectorGraphicViewer.Model.Entities;

namespace Wscad.VectorGraphicViewer.Data
{
    public class ShapeFactory : IShapeFactory
    {
        public IShape CreateShape(Dictionary<string, object> shapeData)
        {
            string type = ShapeFactoryHelpers.ValidateShapeData(shapeData);
            string json = JsonSerializer.Serialize(shapeData);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Parse the shape type from the JSON string into an enum.
            ShapeType shapeType = ShapeFactoryHelpers.ParseShapeType(type);

            if (!_shapeDeserializers.TryGetValue(shapeType, out var deserializer))
            {
                throw new NotSupportedException($"Shape type '{type}' is not supported.");
            }

            return ShapeFactoryHelpers.DeserializeShape(json, options, deserializer);
        }

        public void AddShapeDeserializer(ShapeType shapeType, Func<string, JsonSerializerOptions, IShape> deserializer)
        {
            _shapeDeserializers[shapeType] = deserializer;
        }

        private readonly Dictionary<ShapeType, Func<string, JsonSerializerOptions, IShape>> _shapeDeserializers = new()
        {
            { ShapeType.Line, (json, options) => JsonSerializer.Deserialize<LineData>(json, options)
            ?? throw new InvalidOperationException("Failed to deserialize LineData.") },
            { ShapeType.Circle, (json, options) => JsonSerializer.Deserialize<CircleData>(json, options)
            ?? throw new InvalidOperationException("Failed to deserialize CircleData.") },
            { ShapeType.Triangle, (json, options) => JsonSerializer.Deserialize<TriangleData>(json, options)
            ?? throw new InvalidOperationException("Failed to deserialize TriangleData.") }
        };
    }
}
