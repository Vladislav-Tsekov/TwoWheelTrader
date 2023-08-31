namespace TwoWheelTrader.Models.Interfaces
{
    public interface ISport : IMotorcycle
    {
        // STREET LEGAL SPORT BIKES, IMPORTANT TO SEPARATE THEM INTO CC CATEGORIES AS WELL

        int Kilometers { get; }
    }
}
