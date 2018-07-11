using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private readonly Mock<WeatherService> _mockService;
        private readonly Mock<WeatherEntity> _mockEntity;

        private const string Location = "London";
        private const float Kelvin = 280.4f;
        private const string Weathertype = "Cloudy";
        private const int Sunrise = 1531194962;
        private const int Sunset = 1531253720;

        public WeatherBusinessTests()
        {
            _mockEntity = new Mock<WeatherEntity>();

            var mockRepo = new Mock<IWeatherRepo>();
            _mockService = new Mock<WeatherService>(mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            _mockEntity.Setup(x => x.Name).Returns(Location);
            _mockEntity.Setup(x => x.Main.Temp).Returns(Kelvin);

            _mockEntity.Setup(x => x.Weather).Returns(() => new[]
            {
                new DataAccess.Entities.Weather.Weather
                {
                    Main = Weathertype
                }
            });

            _mockEntity.Setup(x => x.Sys).Returns(new Sys
            {
                Sunrise = Sunrise,
                Sunset = Sunset
            });

            // Act
            var model = _mockService.Object.MapFromEntity(_mockEntity.Object);

            // Assert
            Assert.Equal(Location, model.Location);
            Assert.Equal(Weathertype, model.WeatherType);
            Assert.Equal(Kelvin, model.Temperature);
            Assert.Equal(Sunrise.ToString(), model.Sunrise);
            Assert.Equal(Sunset.ToString(), model.Sunset);
        }

        [Fact]
        public void Can_Calculate_Values()
        {
            // Arrange
            var model = new WeatherModel()
            {
                Sunrise = "1531281435",
                Sunset = "1531340063",
                Temperature = 290.6,
                Location = "London",
                TemperatureUom = TemperatureUom.Celsius,
                WeatherType = "Clear",
                Icon = "01d"
            };

            // Act
            _mockService.Object.CalculateValues(model);

            // Assert
            Assert.Equal(17.45, model.Temperature);
            Assert.Equal("03:57", model.Sunrise);
            Assert.Equal("20:14", model.Sunset);
        }
    }
}