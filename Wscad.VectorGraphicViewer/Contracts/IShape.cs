using System.Windows;

namespace Wscad.VectorGraphicViewer.Contracts
{
    public interface IShape
    {
        UIElement ToUIElement();
    }
}
