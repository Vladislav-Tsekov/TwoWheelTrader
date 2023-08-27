using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class SportRepository : IRepository<ISport>
    {
        private readonly List<ISport> motorcycles;

        public SportRepository()
        {
            motorcycles = new List<ISport>();
        }

        public IReadOnlyCollection<ISport> Motorcycles => motorcycles;

        public void AddMotorcycle(ISport motorcycle)
        {
            motorcycles.Add(motorcycle);
        }
    }
}
