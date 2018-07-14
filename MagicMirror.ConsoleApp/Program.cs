using MagicMirror.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Entry to run app
            serviceProvider.GetService<Main>().RunAsync().GetAwaiter().GetResult();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<ITrafficService, TrafficService>();
            serviceCollection.AddTransient<IWeatherService, WeatherService>();

            // add app
            serviceCollection.AddTransient<Main>();
        }
    }
}