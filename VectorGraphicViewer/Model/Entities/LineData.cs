using System.Windows.Shapes;
using System.Windows;
using VectorGraphicViewer.Extensions.Helpers;

namespace VectorGraphicViewer.Model.Entities
{
    public class LineData : ShapeBase
    {
        public string A { get; set; }
        public string B { get; set; }

        public override UIElement ToUIElement()
        {
            var (x1, y1) = ParsingHelper.ParsePoint(A);
            var (x2, y2) = ParsingHelper.ParsePoint(B);

            return new Line
            {
                X1 = x1 * 2.25,
                Y1 = -y1 * 2.25,
                X2 = x2 * 2.25,
                Y2 = -y2 * 2.25,
                Stroke = GetParsedColor(),
                StrokeThickness = 1
            };
        }

    }
}
