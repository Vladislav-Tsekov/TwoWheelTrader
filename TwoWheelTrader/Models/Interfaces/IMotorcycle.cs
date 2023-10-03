using System.Runtime.CompilerServices;

namespace TwoWheelTrader.Models.Interfaces
{
    public interface IMotorcycle
    {
        const double exchangeRateSEK = 0.1688; // LAST UPDATE - 02.10.2023
        const double dieselPriceBGN = 4.32; // LAST UPDATE - 02.10.2023
        const int commission = 800;
        string Make { get; }
        string Model { get; }
        int CC { get; }
        int Year { get; }
        double PriceForeign { get; }
        double PriceBGN { get; }
        double MarketPrice { get; }
        int DistanceToPickUp { get; }
        double FuelCost { get; }
        double TotalCost { get; }
        double Profit { get; }
        double ROI { get; }
        string Link { get; }
    }
}
