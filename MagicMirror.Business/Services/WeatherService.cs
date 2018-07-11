using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
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

        public async Task<WeatherModel> GetWeatherModel()
        {
            var entity = await _repo.GetWeatherEntityByCityAsync("London");
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