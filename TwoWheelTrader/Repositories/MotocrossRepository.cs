using System.Text;
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

        public IMotorcycle MotorcycleInfo(string link)
        {
            var findMotorcycleByLink = motorcycles.Where(m => m.Link == link).FirstOrDefault();
            return findMotorcycleByLink;
        }

        public string RepositoryStatus() // NEEDS TESTING
        {
            if (this.motorcycles.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var moto in motorcycles)
                {
                    sb.AppendLine($"{moto.Make}, {moto.Model}, {moto.Year}, {moto.PriceForeign}, {moto.MarketPrice}, {moto.TotalCost}, {moto.Profit}, {moto.Link}, {moto.ROI}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return $"{this.GetType().Name} is empty!"; // CHECK THE OUTPUT
            }
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
