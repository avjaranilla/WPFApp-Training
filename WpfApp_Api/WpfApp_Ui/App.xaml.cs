using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppUi_Entities.Interface;
using WpfAppUi_Infra.Repository;

namespace WpfApp_Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IConfiguration Configuration { get; private set; }

        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IListPropertyResponseObjRepo, ListPropertyResponseObjRepo>();
            services.AddScoped<IItemPropertyResponseObjRepo, ItemPropertyResponseObjRepo>();
            services.AddScoped<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            //var serilogLogger = new LoggerConfiguration()
            //                  .WriteTo.File("TheCodeBuzz.txt")
            //                  .CreateLogger();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
