using System.IO;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Contracts.DataProvider;

namespace VectorGraphicViewer.Data
{
    public class VectorDataProvider : IVectorDataProvider
    {
        private readonly Dictionary<string, IShapeDataReader> _readers;
        private readonly IFilePathProvider _filePathProvider;
        private readonly IShapeFactory _shapeFactory;

        public VectorDataProvider(Dictionary<string, IShapeDataReader> readers,
            IFilePathProvider filePathProvider,
            IShapeFactory shapeFactory)
        {
            _readers = readers;
            _filePathProvider = filePathProvider;
            _shapeFactory = shapeFactory;
        }

        public async Task<List<IShape>> LoadShapesAsync()
        {
            string filePath = _filePathProvider.GetFilePath();
            string extension = Path.GetExtension(filePath).ToLower();

            if (!_readers.TryGetValue(extension, out var reader))
            {
                throw new NotSupportedException($"File extension '{extension}' is not supported.");
            }

            using FileStream stream = File.OpenRead(filePath);
            var shapeDataList = await reader.ReadShapesAsync(stream);
            return shapeDataList.Select(_shapeFactory.CreateShape).ToList();
        }
    }
}
