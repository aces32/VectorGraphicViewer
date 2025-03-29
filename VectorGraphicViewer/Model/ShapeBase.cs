using System.Windows.Media;
using System.Windows;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Extensions.Helpers;

namespace VectorGraphicViewer.Model
{
    public abstract class ShapeBase : IShape
    {
        /// <summary>
        /// Color is stored as a semicolon-delimited string ("A;R;G;B").
        /// </summary>
        public string? Color { get; set; }

        public abstract UIElement ToUIElement();

        protected SolidColorBrush GetParsedColor() => ParsingHelper.ParseColor(Color);
    }
}
