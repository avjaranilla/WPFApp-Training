using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppUi_Entities.Interface;
using WpfAppUi_Infra.Repository;
using WpfAppUi_Services;
using WpfAppUi_Services.Commands.ItemCommands;
using WpfAppUi_Services.Commands.ListCommands;
using WpfAppUi_Services.Queries.ItemQueries;

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

            services.AddMediatR(typeof(GetListQueryHandler));
            services.AddMediatR(typeof(InsertListCommandHandler));
            services.AddMediatR(typeof(UpdateListCommandHandler));
            services.AddMediatR(typeof(DeleteListCommandHandler));

            services.AddMediatR(typeof(GetItemQueryHandler));
            services.AddMediatR(typeof(InsertItemCommandHandler));
            services.AddMediatR(typeof(UpdateItemCommandHandler));
            services.AddMediatR(typeof(DeleteItemByItemIdCommandHandler));
            services.AddMediatR(typeof(DeleteItemByListIdCommandHandler));

            services.AddScoped<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
