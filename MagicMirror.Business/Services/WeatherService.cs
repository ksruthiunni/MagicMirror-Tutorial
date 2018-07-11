using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService : Service<WeatherModel>, IWeatherService
    {
        private readonly IWeatherRepo _repo;

        public WeatherService(IWeatherRepo repo)
        {
            _repo = repo;
            SetUpMapperConfiguration();
        }

        public async Task<WeatherModel> GetWeatherModel(string city)
        {
            var entity = await _repo.GetWeatherEntityByCityAsync(city);
            var model = MapFromEntity(entity);
            model.ConvertValues();

            return model;
        }

        public WeatherModel ConvertValues(WeatherModel model)
        {
            return model.ConvertValues();
        }
    }
}