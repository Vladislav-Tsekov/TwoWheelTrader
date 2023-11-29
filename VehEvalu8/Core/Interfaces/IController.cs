using VehEvalu8.Data;
using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Core.Interfaces
{
    public interface IController
    {
        IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance);
        void RemoveMotorcycle(string link);
        Task<string> GetMotorcycleInfoAsync(string link);
        Task GetRepositoriesStatusAsync();
        int DestinationExists(string pickUpDestination);
        Task TopFiveByProfitAsync();
        void GetTransportationCost();
    }
}
