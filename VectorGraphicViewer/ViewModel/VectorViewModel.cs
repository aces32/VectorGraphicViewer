using System.Collections.ObjectModel;
using System.Windows;
using VectorGraphicViewer.Contracts.DataProvider;

namespace VectorGraphicViewer.ViewModel
{
    public class VectorViewModel(IVectorDataProvider vectorDataProvider) : ViewModelBase
    {
        private readonly IVectorDataProvider _vectorDataProvider = vectorDataProvider;
        public ObservableCollection<UIElement> Shapes { get; } = [];

        public override async Task LoadAsync()
        {
            if (Shapes.Any())
            {
                return;
            }

            var shapes = await _vectorDataProvider.LoadShapesAsync();
            if (shapes is not null)
            {
                foreach (var shape in shapes)
                {
                    Shapes.Add(shape.ToUIElement());
                }

            }
        }
    }
}
