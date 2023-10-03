using System.Reflection;
using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Core.Interfaces
{
    public interface IController
    {
        IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance);
        string Add(IMotorcycle motorcycle);
        string RemoveMotorcycle(IMotorcycle motorcycle);
        string GetMotorcycleInfo(string link, string targetRepo);
        void GetRepositoriesStatus();
        int DestinationExists(string pickUpDestination);
        void GetTransportationCost();
        void PrintResult();
    }
}
