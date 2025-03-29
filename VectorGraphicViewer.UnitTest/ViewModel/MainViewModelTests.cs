using Moq;
using System.Threading.Tasks;
using VectorGraphicViewer.Command;
using VectorGraphicViewer.ViewModel;
using Xunit;

namespace VectorGraphicViewer.UnitTests.ViewModel
{
    public class MainViewModelTests
    {
        [Fact]
        public async Task LoadAsync_ShouldLoadSelectedViewModel()
        {
            // Arrange
            var mockVectorViewModel = new Mock<VectorViewModel>(MockBehavior.Strict, null);
            mockVectorViewModel.Setup(vm => vm.LoadAsync()).Returns(Task.CompletedTask);
            var viewModel = new MainViewModel(mockVectorViewModel.Object);

            // Act
            await viewModel.LoadAsync();

            // Assert
            mockVectorViewModel.Verify(vm => vm.LoadAsync(), Times.Once);
        }

        [Fact]
        public Task SelectViewModel_ShouldChangeSelectedViewModel()
        {
            // Arrange
            var mockVectorViewModel = new Mock<VectorViewModel>(MockBehavior.Strict, null);
            var mockOtherViewModel = new Mock<ViewModelBase>();
            mockOtherViewModel.Setup(vm => vm.LoadAsync()).Returns(Task.CompletedTask);
            var viewModel = new MainViewModel(mockVectorViewModel.Object);

            // Act
            viewModel.SelectViewModel(mockOtherViewModel.Object);

            // Assert
            Assert.Equal(mockOtherViewModel.Object, viewModel.SelectedViewModel);
            mockOtherViewModel.Verify(vm => vm.LoadAsync(), Times.Once);
            return Task.CompletedTask;
        }
    }
}
