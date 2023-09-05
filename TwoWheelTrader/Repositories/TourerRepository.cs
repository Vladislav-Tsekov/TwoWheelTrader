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

        public void TopFiveByProfit(IRepository<IEnduro> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(3);
        }

        public void TopFiveROI(IRepository<IEnduro> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.ROI).Take(5);
        }
    }
}
