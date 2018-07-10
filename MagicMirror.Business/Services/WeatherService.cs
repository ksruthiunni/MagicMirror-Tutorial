using Acme.Generic.Helpers;
using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System;

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

        public WeatherModel CalculateValues(WeatherModel model)
        {
            model.Temperature = ConvertTemperature(model.Temperature, TemperatureUom.Celsius);

            return model;
        }

        private double ConvertTemperature(double degrees, TemperatureUom uom)
        {
            double convertedDegrees = -1;

            switch (uom)
            {
                case TemperatureUom.Celsius:
                    convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    break;

                case TemperatureUom.Fahrenheit:
                    convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    break;

                case TemperatureUom.Kelvin:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(uom), uom, null);
            }

            return convertedDegrees;
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