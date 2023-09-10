using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Core.Interfaces
{
    public interface IController
    {
        string Add(IMotorcycle motorcycle);
        string RemoveMotorcycle(IMotorcycle motorcycle);
        string GetMotorcycleInfo(IMotorcycle motorcycle);
        string GetMotorcycleList();
    }
}
