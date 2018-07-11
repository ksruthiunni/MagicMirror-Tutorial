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
        private readonly Mock<WeatherEntity> _mockEntity;
        private readonly Mock<IWeatherRepo> _mockRepo;
        private readonly Mock<WeatherService> _mockService;


        private const string Location = "London";
        private const float Kelvin = 290.6f;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1531281435;
        private const int Sunset = 1531340063;

        public WeatherBusinessTests()
        {
            _mockEntity = new Mock<WeatherEntity>();

            _mockRepo = new Mock<IWeatherRepo>();
            _mockService = new Mock<WeatherService>(_mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            _mockEntity.Setup(x => x.Name).Returns(Location);
            _mockEntity.Setup(x => x.Main.Temp).Returns(Kelvin);
            _mockEntity.Setup(x => x.Sys.Sunrise).Returns(Sunrise);
            _mockEntity.Setup(x => x.Sys.Sunset).Returns(Sunset);

            _mockEntity.Setup(x => x.Weather).Returns(() => new[]
            {
                new DataAccess.Entities.Weather.Weather
                {
                    Main = Weathertype
                }
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
                Sunrise = Sunrise.ToString(),
                Sunset = Sunset.ToString(),
                Temperature = Kelvin,
                Location = Location,
                TemperatureUom = TemperatureUom.Celsius,
                WeatherType = Weathertype,
                Icon = Icon
            };

            // Act
            model.ConvertValues();

            // Assert
            Assert.Equal(17.45, model.Temperature);
            Assert.Equal("03:57", model.Sunrise);
            Assert.Equal("20:14", model.Sunset);
        }
    }
}