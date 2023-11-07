using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Text;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;
using VehEvalu8.Data;
using VehEvalu8.Data.DBModels;

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
            using (var context = new MotoContext())
            {
                var motocross = new Motocross
                {
                    FuelCost = (decimal)motorcycle.FuelCost,
                    PriceBgn = (decimal)motorcycle.PriceBGN,
                    PriceForeign = (decimal)motorcycle.PriceForeign,
                    Profit = (decimal)motorcycle.Profit,
                    Roi = (decimal)motorcycle.ROI,
                    TotalCost = (decimal)motorcycle.TotalCost,
                };
            }
        }

        public IMotorcycle MotorcycleInfo(string link)
        {
            IMotorcycle? findMotorcycleByLink = motorcycles.Where(m => m.Link == link).FirstOrDefault();
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
