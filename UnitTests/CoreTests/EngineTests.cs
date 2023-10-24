namespace UnitTests.CoreTests;

using NUnit.Framework;
using TwoWheelTrader.Core;
using TwoWheelTrader.Core.Interfaces;
using TwoWheelTrader.Models.Interfaces;

public class EngineTests
{
    [SetUp]
    public void Setup()
    {
        Controller controller = new();
        Engine engine = new(controller);
    }

    [Test]
    public void ControllerInitializesCorrectly()
    {
        Controller controller = new();
        Assert.IsNull(controller);
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