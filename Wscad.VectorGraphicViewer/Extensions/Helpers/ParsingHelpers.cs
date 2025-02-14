using System.Windows.Media;

namespace Wscad.VectorGraphicViewer.Extensions.Helpers
{
    public static class ParsingHelper
    {
        /// <summary>
        /// Parses a semicolon-delimited string into a (double x, double y) tuple.
        /// </summary>
        public static (double, double) ParsePoint(string point)
        {
            var parts = point.Split(';').Select(double.Parse).ToArray();
            return (parts[0], parts[1]);
        }

        /// <summary>
        /// Parses a semicolon-delimited string into a SolidColorBrush.
        /// Format: "A;R;G;B"
        /// </summary>
        public static SolidColorBrush ParseColor(string? color)
        {
            if (color is not null)
            {
                var parts = color?.Split(';').Select(byte.Parse).ToArray();
                return new SolidColorBrush(Color.FromArgb(parts[0], parts[1], parts[2], parts[3]));
            }

            return new SolidColorBrush();
        }
    }
}
