using Microsoft.EntityFrameworkCore;
using System.Text;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;
using VehEvalu8.Data;
using VehEvalu8.Data.DBModels;

namespace TwoWheelTrader.Repositories
{
    public class MotocrossRepository : IRepository<IMotorcycle>
    {
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);

            using var context = new MotoContext();

            try
            {
                var moto = new Motocross
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

                moto.Make = make;
                moto.Model = model;
                moto.Year = year;
                moto.Cc = cc;

                context.Motocrosses.Add(moto);
                context.SaveChanges();

                Console.WriteLine($"{moto.GetType().Name} motorcycle added successfully to database.");

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
            MotoContext? database = new();

            if (database.Motocrosses.Any())
            {
                var motoTable = database.Motocrosses
                    .Include(m => m.Make).Include(m => m.Model)
                    .Include(m => m.Cc).Include(m => m.Year)
                    .AsNoTracking()
                    .Select(m => new
                    {
                        m.Make.MakeName,
                        m.Model.ModelName,
                        m.Cc.EngineSize,
                        m.Year.Year1,
                        m.TotalCost,
                        m.Profit,
                        m.Roi,
                    })
                    .ToList();

                StringBuilder dbRepoBuilder = new();

                dbRepoBuilder.AppendLine($"{Environment.NewLine}{this.GetType().Name} has the following motorcycles.");

                foreach (var m in motoTable)
                {
                    dbRepoBuilder.AppendLine($"{m.MakeName} {m.ModelName} {m.EngineSize} ({m.Year1}). Cost: {m.TotalCost}, Profit: {m.Profit}, ROI: {m.Roi}.");
                }

                return dbRepoBuilder.ToString().TrimEnd();
            }
            else
            {
                return $"{this.GetType().Name} is empty!";
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
