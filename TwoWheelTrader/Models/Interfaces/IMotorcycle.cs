namespace TwoWheelTrader.Models.Interfaces
{
    public interface IMotorcycle
    {
        string Make { get; }
        string Model { get; }
        int CC { get; }
        int Year { get; }
        int PriceForeign { get; }
        int PriceBGN { get; }
        int MarketPrice { get; }
        int DistanceToPickUp { get; }
        int FuelCost { get; }
        int TotalCost { get; }
        int Profit { get; }
        string Link { get; }
    }
}
