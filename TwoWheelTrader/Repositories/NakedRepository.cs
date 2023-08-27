using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class NakedRepository : IRepository<INaked>
    {
        private readonly List<INaked> motorcycles;

        public NakedRepository()
        {
            motorcycles = new List<INaked>();
        }

        public IReadOnlyCollection<INaked> Motorcycles => motorcycles;

        public void AddMotorcycle(INaked motorcycle)
        {
            motorcycles.Add(motorcycle);
        }
    }
}
