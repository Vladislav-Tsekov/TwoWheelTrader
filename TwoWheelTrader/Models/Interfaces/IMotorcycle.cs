namespace TwoWheelTrader.Models.Interfaces
{
    public interface IMotorcycle
    {
        const double exchangeRateSEK = 1.642;
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
