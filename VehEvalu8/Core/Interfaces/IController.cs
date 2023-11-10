using System.Reflection;
using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Core.Interfaces
{
    public interface IController
    {
        IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance);
        string RemoveMotorcycle(IMotorcycle motorcycle);
        string GetMotorcycleInfo(string link);
        void GetRepositoriesStatus();
        int DestinationExists(string pickUpDestination);
        public void TopFiveByProfit();
        void GetTransportationCost();

        //string Add(IMotorcycle motorcycle); //DEPRECATED
        //void PrintResult(); //DEPRECATED
    }
}
