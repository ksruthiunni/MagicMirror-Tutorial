using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp.Models;
using System;
using System.Threading.Tasks;

namespace MagicMirror.ConsoleApp
{
    public class Main : IMain
    {
        private IWeatherService _weatherService;
        private ITrafficService _trafficService;

        private UserInformation _userInformation;
        private WeatherModel _weatherModel;
        private TrafficModel _trafficModel;

        public Main(IWeatherService weatherService, ITrafficService trafficService)
        {
            _weatherService = weatherService;
            _trafficService = trafficService;
        }

        public async Task RunAsync()
        {
            try
            {
                _userInformation = GetInformation();
                _weatherModel = await GetWeatherModelAsync(_userInformation.Town);
                _trafficModel = await GetTrafficModelAsync($"{_userInformation.Address}, {_userInformation.Town}",
                    _userInformation.WorkAddress);

                GenerateOutput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private UserInformation GetInformation()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your street and number:");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter your zipcode:");
            string zipcode = Console.ReadLine();

            Console.WriteLine("Please enter your town and country:");
            string town = Console.ReadLine();

            Console.WriteLine("Please enter your work address:");
            string workAddress = Console.ReadLine();

            var result = new UserInformation
            {
                Name = name,
                Address = address,
                Zipcode = zipcode,
                Town = town,
                WorkAddress = workAddress
            };

            return result;
        }

        private async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            _weatherModel = await _weatherService.GetWeatherModel(city);
            return _weatherModel;
        }

        private async Task<TrafficModel> GetTrafficModelAsync(string start, string destination)
        {
            _trafficModel = await _trafficService.GetTrafficModel(start , destination);
            return _trafficModel;
        }

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {GetTimeOfDay()} {_userInformation.Name}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {_weatherModel.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {_weatherModel.Temperature} degrees {_weatherModel.TemperatureUom}.");
            Console.WriteLine($"The sun has risen at {_weatherModel.Sunrise} and will set at approximately {_weatherModel.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {_trafficModel.Minutes} minutes. " +
                $"If you leave now, you should arrive at approximately {_trafficModel.TimeOfArrival.ToShortTimeString()}.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }

        private string GetTimeOfDay()
        {
            var currentTime = DateTime.Now.TimeOfDay.Hours;

            if (currentTime >= 0 && currentTime <= 11)
                return "morning";
            else if (currentTime <= 13)
                return "day";
            else if (currentTime <= 18)
                return "afternoon";
            else if (currentTime <= 22)
                return "evening";
            else
                return "night";
        }
    }
}