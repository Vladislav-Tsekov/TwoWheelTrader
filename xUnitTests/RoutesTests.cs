using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Core;
using Xunit;

namespace xUnitTests
{
    public class RoutesTests
    {
        [Fact]
        public void DestinationExists()
        {
            // Arrange
            var controller = new Controller();

            // Act
            int distance = controller.DestinationExists("Linkoping");

            // Assert
            Assert.Equal(15, distance);
        }
    }
}
