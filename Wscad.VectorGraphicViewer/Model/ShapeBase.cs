using System.Windows.Media;
using System.Windows;
using Wscad.VectorGraphicViewer.Contracts;
using Wscad.VectorGraphicViewer.Extensions.Helpers;

namespace Wscad.VectorGraphicViewer.Model
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
