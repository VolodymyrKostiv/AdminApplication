using AdminApplication.Navigators;
using AdminApplication.ViewModels;
using AdminApplication.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApplication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();

            services.AddSingleton<IViewModelFactory<AddEmployeeViewModel>, AddEmployeeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CheckEmployeesViewModel>, CheckEmployeesViewModelFactory>();

            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
