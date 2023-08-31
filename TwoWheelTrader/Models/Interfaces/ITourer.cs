namespace TwoWheelTrader.Models.Interfaces
{
    public interface ITourer : IMotorcycle
    {
        // CREATE THESE TYPES OF MOTORCYCLES LAST --- LOW PRIORITY

        int Kilometers { get; }
    }
}
