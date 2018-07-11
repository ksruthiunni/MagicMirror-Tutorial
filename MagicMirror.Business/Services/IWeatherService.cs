using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherModel(string city);

        WeatherModel ConvertValues(WeatherModel model);
    }
}