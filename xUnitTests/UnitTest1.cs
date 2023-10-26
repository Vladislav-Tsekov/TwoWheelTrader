using TwoWheelTrader.Core;
using Xunit;

namespace UnitTests.CoreTests
{
    public class EngineTests
    {
        [Fact]
        public void ControllerInitializesCorrectly()
        {
            // Arrange
            Controller controller = new Controller();
            string make = "yamaha";
            string model = "yzf";

            // Act
            var motorcycle = controller.CreateMotorcycle(make, model, 250, 2023, 8000, "https://example.com", 100);

            // Assert
            Assert.NotNull(motorcycle);
        }

        [Fact]
        public void DestinationExists_ExistingDestination_ReturnsDistance()
        {
            // Arrange
            var controller = new Controller();

            // Act
            int distance = controller.DestinationExists("Linkoping");

            // Assert
            Assert.Equal(15, distance);
        }

        [Fact]
        public void CreateMotorcycle_ValidInput_CreatesMotorcycle()
        {
            // Arrange
            string make = "yam";
            string model = "yzf";
            int cc = 250;
            int year = 2019;
            int foreignPrice = 33000;
            string link = "www.blocket.com";
            int distance = 10;

            Controller controller = new Controller();

            // Act
            var motorcycle = controller.CreateMotorcycle(make, model, cc, year, foreignPrice, link, distance);

            // Assert
            Assert.NotNull(motorcycle);
        }
    }
}
