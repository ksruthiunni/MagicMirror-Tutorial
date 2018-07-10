using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;

namespace MagicMirror.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private IWeatherRepo _repo;
        private IMapper Mapper;

        public WeatherService(IWeatherRepo repo)
        {
            _repo = repo;
        }

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {
            
        }
    }
}