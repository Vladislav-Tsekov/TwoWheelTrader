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

        public void TopFiveByProfit(IRepository<ISport> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(3);
        }

        public void TopFiveROI(IRepository<ISport> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.ROI).Take(5);
        }
    }
}
