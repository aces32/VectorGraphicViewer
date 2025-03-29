using Moq;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Data;
using VectorGraphicViewer.Extensions.Enums;
using VectorGraphicViewer.Model.Entities;

namespace VectorGraphicViewer.UnitTests.Data
{
    public class ShapeFactoryTests
    {
        [Fact]
        public void CreateShape_ShouldReturnLineData_WhenShapeTypeIsLine()
        {
            // Arrange
            var shapeData = new Dictionary<string, object>
            {
                { "type", "line" }
            };
            var shapeFactory = new ShapeFactory();

            // Act
            var result = shapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsType<LineData>(result);
        }

        [Fact]
        public void CreateShape_ShouldThrowNotSupportedException_WhenShapeTypeIsNotSupported()
        {
            // Arrange
            var shapeData = new Dictionary<string, object>
            {
                { "type", "unsupported" }
            };
            var shapeFactory = new ShapeFactory();

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => shapeFactory.CreateShape(shapeData));
        }

        [Fact]
        public void AddShapeDeserializer_ShouldAddNewDeserializer()
        {
            // Arrange
            var shapeFactory = new ShapeFactory();
            var shapeData = new Dictionary<string, object>
            {
                { "type", "rectangle" }
            };
            var rectangleData = new Mock<IShape>();

            shapeFactory.AddShapeDeserializer(ShapeType.Rectangle, (json, options) => rectangleData.Object);

            // Act
            var result = shapeFactory.CreateShape(shapeData);

            // Assert
            Assert.Equal(rectangleData.Object, result);
        }

    }
}
