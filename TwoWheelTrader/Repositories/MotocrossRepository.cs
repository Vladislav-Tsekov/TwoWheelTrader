using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Text;
using System.Threading.Channels;
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
            motorcycles.Add(motorcycle);

            using var context = new MotoContext();

            try
            {
                var motocross = new Motocross
                {
                    FuelCost = (decimal)motorcycle.FuelCost,
                    PriceBgn = (decimal)motorcycle.PriceBGN,
                    Distance = motorcycle.DistanceToPickUp,
                    PriceForeign = (decimal)motorcycle.PriceForeign,
                    Profit = (decimal)motorcycle.Profit,
                    Roi = (decimal)motorcycle.ROI,
                    TotalCost = (decimal)motorcycle.TotalCost,
                    Link = motorcycle.Link
                };

                Make? make = context.Makes.FirstOrDefault(m => m.MakeName == motorcycle.Make);
                Model? model = context.Models.FirstOrDefault(m => m.ModelName == motorcycle.Model);
                Year? year = context.Years.FirstOrDefault(y => y.Year1 == motorcycle.Year);
                Cc? cc = context.Ccs.FirstOrDefault(c => c.EngineSize == motorcycle.CC);

                motocross.Make = make;
                motocross.Model = model;
                motocross.Year = year;
                motocross.Cc = cc;

                context.Motocrosses.Add(motocross);
                context.SaveChanges();

                Console.WriteLine("Motorcycle entity added to the database.");

                context.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
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
