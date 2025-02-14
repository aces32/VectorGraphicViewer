using System.IO;
using Wscad.VectorGraphicViewer.Contracts;

namespace Wscad.VectorGraphicViewer.Data
{
    public class FilePathProvider : IFilePathProvider
    {
        public string GetFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VectorFiles", "ShapeObjects.json");
        }
    }
}
