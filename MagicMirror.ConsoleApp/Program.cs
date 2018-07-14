using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<Main>().RunAsync().GetAwaiter().GetResult();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<ITrafficService, TrafficService>();
            serviceCollection.AddTransient<ITrafficRepo, TrafficRepo>();
            serviceCollection.AddTransient<IWeatherService, WeatherService>();
            serviceCollection.AddTransient<IWeatherRepo, WeatherRepo>();

            // add app
            serviceCollection.AddTransient<Main>();
        }
    }
}