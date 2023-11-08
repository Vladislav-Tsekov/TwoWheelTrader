using System.Reflection;
using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Core.Interfaces
{
    public interface IController
    {
        IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance);
        string RemoveMotorcycle(IMotorcycle motorcycle);
        string GetMotorcycleInfo(string link);
        void GetRepositoriesStatus();
        int DestinationExists(string pickUpDestination);
        void GetTransportationCost();

        //string Add(IMotorcycle motorcycle); //DEPRECATED
        //void PrintResult(); //DEPRECATED
    }
}
