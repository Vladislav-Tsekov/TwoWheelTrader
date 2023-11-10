using Microsoft.EntityFrameworkCore;
using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void AddMotorcycle(T motorcycle);

        void TopFiveByProfit(); 

        string RepositoryStatus();

        //void RemoveMotorcycle(string motorcycle); -- Not yet implemented, signature unknown, probably an ID

        //void MotorcycleExists(T motorcycle); -- Not sure if this will be needed for the scope of the program, will just add it for now
    }
}
