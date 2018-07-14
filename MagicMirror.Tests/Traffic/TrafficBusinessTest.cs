using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTests
    {
        private readonly ITrafficService _service;
        private TrafficModel _model;

        private const int Duration = 42;
        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        public TrafficBusinessTests()
        {
            var mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService(mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            var element = new Element
            {
                Distance = new Distance { Value = Distance },
                Duration = new Duration { Value = Duration },
            };

            var entity = new TrafficEntity
            {
                Rows = new[] { new Row {
                    Elements = new [] { element }
                    }
                },
                Origin_addresses = new[] { Origin },
                Destination_addresses = new[] { Destination },
            };

            // Act
            TrafficModel model = _service.MapFromEntity(entity);

            // Assert
            Assert.Equal(model.Distance, Distance);
            Assert.Equal(model.Duration, Duration);
            Assert.Equal(Destination, model.Destination);
            Assert.Equal(Origin, model.Origin);
        }

        [Fact]
        public void Can_Calculate_MetricToImperial()
        {
            // Arrange
            SetUpTestData();
            _model.DistanceUom = DistanceUom.Metric;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(122.31, _model.Distance);
            Assert.Equal(Duration, _model.Duration);
        }

        [Fact]
        public void Can_Calculate_ImperialToMetric()
        {
            // Arrange
            SetUpTestData();
            _model.DistanceUom = DistanceUom.Imperial;

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(47.22, _model.Distance);
            Assert.Equal(Duration, _model.Duration);
        }

        [Fact]
        public void Can_Calculate_TimeOfArrival()
        {
            // Arrange
            SetUpTestData();

            // Act
            _model.ConvertValues();

            // Assert
            Assert.Equal(
                DateTime.Now.AddMinutes(_model.Duration).ToShortTimeString(),
                _model.TimeOfArrival.ToShortTimeString());
        }

        private void SetUpTestData()
        {
            _model = new TrafficModel
            {
                Distance = Distance,
                Duration = Duration,
            };
        }
    }
}