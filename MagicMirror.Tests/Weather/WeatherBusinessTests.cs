using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private Mock<IWeatherRepo> mockRepo;
        private Mock<WeatherService> mockService;
        private Mock<WeatherEntity> mockEntity;

        private string location = "London";
        private float fahrenheit = 280.4f;
        private string weathertype = "Cloudy";
        private int sunrise = 1531194962;
        private int sunset = 1531253720;

        public WeatherBusinessTests()
        {
            mockRepo = new Mock<IWeatherRepo>();
            mockEntity = new Mock<WeatherEntity>();

            mockService = new Mock<WeatherService>(mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            mockEntity.Setup(x => x.Name).Returns(location);
            mockEntity.Setup(x => x.Main.Temp).Returns(fahrenheit);
            //mockEntity.Setup(x => x.Weather).Returns()


            mockEntity.Setup(x => x.Sys).Returns(new Sys
            {
                Sunrise = sunrise,
                Sunset = sunset
            });

            // Act
            var model = mockService.Object.MapFromEntity(mockEntity.Object);

            // Assert
            Assert.Equal(location, model.Location);
            Assert.Equal(fahrenheit, model.Temperature);
            Assert.Equal(sunrise.ToString(), model.Sunrise);
            Assert.Equal(sunset.ToString(), model.Sunset);
        }
    }
}