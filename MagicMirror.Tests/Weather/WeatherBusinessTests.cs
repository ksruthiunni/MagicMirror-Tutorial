using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.Business.Services.Contracts;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private readonly IWeatherService _service;
        private WeatherModel _model;

        private const string Location = "London";
        private const double Kelvin = 295.15;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1531281435;
        private const int Sunset = 1531340063;

        public WeatherBusinessTests()
        {
            var mockRepo = new Mock<IWeatherRepo>();
            _service = new WeatherService(mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            var mockEntity = new Mock<WeatherEntity>();
            mockEntity.Setup(x => x.Name).Returns(Location);
            mockEntity.Setup(x => x.Main.Temp).Returns(Kelvin);
            mockEntity.Setup(x => x.Sys.Sunrise).Returns(Sunrise);
            mockEntity.Setup(x => x.Sys.Sunset).Returns(Sunset);

            mockEntity.Setup(x => x.Weather).Returns(() => new[]
            {
                new DataAccess.Entities.Weather.Weather
                {
                    Main = Weathertype
                }
            });

            // Act
            _model = _service.MapFromEntity(mockEntity.Object);

            // Assert
            Assert.Equal(Location, _model.Location);
            Assert.Equal(Weathertype, _model.WeatherType);
            Assert.Equal(Kelvin, _model.Temperature);
            Assert.Equal(Sunrise.ToString(), _model.Sunrise);
            Assert.Equal(Sunset.ToString(), _model.Sunset);
        }

        [Fact]
        public void Can_Calculate_SunRise_SunSet()
        {
            // Arrange
            SetUpTestData();

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal("03:57", _model.Sunrise);
            Assert.Equal("20:14", _model.Sunset);
        }

        [Fact]
        public void Can_Convert_kelvin_To_Celsius()
        {
            // Arrange
            SetUpTestData();
            _model.TemperatureUom = TemperatureUom.Celsius;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(22, _model.Temperature);
        }

        [Fact]
        public void Can_Convert_kelvin_To_Fahrenheit()
        {
            // Arrange
            SetUpTestData();
            _model.TemperatureUom = TemperatureUom.Fahrenheit;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(71.87, _model.Temperature);
        }

        private void SetUpTestData()
        {
            _model = new WeatherModel
            {
                Sunrise = Sunrise.ToString(),
                Sunset = Sunset.ToString(),
                Temperature = Kelvin,
                Location = Location,
                WeatherType = Weathertype,
                Icon = Icon
            };
        }
    }
}