using System.Windows;

namespace VectorGraphicViewer.Contracts
{
    public interface IShape
    {
        UIElement ToUIElement();
    }
}
