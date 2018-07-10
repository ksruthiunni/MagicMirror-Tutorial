using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
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
            SetUpMapperConfiguration();
        }

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {
            var model = Mapper.Map<WeatherModel>(entity);
            return model;
        }

        protected void SetUpMapperConfiguration()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);
            Mapper = new Mapper(config);
        }
    }
}