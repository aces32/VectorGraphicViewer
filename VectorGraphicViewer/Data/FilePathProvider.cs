using System.IO;
using VectorGraphicViewer.Contracts;

namespace VectorGraphicViewer.Data
{
    public class FilePathProvider : IFilePathProvider
    {
        public string GetFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VectorFiles", "ShapeObjects.json");
        }
    }
}
