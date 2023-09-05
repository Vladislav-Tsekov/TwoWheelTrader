using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class EnduroRepository : IRepository<IEnduro>
    {
        private readonly List<IEnduro> motorcycles;

        public EnduroRepository()
        {
            motorcycles = new List<IEnduro>();
        }
        public IReadOnlyCollection<IEnduro> Motorcycles => motorcycles;

        public void AddMotorcycle(IEnduro motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void TopThreeByProfit(IRepository<IEnduro> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(3);
        }

        public void TopThreeROI(IRepository<IEnduro> motorcycles)
        {
            throw new NotImplementedException();
        }
    }
}
