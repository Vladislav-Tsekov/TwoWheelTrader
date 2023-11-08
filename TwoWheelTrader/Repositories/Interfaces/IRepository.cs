using Microsoft.EntityFrameworkCore;
using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void AddMotorcycle(T motorcycle);

        void TopFiveByProfit(IRepository<T> motorcycles); 

        void TopFiveROI(IRepository<T> motorcycles);

        string RepositoryStatus();

        //void RemoveMotorcycle(string motorcycle); -- Not yet implemented, signature unknown, probably an ID

        //void MotorcycleExists(T motorcycle); -- Not sure if this will be needed for the scope of the program, will just add it for now
    }
}
