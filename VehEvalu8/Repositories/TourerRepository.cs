using System.Text;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories.Interfaces;

namespace VehEvalu8.Repositories
{
    public class TourerRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public TourerRepository()
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

        public string RepositoryStatus() 
        {
            if (this.motorcycles.Count > 0)
            {
                StringBuilder sb = new();

                sb.AppendLine($"{Environment.NewLine}{this.GetType().Name} has the following motorcycles.");

                foreach (var moto in motorcycles)
                {
                    sb.Append($"{moto.Make}, {moto.Model.ToUpper()}, {moto.Year}, {moto.PriceForeign}, {moto.MarketPrice}, {(int)moto.TotalCost}, {(int)moto.Profit}, {moto.Link}, {moto.ROI:f2}{Environment.NewLine}");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return $"{this.GetType().Name} is empty!"; 
            }
        }

        public void TopFiveByProfit()
        {

        }
    }
}
