using VehEvalu8.Core;
using VehEvalu8.Data;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories;
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
            var motorcycle = controller.CreateMotorcycle(make, model, 250, 2023, 8000, "www.yamaha.com", 100);

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
            controller.RemoveMotorcycle("www.yamaha.com");
        }

        [Fact]
        public void GetMotorcycleInfo()
        {
            // Arrange
            Controller controller = new Controller();
            MotocrossRepository motocross = new();
            MotoContext context = new();
            IMotorcycle motorcycle = new VehEvalu8.Models.Motocross.Kawasaki(250, 2019, 35000, "www.kawa250.com", 15);
            motocross.AddMotorcycle(motorcycle, context);
            string link = "www.kawa250.com";

            // Act

            // Assert
            //TODO - IMPLEMENT TEST
        }
    }
}
