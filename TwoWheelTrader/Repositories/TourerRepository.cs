using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class TourerRepository : IRepository<ITourer>
    {
        private readonly List<ITourer> motorcycles;

        public TourerRepository()
        {
            motorcycles = new List<ITourer>();
        }

        public IReadOnlyCollection<ITourer> Motorcycles => motorcycles;

        public void AddMotorcycle(ITourer motorcycle)
        {
            motorcycles.Add(motorcycle);
        }
    }
}
