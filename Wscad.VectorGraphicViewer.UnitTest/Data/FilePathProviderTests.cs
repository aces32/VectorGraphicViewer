using System;
using System.IO;
using Wscad.VectorGraphicViewer.Data;
using Xunit;

namespace Wscad.VectorGraphicViewer.UnitTests.Data
{
    public class FilePathProviderTests
    {
        [Fact]
        public void GetFilePath_ShouldReturnCorrectPath()
        {
            // Arrange
            var expectedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VectorFiles", "ShapeObjects.json");
            var filePathProvider = new FilePathProvider();

            // Act
            var result = filePathProvider.GetFilePath();

            // Assert
            Assert.Equal(expectedPath, result);
        }

        [Fact]
        public void GetFilePath_ShouldReturnPathWithBaseDirectory()
        {
            // Arrange
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var expectedPath = Path.Combine(baseDirectory, "VectorFiles", "ShapeObjects.json");
            var filePathProvider = new FilePathProvider();

            // Act
            var result = filePathProvider.GetFilePath();

            // Assert
            Assert.StartsWith(baseDirectory, result);
            Assert.EndsWith("VectorFiles\\ShapeObjects.json", result.Replace("/", "\\"));
        }
    }
}
