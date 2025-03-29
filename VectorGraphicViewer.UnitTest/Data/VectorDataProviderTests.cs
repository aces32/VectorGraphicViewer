using Moq;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Data;

namespace VectorGraphicViewer.UnitTest.Data
{
    public class VectorDataProviderTests
    {
        [Fact]
        public async Task LoadShapesAsync_ShouldReturnShapes_WhenFileIsValid()
        {
            // Arrange
            var mockShapeDataReader = new Mock<IShapeDataReader>();
            var mockFilePathProvider = new Mock<IFilePathProvider>();
            var mockShapeFactory = new Mock<IShapeFactory>();

            var shapeDataList = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { { "type", "line" } }
                };

            var shape = new Mock<IShape>();

            mockFilePathProvider.Setup(p => p.GetFilePath())
                .Returns(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VectorFiles", "ShapeObjects.json"));
            mockShapeDataReader.Setup(r => r.ReadShapesAsync(It.IsAny<Stream>())).ReturnsAsync(shapeDataList);
            mockShapeFactory.Setup(f => f.CreateShape(It.IsAny<Dictionary<string, object>>())).Returns(shape.Object);

            var readers = new Dictionary<string, IShapeDataReader>
                {
                    { ".json", mockShapeDataReader.Object }
                };

            var vectorDataProvider = new VectorDataProvider(readers, mockFilePathProvider.Object, mockShapeFactory.Object);

            // Act
            var result = await vectorDataProvider.LoadShapesAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal(shape.Object, result.First());
        }

        [Fact]
        public async Task LoadShapesAsync_ShouldThrowNotSupportedException_WhenFileExtensionIsNotSupported()
        {
            // Arrange
            var mockFilePathProvider = new Mock<IFilePathProvider>();
            var mockShapeFactory = new Mock<IShapeFactory>();

            mockFilePathProvider.Setup(p => p.GetFilePath()).Returns("test.unsupported");

            var readers = new Dictionary<string, IShapeDataReader>();

            var vectorDataProvider = new VectorDataProvider(readers, mockFilePathProvider.Object, mockShapeFactory.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotSupportedException>(() => vectorDataProvider.LoadShapesAsync());
        }

    }
}
