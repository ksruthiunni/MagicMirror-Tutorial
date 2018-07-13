using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.Business.Services.Contracts;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTests
    {
        private ITrafficService _service;
        private TrafficModel _model;

        private const int Duration = 42;
        private const int Distance = 76;
        private const string origin = "London, Uk";
        private const string destination = "Leeds, Uk";

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
                Rows = new Row[] { new Row {
                    Elements = new Element[]{ element }
                    }
                },
                Origin_addresses = new string[] { origin },
                Destination_addresses = new string[] { destination  },
            };
            // Act
            TrafficModel model = _service.MapFromEntity(entity);

            // Assert
            Assert.Equal(model.Distance, Distance);
            Assert.Equal(model.Duration, Duration);
            Assert.Equal(destination, model.Destination);
            Assert.Equal(origin, model.Origin);
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
            Assert.Equal(DateTime.Now.AddMinutes(_model.Duration).ToShortTimeString()
                , _model.TimeOfArrival.ToShortTimeString());
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