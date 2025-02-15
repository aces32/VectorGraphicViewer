using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Wscad.VectorGraphicViewer.Extensions.Helpers;

namespace Wscad.VectorGraphicViewer.Model.Entities
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
                Width = Radius * 2,
                Height = Radius * 2,
                Stroke = GetParsedColor(),
                StrokeThickness = 1,
                Fill = Filled ? GetParsedColor() : Brushes.Transparent
            };

            Canvas.SetLeft(ellipse, (cx - Radius));
            Canvas.SetTop(ellipse, (-cy - Radius));

            return ellipse;
        }
    }
}
