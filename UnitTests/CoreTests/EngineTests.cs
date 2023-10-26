using NUnit.Framework;
using TwoWheelTrader.Core;
using TwoWheelTrader.Core.Interfaces;
using TwoWheelTrader.Models.Interfaces;

namespace UnitTests.CoreTests
{
public class EngineTests
{
    [SetUp]
    public void Setup()
    {
        Controller controller = new();
        Engine engine = new(controller);
        engine.RunProgram();
    }

    [Test]
    public void ControllerInitializesCorrectly()
    {
        Controller controller = new();
        Engine engine = new(controller);

        string make = "yamaha";
        string model = "yzf";
        int cc = 250;
        int year = 2023;
        int foreignPrice = 8000;
        string link = "https://example.com";
        int distance = 100;

        // Act
        var motorcycle = controller.CreateMotorcycle(make, model, cc, year, foreignPrice, link, distance);

        // Assert
        Assert.IsNotNull(motorcycle);
        Assert.AreEqual(make, motorcycle.Make);
        Assert.AreEqual(model, motorcycle.Model);
    }

    [Test]
    public void DestinationExists_ExistingDestination_ReturnsDistance()
    {
        // Arrange
        var controller = new Controller();

        // Act
        int distance = controller.DestinationExists("Linkoping");

        // Assert
        Assert.AreEqual(100, distance);
    }

    [Test]
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

        Controller controller = new();
        Engine engine = new(controller);

        // Act
        IMotorcycle motorcycle = controller.CreateMotorcycle(make, model, cc, year, foreignPrice, link, distance);

        Assert.IsNotNull(motorcycle);
    }
}
}