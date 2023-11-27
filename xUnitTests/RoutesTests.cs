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
