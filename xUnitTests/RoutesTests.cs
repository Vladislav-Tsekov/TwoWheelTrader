using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehEvalu8.Core;
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
            int distance = controller.DestinationExists("Falun");

            // Assert
            Assert.Equal(350, distance);
        }
    }
}
