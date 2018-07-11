using System;
using System.Collections.Generic;
using System.Text;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Xunit;
using Moq;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTest
    {
        private readonly Mock<ITrafficRepo> _mockRepo;
        private readonly TrafficService _service;

        private readonly int distance = 72;
        private readonly int duration = 108;

        public TrafficBusinessTest()
        {
            _mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService(_mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            var mockEntity = new Mock<MockTrafficEntity>();
            mockEntity.Setup(x => x.Rows.Elements.Distance.Value).Returns(distance);
            mockEntity.Setup(x => x.Rows.Elements.Duration.Value).Returns(duration);

            // Act
            var model =_service.MapFromEntity(mockEntity.Object);

            // Assert
            Assert.Equal(distance, model.Distance);
            Assert.Equal(duration, model.Duration);
        }
    }
}
