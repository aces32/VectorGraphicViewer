using System.Text.Json;
using VectorGraphicViewer.Data.Reader;

namespace VectorGraphicViewer.UnitTests.Data.Reader
{
    public class JsonShapeDataReaderTests
    {
        [Fact]
        public async Task ReadShapesAsync_ShouldReturnShapeDataList_WhenJsonIsValid()
        {
            // Arrange
            var json = "[{\"type\":\"line\"}]";
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            var reader = new JsonShapeDataReader();

            // Act
            var result = await reader.ReadShapesAsync(stream);

            // Assert
            Assert.Single(result);
            Assert.Equal("line", result[0]["type"].ToString());
        }

        [Fact]
        public async Task ReadShapesAsync_ShouldReturnEmptyList_WhenJsonIsEmpty()
        {
            // Arrange
            var json = "[]";
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            var reader = new JsonShapeDataReader();

            // Act
            var result = await reader.ReadShapesAsync(stream);

            // Assert
            Assert.Empty(result);
        }


        [Fact]
        public async Task ReadShapesAsync_ShouldThrowJsonException_WhenJsonIsInvalid()
        {
            // Arrange
            var json = "[{\"type\":\"line\"";
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            var reader = new JsonShapeDataReader();

            // Act & Assert
            await Assert.ThrowsAsync<JsonException>(() => reader.ReadShapesAsync(stream));
        }
    }
}

