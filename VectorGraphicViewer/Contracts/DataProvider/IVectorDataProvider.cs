﻿namespace VectorGraphicViewer.Contracts.DataProvider
{
    public interface IVectorDataProvider
    {
        Task<List<IShape>> LoadShapesAsync();
    }
}
