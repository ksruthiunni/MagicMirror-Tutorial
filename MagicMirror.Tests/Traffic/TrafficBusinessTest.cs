using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.Business.Services.Contracts;
using MagicMirror.DataAccess.Repos;
using Xunit;
using Moq;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTest
    {
        private ITrafficService _service;
        private TrafficModel _model;

        private const int Duration = 42;
        private const int Distance = 76;

        public TrafficBusinessTest()
        {
            var mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService(mockRepo.Object);

            SetUpTestData();
        }

        private void SetUpTestData()
        {
            _model = new TrafficModel
            {
                Distance = Distance,
                Duration = Duration,
            };
        }

        [Fact]
        public void Can_Correctly_Convert_Imperial_To_Metric()
        {
            // Arrange
            _model.DistanceUom = DistanceUom.Metric;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(122.31, _model.Distance);
            Assert.Equal(Duration, _model.Duration);
        }

        [Fact]
        public void Can_Correctly_Convert_Metric_To_Imperial()
        {
            // Arrange
            _model.DistanceUom = DistanceUom.Imperial;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(47.22, _model.Distance);
            Assert.Equal(Duration, _model.Duration);
        }
    }
}
