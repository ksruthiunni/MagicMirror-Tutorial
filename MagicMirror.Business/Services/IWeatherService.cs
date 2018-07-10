using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.Business.Services
{
    public interface IWeatherService
    {
        WeatherModel MapFromEntity(WeatherEntity entity);

        //WeatherModel CalculateValues(WeatherModel model);
    }
}