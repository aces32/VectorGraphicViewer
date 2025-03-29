using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VectorGraphicViewer.Contracts;
using VectorGraphicViewer.Contracts.DataProvider;
using VectorGraphicViewer.Data;
using VectorGraphicViewer.Data.Reader;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<VectorViewModel>();
            services.AddTransient<JsonShapeDataReader>();
            services.AddTransient<IFilePathProvider, FilePathProvider>();
            services.AddSingleton<IShapeFactory, ShapeFactory>();
            services.AddTransient<IVectorDataProvider>(provider =>
            {
                var readers = new Dictionary<string, IShapeDataReader>
                {
                    { ".json", provider.GetRequiredService<JsonShapeDataReader>() },
                };

                var filePathProvider = provider.GetRequiredService<IFilePathProvider>();
                var shapeFactory = provider.GetRequiredService<IShapeFactory>();
                return new VectorDataProvider(readers, filePathProvider, shapeFactory);
            });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }

}
