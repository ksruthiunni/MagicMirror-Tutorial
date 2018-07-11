using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private IWeatherRepo _repo;
        private IMapper _mapper;

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

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {
            var model = _mapper.Map<WeatherModel>(entity);
            return model;
        }

        public WeatherModel CalculateValues(WeatherModel model)
        {
            return model.ConvertValues();
        }

        protected void SetUpMapperConfiguration()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);
            _mapper = new Mapper(config);
        }
    }
}