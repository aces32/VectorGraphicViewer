using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using VectorGraphicViewer.Extensions.Helpers;

namespace VectorGraphicViewer.Model.Entities
{
    public class CircleData : ShapeBase
    {
        public string? Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }

        public override UIElement ToUIElement()
        {
            if (string.IsNullOrEmpty(Center))
            {
                throw new ArgumentNullException(nameof(Center), "Center cannot be null or empty.");
            }

            var (cx, cy) = ParsingHelper.ParsePoint(Center);
            var ellipse = new Ellipse
            {
                Width = Radius * 2 * 2.25,
                Height = Radius * 2 * 2.25,
                Stroke = GetParsedColor(),
                StrokeThickness = 1,
                Fill = Filled ? GetParsedColor() : Brushes.Transparent
            };

            Canvas.SetLeft(ellipse, (cx * 2.25 - Radius));
            Canvas.SetTop(ellipse, (-cy * 2.25 - Radius));

            return ellipse;
        }
    }
}
