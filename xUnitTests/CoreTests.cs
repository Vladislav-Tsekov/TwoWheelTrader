using System.Reflection;
using TwoWheelTrader.Core;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories;
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
        public void CreateMotorcycle()
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

        [Fact]
        public void GetMotorcycleInfo()
        {
            // Arrange
            Controller controller = new Controller();
            MotocrossRepository motocross = new();
            IMotorcycle motorcycle = new TwoWheelTrader.Models.Motocross.Kawasaki("KXF", 250, 2019, 35000, "www.kawa250.com", 15);
            motocross.AddMotorcycle(motorcycle);
            string link = "www.kawa250.com";
            string targetRepo = "mx";

            // Act
            string info = controller.GetMotorcycleInfo(link, targetRepo);

            // Assert

            //TODO - RUN THE TEST
        }
    }
}
