using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class MotocrossRepository : IRepository<IMotocross>
    {
        private readonly List<IMotocross> motorcycles;
        public MotocrossRepository()
        {
            motorcycles = new List<IMotocross>();
        }

        public IReadOnlyCollection<IMotocross> Motorcycles => motorcycles;

        public void AddMotorcycle(IMotocross motorcycle)
        {
            motorcycles.Add(motorcycle);
        }
    }
}
