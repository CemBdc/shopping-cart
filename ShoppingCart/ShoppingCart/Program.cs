using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShoppingCart
{
    /// <summary>
    /// Program.cs will be used to do the setup and register the IOC container
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            serviceProvider.GetService<App>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // required to run the application
            services.AddTransient<App>();

            return services;
        }
    }
}
