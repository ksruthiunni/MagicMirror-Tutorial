using System.Threading.Tasks;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.Business.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherModel();

        WeatherModel MapFromEntity(WeatherEntity entity);

        WeatherModel CalculateValues(WeatherModel model);
    }
}