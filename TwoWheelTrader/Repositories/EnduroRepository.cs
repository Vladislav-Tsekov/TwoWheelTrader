using System.Text;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class EnduroRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public EnduroRepository()
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

                sb.AppendLine($"{this.GetType().Name} has the following motorcycles.");

                foreach (var moto in motorcycles)
                {
                    sb.AppendLine($"{moto.Make}, {moto.Model}, {moto.Year}, {moto.PriceForeign}, {moto.MarketPrice}, {moto.TotalCost:f2}, {moto.Profit:f2}, {moto.Link}, {moto.ROI:f2}");
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
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(5);
        }

        public void TopFiveROI(IRepository<IMotorcycle> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.ROI).Take(5);
        }
    }
}
