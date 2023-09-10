using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class MotocrossRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;
        public MotocrossRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public IReadOnlyCollection<IMotorcycle> Motorcycles => motorcycles;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void TopFiveByProfit(IRepository<IMotorcycle> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(3);
        }

        public void TopFiveROI(IRepository<IMotorcycle> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.ROI).Take(5);
        }
    }
}
