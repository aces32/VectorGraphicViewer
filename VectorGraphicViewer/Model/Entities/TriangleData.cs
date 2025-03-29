using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using VectorGraphicViewer.Extensions.Helpers;

namespace VectorGraphicViewer.Model.Entities
{
    public class TriangleData : ShapeBase
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public bool Filled { get; set; }

        public override UIElement ToUIElement()
        {
            var (x1, y1) = ParsingHelper.ParsePoint(A);
            var (x2, y2) = ParsingHelper.ParsePoint(B);
            var (x3, y3) = ParsingHelper.ParsePoint(C);

            return new Polygon
            {
                Points = new PointCollection
                {
                    new Point(x1 * 2.25 , -y1 * 2.25),
                    new Point(x2 * 2.25 , -y2 * 2.25),
                    new Point(x3 * 2.25 , -y3 * 2.25)
                },
                Stroke = GetParsedColor(),
                StrokeThickness = 1,
                Fill = Filled ? GetParsedColor() : Brushes.Transparent
            };
        }

    }
}
