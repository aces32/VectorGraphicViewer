using Moq;
using Wscad.VectorGraphicViewer.Contracts;
using Wscad.VectorGraphicViewer.Contracts.DataProvider;
using Wscad.VectorGraphicViewer.ViewModel;

namespace Wscad.VectorGraphicViewer.UnitTests.ViewModel
{
    public class VectorViewModelTests
    {
        [Fact]
        public async Task LoadAsync_ShouldLoadShapes_WhenShapesAreNotLoaded()
        {
            // Arrange
            var mockDataProvider = new Mock<IVectorDataProvider>();
            var shapes = new List<IShape> { new Mock<IShape>().Object };
            mockDataProvider.Setup(dp => dp.LoadShapesAsync()).ReturnsAsync(shapes);
            var viewModel = new VectorViewModel(mockDataProvider.Object);

            // Act
            await viewModel.LoadAsync();

            // Assert
            Assert.NotEmpty(viewModel.Shapes);
            Assert.Single(viewModel.Shapes);
        }

        [Fact]
        public async Task LoadAsync_ShouldNotLoadShapes_WhenShapesAreAlreadyLoaded()
        {
            // Arrange
            var mockDataProvider = new Mock<IVectorDataProvider>();
            var shapes = new List<IShape> { new Mock<IShape>().Object };
            mockDataProvider.Setup(dp => dp.LoadShapesAsync()).ReturnsAsync(shapes);
            var viewModel = new VectorViewModel(mockDataProvider.Object);
            await viewModel.LoadAsync(); // Load shapes initially

            // Act
            await viewModel.LoadAsync(); // Try loading shapes again

            // Assert
            mockDataProvider.Verify(dp => dp.LoadShapesAsync(), Times.Once); // Ensure LoadShapesAsync is called only once
        }
    }
}
